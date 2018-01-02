using System.ServiceProcess;
using WatchServer.Core.Services.Reporting;

namespace Collector
{
    public abstract class BaseService : ServiceBase
    {
    }

    public class CPUCollectorService : BaseService
    {
        private readonly IHeartbeatService cpuHeartbeatService;

        public CPUCollectorService(IHeartbeatService cpuHeartbeatService)
        {
            this.cpuHeartbeatService = cpuHeartbeatService;
        }

        protected override void OnStart(string[] args)
        {
            this.cpuHeartbeatService.StartCollecting();
        }

        protected override void OnStop()
        {
            this.cpuHeartbeatService.StopCollecting();
        }
    }
}
