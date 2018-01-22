using System;
using System.Configuration;

namespace WatchServer.Core.Services.Configuration
{
    public class AppSettingConfigurationService : IConfigurationService
    {
        public string GetSetting(string key)
        {
            var appSettings = ConfigurationManager.AppSettings;
            if (appSettings.Count == 0)
            {
                throw new ConfigurationException("No app settings!");
            }

            return appSettings[key];
        }

        public string GetConnectionString(string key)
        {
            var connectionStrings = ConfigurationManager.ConnectionStrings;
            if (connectionStrings.Count == 0)
            {
                throw new ConfigurationException("No connection strings!");
            }

            return connectionStrings[key].ConnectionString;
        }

        public T GetSetting<T>(string key)
        {
            var appSettings = ConfigurationManager.AppSettings;
            if (appSettings.Count == 0)
            {
                throw new ConfigurationException("No app settings!");
            }

            return (T)Convert.ChangeType(appSettings[key], typeof(T));

        }
    }
}