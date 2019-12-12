using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using DBManager.Utils;
using log4net;

namespace DBManager
{
    public class DatabaseManager
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(DatabaseManager).Name);

        private SqlConnection connection = null;
        private SqlCommand command = null;
        private SqlDataReader reader = null;
        private StringBuilder outputBuilder = null;

        private void SetCommandType(string sql)
        {
            if (command != null)
            {
                if (sql.StartsWith("[") && sql.EndsWith("]"))
                    command.CommandType = CommandType.StoredProcedure;
                else
                    command.CommandType = CommandType.Text;
            }
        }

        private void connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            outputBuilder.Append("Source : " + e.Source);
            if (e.Errors != null)
            {
                foreach (SqlError error in e.Errors)
                    outputBuilder.Append(error.Message);
            }
            outputBuilder.Append(e.Message);
        }

        private void CloseStuff()
        {
            try
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                    reader = null;
                }
                if (command != null)
                {
                    command.Parameters.Clear();
                    command.Dispose();
                    command = null;
                }
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                    connection = null;
                }
            }
            catch // ignore
            {
            }
        }

        private SqlCommand CreateCommand()
        {
            try
            {
                connection = new SqlConnection(DBConfig.ConnectionString);
                connection.Open();
                return connection.CreateCommand();
            }
            catch (Exception e)
            {
                log.Error("Problem connecting to Database = ", e);
                throw e;
            }
        }

        private void InitializeCommand(string sql, SqlParameter[] parameters = null)
        {
            command = CreateCommand();
            command.CommandText = sql;
            if (parameters != null)
                command.Parameters.AddRange(parameters);

            SetCommandType(sql);
        }

        private void ExecuteScript(string scriptSQL)
        {
            try
            {
                // split script on GO command
                IEnumerable<string> commandStrings = Regex.Split(scriptSQL, @"^\s*GO\s*$",
                    RegexOptions.Multiline | RegexOptions.IgnoreCase);

                // we need to use the same connection while executing multiple statements. 
                // This is because of Temperory Tables (i.e. #Config)
                // Temp tables are cleared/dropped once the connection are reset.
                // this causes problems while executing long scripts

                connection = new SqlConnection(DBConfig.ConnectionString);
                try
                {
                    connection.Open();
                }
                catch (Exception e)
                {
                    log.Error(e.Message, e);
                    log.Warn("The Database does not exist. Trying to create the database.");
                    // the database has not been created yet.
                    CloseStuff();
                    TryCreateDatabase();

                    Thread.Sleep(5000); // sleep for 5 seconds.

                    connection = new SqlConnection(DBConfig.ConnectionString);
                    connection.Open();
                }
                command = connection.CreateCommand();

                foreach (string commandText in commandStrings)
                {
                    command.CommandText = commandText;
                    if (!String.IsNullOrEmpty(commandText))
                    {
                        log.Debug("Executing Command = " + commandText);
                        command.ExecuteNonQuery();
                    }
                }
                log.Info("Script Executed Successfully.");
            }
            catch (Exception ex)
            {
                // Reports any errors and abort.
                log.Error(ex.Message, ex);
                throw ex;
            }
            finally
            {
                CloseStuff();
            }
        }

        private void TryCreateDatabase()
        {
            try
            {
                connection = new SqlConnection(DBConfig.GetAllAccessConnectionString);
                log.Debug("Database connection String");
                log.Debug("********************************");
                log.Debug(DBConfig.ConnectionString);
                log.Debug(DBConfig.GetAllAccessConnectionString);
                log.Debug("********************************");
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "CREATE DATABASE " + DBConfig.DatabaseName;
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                log.Error(e.Message, e);
            }
            finally
            {
                CloseStuff();
            }
        }

        private int ExecuteUpdate(string sql, SqlParameter[] parameters = null, 
            StringBuilder printCommands = null, int timeout = 0)
        {
            try
            {
                InitializeCommand(sql, parameters);

                if (printCommands != null)
                {
                    outputBuilder = null;
                    // we need to capture the print statements in the SQL
                    connection.InfoMessage += new SqlInfoMessageEventHandler(connection_InfoMessage);
                    outputBuilder = printCommands;
                }

                if (timeout > 0)
                    command.CommandTimeout = timeout;

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }
            catch (Exception e)
            {
                log.Fatal("SQL data Exception = ", e);
                throw e;
            }
            finally
            {
                CloseStuff();
            }
        }

        private List<object> ExecuteQuery(string sql, IDBValue valueObject, SqlParameter[] parameters = null)
        {
            try
            {
                InitializeCommand(sql, parameters);

                reader = command.ExecuteReader();
                List<object> retValues = new List<object>();
                while (reader.Read())
                {
                    object obj = valueObject.RestoreObject(reader);
                    if (obj != null)
                        retValues.Add(obj);
                }
                return retValues;
            }
            catch (Exception e)
            {
                log.Fatal("SQL data Exception = ", e);
                throw e;
            }
            finally
            {
                CloseStuff();
            }
        }

        private object ExecuteScalar(string sql, SqlParameter[] parameters = null)
        {
            try
            {
                InitializeCommand(sql, parameters);

                return command.ExecuteScalar();
            }
            catch (Exception e)
            {
                log.Fatal("SQL data Exception = ", e);
                throw e;
            }
            finally
            {
                CloseStuff();
            }
        }

        /// <summary>
        /// Wrapper method for all the database operations. Method executions varies based on the Query Mode
        /// </summary>
        /// <param name="sql">Script of sql statements to execute.</param>
        /// <param name="mode">If value is <value>Multiple</value> sql would be first split into 
        /// individual queries based on GO keyword. The method also tries to create database if it does not 
        /// exists which is useful while setting up the application post install. 
        /// <remarks>Returns Null</remarks> <br />
        /// If value is <value>Reader</value> internally executes the ExecuteReader method and returns the 
        /// listof object based after calling the restore object method. Parameter obj should be of type IDBValue 
        /// if value is <value>Reader</value><paramref name="obj"/> throws ArgumentExeception. <br />
        /// If value is <value>Scalar</value> runs the ExecuteScalar method and returns the object returned 
        /// by the database query. <br />
        /// If value is <value>Update</value> runs the ExecuteUpdate method. Returns the number of rows 
        /// modified by the sql statement. <br />
        /// If value is <value>ConfigReader</value> runs the sql query against the [dbo].[Configuration] table
        /// which is used for storing application specific config entries in the database. Returns ConfigValue Object.
        /// </param>
        /// <param name="parameters">Parameters to be passed to the sql query command</param>
        /// <param name="obj">If <value>Mode is Reader</value> should be of type IDBValue and cannot be null <br />
        /// If <value>Mode is Update</value>, if not null, should be of type StringBuilder. Returns the 
        /// log of the execution in the StringBuilder object. <br />
        /// </param>
        /// <param name="timeout">Query execution timeout, 0 for default timeout value</param>
        /// <returns>If <value>Mode is Multiple</value>, null<br />
        /// If <value>Mode is Reader</value> List of object of type <object>List based on <paramref name="obj"/></object>
        /// If <value>Mode is Scalar</value> returns the result of the database query.
        /// If <value>Mode is Update</value> returns the number of rows affected by the query.
        /// If <value>Mode is ConfigReader</value> returns the config entries for a particular domain passed as parameters
        /// </returns>
        public object ExecuteQuery(string sql, QueryMode mode, SqlParameter[] parameters = null, 
            object obj = null, int timeout = 0)
        {
            switch (mode)
            {
                case QueryMode.Script:
                    ExecuteScript(sql);
                    break;
                case QueryMode.Reader:
                    if (obj == null || (obj as IDBValue) == null)
                    {
                        string error = "Invalid object passed. Obj must be an IDBValue is QueryMode is 'Reader'";
                        throw new ArgumentException(error);
                    }
                    return ExecuteQuery(sql, obj as IDBValue, parameters) as List<object>;
                case QueryMode.Scalar:
                    return ExecuteScalar(sql, parameters);
                case QueryMode.Update:
                    if (obj != null && (obj as StringBuilder) == null) // check if object passed in is correct.
                    {
                        string error = "Invalid argument passed. Obj must be an String Builder is QueryMode is 'Update'";
                        throw new ArgumentException(error);
                    }
                    return ExecuteUpdate(sql, parameters, obj as StringBuilder, timeout);
                case QueryMode.ConfigReader:
                    if (obj != null && (obj as ConfigValue) == null) // check if object passed in is correct.
                    {
                        string error = "Invalid argument passed. Obj must be an ConfigValue is QueryMode is 'ConfigReader'";
                        throw new ArgumentException(error);
                    }
                    return ExecuteConfigQuery(sql, obj as ConfigValue, parameters);
            }
            return null;
        }

        private ConfigValue ExecuteConfigQuery(string sql, ConfigValue configValue, SqlParameter[] parameters = null)
        {
            try
            {
                InitializeCommand(sql, parameters);

                reader = command.ExecuteReader();
                return configValue.RestoreObject(reader) as ConfigValue;
            }
            catch (Exception e)
            {
                log.Fatal("SQL data Exception = ", e);
                throw e;
            }
            finally
            {
                CloseStuff();
            }
        }
    }
}