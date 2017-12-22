using System;
using System.Diagnostics;
using System.ServiceProcess;
using WatchServer.Core.Services.Reporting;

namespace Collector
{
    using System.Threading;

    using WatchServer.Core;

    public abstract class BaseService : ServiceBase
    {
    }

    public class CPUCollectorService : BaseService
    {
        private readonly ICPUHeartbeatService cpuHeartbeatService;

        public CPUCollectorService(ICPUHeartbeatService cpuHeartbeatService)
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
