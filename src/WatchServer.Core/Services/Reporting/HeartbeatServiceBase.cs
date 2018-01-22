using System;
using System.Threading;
using WatchServer.Core.Services.Configuration;

namespace WatchServer.Core.Services.Reporting
{
    public abstract class HeartbeatServiceBase : IHeartbeatService
    {
        protected readonly IReportingService ReportingService;
        protected readonly IConfigurationService _configurationService;
        protected Timer _timer;

        protected HeartbeatServiceBase(IConfigurationService configurationService, IReportingService reportingService)
        {
            ReportingService = reportingService;
            _configurationService = configurationService;
        }

        public abstract void WriteMetric();

        public virtual void StartCollecting()
        {
            var dueTime = (int)TimeSpan.FromSeconds(_configurationService.GetSetting<int>("WriteMetricSeconds")).TotalMilliseconds;
            _timer = new Timer(state => WriteMetric(), null, 0, dueTime);
        }

        public virtual void StopCollecting()
        {
            _timer.Dispose();
            _timer = null;
        }
    }
}