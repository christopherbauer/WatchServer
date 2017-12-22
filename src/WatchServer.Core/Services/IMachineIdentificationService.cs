namespace WatchServer.Core.Services
{
    public interface IMachineIdentificationService
    {
        string GetMachineName();
        string GetServerID();
    }
}