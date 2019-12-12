using System;
using System.Collections.Generic;
using System.IO;
using JavaToCSharp.Library;

namespace JavaToCSharp
{
    public class ConfigurationEnvironment
    {
        private static IDictionary<String, ConfigurationEnvironment> domainInstanceMap;

        private JavaProperties javaProperties = new JavaProperties();

        static ConfigurationEnvironment()
        {
            domainInstanceMap = new Dictionary<String, ConfigurationEnvironment>();
        }

        public static ConfigurationEnvironment GetInstance(String domainName)
        {

            if (domainInstanceMap.ContainsKey(domainName))
                return domainInstanceMap[domainName];

            ConfigurationEnvironment _instance = ReadConfigurationFile(domainName);
            domainInstanceMap[domainName] = _instance;
            return _instance;
        }

        /// <summary>
        /// Reads the configuration file from the Domain root
        /// </summary>
        /// <param name="domainName"></param>
        /// <returns></returns>
        private static ConfigurationEnvironment ReadConfigurationFile(String domainName)
        {
            ConfigurationEnvironment _instance = new ConfigurationEnvironment();
            if (!File.Exists(domainName))
                throw new ArgumentException("Invalid Domain Name specified. " + domainName);
            FileStream fileStream = new FileStream(domainName, FileMode.Open, FileAccess.Read);
            _instance.javaProperties.Load(fileStream);
            fileStream.Close();

            return _instance;
        }

        public String GetProperty(String propertyName)
        {
            return javaProperties.GetProperty(propertyName);
        }

        public String GetProperty(String propertyName, String defaultValue)
        {
            return javaProperties.GetProperty(propertyName, defaultValue);
        }

        public bool GetBooleanProperty(String propertyName)
        {
            bool result = false;
            bool success = Boolean.TryParse(javaProperties.GetProperty(propertyName), out result);
            if (success)
                return result;

            throw new ArgumentException("Property Name = " + propertyName + " is not a boolean value.");
        }
    }
}
