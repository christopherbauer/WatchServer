namespace WatchServer.Core.Services.Reporting
{
    public interface IHeartbeatService
    {
        void WriteMetric();

        void StartCollecting();

        void StopCollecting();
    }
}