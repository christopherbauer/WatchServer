using System.Diagnostics;
using WatchServer.Core.Services.Configuration;

namespace WatchServer.Core.Services.Reporting
{
    public class CPUHeartbeatService : HeartbeatServiceBase
    {
        readonly PerformanceCounter _cpuCounter = new PerformanceCounter();

        public CPUHeartbeatService(IConfigurationService configurationService, IReportingService reportingService) : base(configurationService, reportingService)
        {
        }

        public override void StartCollecting()
        {
            _cpuCounter.CategoryName = "Processor";
            _cpuCounter.CounterName = "% Processor Time";
            _cpuCounter.InstanceName = "_Total";
            base.StartCollecting();
        }

        public override void WriteMetric()
        {
            ReportingService.WriteMetric(MetricCode.PercentCPU, _cpuCounter.NextValue());
        }
    }
}