using System;
using System.Diagnostics;
using System.Threading;

namespace WatchServer.Core.Services.Reporting
{
    public interface ICPUHeartbeatService
    {
        void WriteMetric();

        void StartCollecting();

        void StopCollecting();
    }

    public class CPUHeartbeatService : ICPUHeartbeatService
    {
        private readonly IReportingService _reportingService;
        readonly PerformanceCounter _cpuCounter = new PerformanceCounter();

        private Timer timer;

        public CPUHeartbeatService(IReportingService reportingService)
        {
            _reportingService = reportingService;
        }

        public void StartCollecting()
        {
            _cpuCounter.CategoryName = "Processor";
            _cpuCounter.CounterName = "% Processor Time";
            _cpuCounter.InstanceName = "_Total";
            var dueTime = (int)TimeSpan.FromSeconds(1).TotalMilliseconds;
            timer = new Timer(state => WriteMetric(), null, 0, dueTime);
        }

        public void WriteMetric()
        {
            _reportingService.WriteMetric(MetricCode.PercentCPU, _cpuCounter.NextValue());
        }

        public void StopCollecting()
        {
            timer.Dispose();
            timer = null;
        }
    }
}