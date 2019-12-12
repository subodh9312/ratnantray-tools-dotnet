using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using log4net;

namespace DBManager.Utils
{
    public static class DBUtils
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(DBUtils).Name);

        public static void SaveConnectionString(string location, string connectionStringName, string connectionString, string providerName)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(location);
            string connectionsection = config.ConnectionStrings.ConnectionStrings[connectionStringName].ConnectionString;

            ConnectionStringSettings connectionstring = null;
            if (connectionsection != null)
            {
                config.ConnectionStrings.ConnectionStrings.Remove(connectionStringName);
            }

            connectionstring = new ConnectionStringSettings(connectionStringName, connectionString, providerName);
            config.ConnectionStrings.ConnectionStrings.Add(connectionstring);

            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        public static void SaveConnectionString(string location, string connectionStringName, string connectionString)
        {
            SaveConnectionString(location, connectionStringName, connectionString, "System.Data.SqlClient");
        }

        public static string GetConnectionString(string dataSource, string initialCatalog,
            string userId, string password, string attachDbFileName = "", string dataDirectory = "")
        {
            StringBuilder connectionString = new StringBuilder();

            if (!String.IsNullOrEmpty(dataDirectory))
                AppDomain.CurrentDomain.SetData("DataDirectory", dataDirectory);
            else
                AppDomain.CurrentDomain.SetData("DataDirectory", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            connectionString.Append("Data Source=");
            connectionString.Append(dataSource);
            connectionString.Append(";");
            if (!String.IsNullOrEmpty(attachDbFileName))
            {
                connectionString.Append("AttachDbFileName=");
                connectionString.Append("|DataDirectory|" + attachDbFileName);
            }
            else
            {
                connectionString.Append("Initial Catalog=");
                if (String.IsNullOrEmpty(initialCatalog))
                    initialCatalog = "tempdb";

                connectionString.Append(initialCatalog);
            }
            connectionString.Append(";");
            if (!String.IsNullOrEmpty(userId) && !String.IsNullOrEmpty(password))
            {
                connectionString.Append("Integrated Security=False; User Id=");
                connectionString.Append(userId);
                connectionString.Append(";Password=");
                connectionString.Append(password);
            }
            else
            {
                connectionString.Append("Integrated Security=True");
            }
            connectionString.Append(";");

            return connectionString.ToString();
        }

        public static void WriteApplicationSettings(string assmeblyPath, string appSettingName,
            string appSettingValue)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(assmeblyPath);
            AppSettingsSection section = config.AppSettings;

            if (section != null)
            {
                if (section.Settings[appSettingName] != null)
                    section.Settings.Remove(appSettingName);

                section.Settings.Add(new KeyValueConfigurationElement(appSettingName, appSettingValue));
                config.Save();

                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        public static string GetConnectionString(string assemblyPath, bool isAllAccess = false)
        {
            Configuration config = null;
            string dataSource = "";
            string initialCatalog = "";
            string userId = "";
            string password = "";
            string attachDbFileName = "";
            string dataDirectory = "";
            try
            {
                config = ConfigurationManager.OpenExeConfiguration(assemblyPath);
                dataSource = config.AppSettings.Settings["ConnectionString.DataSource"].Value;
                if (!isAllAccess)
                {
                    initialCatalog = config.AppSettings.Settings["ConnectionString.InitialCatalog"].Value;
                }
                else
                {
                    initialCatalog = "tempdb";
                }
                userId = config.AppSettings.Settings["ConnectionString.UserId"].Value;
                password = config.AppSettings.Settings["ConnectionString.Password"].Value;

                if (!String.IsNullOrEmpty(password))
                    password = StringCipher.Decrypt(password);

                attachDbFileName = config.AppSettings.Settings["ConnectionString.AttachDbFileName"].Value;
                dataDirectory = config.AppSettings.Settings["ConnectionString.DataDirectory"].Value;

                if (String.IsNullOrEmpty(dataDirectory))
                    dataDirectory = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            }
            catch (Exception e)
            {
                log.Error(e.Message, e);

                log.Warn("Trying the dirty method");
                return loadConfig(assemblyPath);
            }

            return GetConnectionString(dataSource, initialCatalog, userId, password, attachDbFileName, dataDirectory);
        }

        private static string loadConfig(string assemblyPath)
        {
            string connectionString = "";
            try
            {
                string dataSource = "";
                string initialCatalog = "";
                string userId = "";
                string password = "";
                string attachDbFileName = "";
                string dataDirectory = "";
                XmlDocument xdoc = new XmlDocument();
                string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                assemblyPath = Path.Combine(directory + @"\" + assemblyPath + ".config");
                xdoc.Load(assemblyPath);
                XmlNode xnodes = xdoc.SelectSingleNode("/configuration/appSettings");

                foreach (XmlNode xnn in xnodes.ChildNodes)
                {
                    switch (xnn.Attributes[0].Value)
                    {
                        case "ConnectionString.DataSource":
                            dataSource = xnn.Attributes[1].Value;
                            break;
                        case "ConnectionString.InitialCatalog":
                            initialCatalog = xnn.Attributes[1].Value;
                            break;
                        case "ConnectionString.UserId":
                            userId = xnn.Attributes[1].Value;
                            break;
                        case "ConnectionString.Password":
                            password = xnn.Attributes[1].Value;
                            break;
                        case "ConnectionString.AttachDbFileName":
                            attachDbFileName = xnn.Attributes[1].Value;
                            break;
                        case "ConnectionString.DataDirectory":
                            dataDirectory = xnn.Attributes[1].Value;
                            break;
                    }
                }
                log.Info("Parameters Read Successfully..");
                log.Info("******************************");
                connectionString = GetConnectionString(dataSource, initialCatalog, userId,
                    password, attachDbFileName, dataDirectory);
                log.InfoFormat("ConnectionString {0} ", connectionString);
            }
            catch (Exception e)
            {
                log.Error(e.Message, e);
            }
            return connectionString;
        }

        public static string GetDatabaseName(string assemblyPath)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(assemblyPath);
            string initialCatalog = config.AppSettings.Settings["ConnectionString.InitialCatalog"].Value;

            return initialCatalog;
        }

        public static void SetupDatabase(Assembly assembly, string[] resourceNames)
        {
            // check if database is properly setup
            DatabaseManager manager = new DatabaseManager();
            foreach (string resourceName in resourceNames)
            {
                log.Info("Executing Script = " + resourceName);
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string result = reader.ReadToEnd();

                        result = ReplaceTokens(result);

                        // check if the configuration is setup
                        manager.ExecuteQuery(result, QueryMode.Script);
                    }
                }
                log.Info("Successful Executed Script " + resourceName);
            }
        }

        private static string ReplaceTokens(string result)
        {
            result = result.Replace("@CustomDatabaseName", ConfigurationManager.AppSettings["ConnectionString.InitialCatalog"]);
            if (AppDomain.CurrentDomain.GetData("BackupDirectory") != null)
                result = result.Replace("@BackupDirectory", AppDomain.CurrentDomain.GetData("BackupDirectory").ToString());
            if (AppDomain.CurrentDomain.GetData("DataDirectory") != null)
                result = result.Replace("@DataDirectory", AppDomain.CurrentDomain.GetData("DataDirectory").ToString());

            return result;
        }

        public static void ExecuteScript(Assembly assembly, string embeddedResource)
        {
            string[] resources = new string[] { embeddedResource };
            SetupDatabase(assembly, resources);
        }
    }
}
