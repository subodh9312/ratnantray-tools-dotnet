using System;
using System.Configuration;
using System.Diagnostics;

namespace DBManager.Utils
{
    public static class DBConfig
    {
        public static string ConnectionString { get; private set; }
        public static string LogFilePath { get; private set; }
        public static string GetAllAccessConnectionString { get; private set; }
        public static string DatabaseName { get; private set; }

        static DBConfig()
        {
            Init();
        }

        private static void Init()
        {
            LogFilePath = GetConfigurationSetting(DBConstants.LOG_FILE_PATH);

            if (String.IsNullOrEmpty(LogFilePath))
                LogFilePath = AppDomain.CurrentDomain.BaseDirectory;

            Process process = Process.GetCurrentProcess();
            string assemblyPath = System.IO.Path.GetFileName(process.MainModule.FileName);

            if (assemblyPath.Contains(".vshost"))
                assemblyPath = assemblyPath.Replace(".vshost", "");
            ConnectionString = DBUtils.GetConnectionString(assemblyPath);

            GetAllAccessConnectionString = DBUtils.GetConnectionString(assemblyPath, true);

            DatabaseName = DBUtils.GetDatabaseName(assemblyPath);
        }

        private static string GetConfigurationSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
