namespace WatchServer.Core.Services.Configuration
{
    public interface IConfigurationService
    {
        string GetSetting(string key);
        string GetConnectionString(string key);
        T GetSetting<T>(string key);
    }
}