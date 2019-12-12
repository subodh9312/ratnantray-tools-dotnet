using System;
using System.Data.SqlClient;
using System.Reflection;
using DBManager.Library;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace DBManager
{
    public abstract class ConfigValue : IDBValue
    {
        public object RestoreObject(SqlDataReader reader)
        {
            while (reader.Read())
            {
                string parameterName = reader["ParameterName"] as string;
                string parameterValue = reader["ParameterValue"] as string;

                string propertyName = parameterName.ToTitleCase();
                if (parameterName.IndexOf("_") != -1)
                {
                    string[] parts = parameterName.Split('_');
                    propertyName = "";
                    foreach (string part in parts)
                        propertyName += part.ToTitleCase();
                    PropertyInfo info = GetType().GetProperty(propertyName);
                    info.SetValue(this, Convert.ChangeType(parameterValue, info.PropertyType), null);
                }
            }
            return this;
        }

        protected bool ModifyEntry(string parameterName, string parameterValue, string domain, 
            bool createIfNotFound = true, bool encryptValue = false)
        {
            bool success = false;

            if (String.IsNullOrEmpty(domain))
                throw new ArgumentException("DOMAIN_NAME variable must be set.");

            if (encryptValue)
                parameterValue = Encrypt(parameterValue);

            string sql = "UPDATE Configuration SET [ParameterValue] = @ParameterValue";
            sql += " WHERE [ParameterName] = @ParameterName AND [Domain] = @Domain";

            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@ParameterName", parameterName));
            parameters.Add(new SqlParameter("@ParameterValue", parameterValue));
            parameters.Add(new SqlParameter("@Domain", domain));

            DatabaseManager manager = new DatabaseManager();
            int rowsAffected = Convert.ToInt32(manager.ExecuteQuery(sql, Utils.QueryMode.Update, parameters.ToArray()));

            if (rowsAffected == 0 && createIfNotFound)
            {
                sql = "INSERT INTO [Configuration] ([ParameterName], [ParameterValue], [Domain])";
                sql += " VALUES (@ParameterName, @ParameterValue, @Domain)";
                rowsAffected = Convert.ToInt32(manager.ExecuteQuery(sql, Utils.QueryMode.Update, parameters.ToArray()));
                if (rowsAffected == 1)
                    success = true;
            }
            else if (rowsAffected == 1)
                success = true;

            return success;
        }

        protected object GetEntry(string parameterName, string domain, bool decryptValue = false)
        {
            string sql = "SELECT [ParameterValue] FROM [Configuration] ";
            sql += "WHERE [ParameterName] = @ParameterName AND [DOMAIN] = @Domain ";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ParameterName", parameterName));
            parameters.Add(new SqlParameter("@Domain", domain));

            DatabaseManager manager = new DatabaseManager();

            object parameterValue = manager.ExecuteQuery(sql, Utils.QueryMode.Scalar, parameters.ToArray());

            if (decryptValue && parameterValue != null)
                parameterValue = Decrypt(parameterValue.ToString());

            return parameterValue;
        }

        private readonly string PasswordHash = "P@@Sw0rd";
        private readonly string SaltKey = "S@LT&KEY";
        private readonly string VIKey = "@1B2c3D4e5F6g7H8";

        private string Encrypt(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }

        private string Decrypt(string encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }
    }
}
