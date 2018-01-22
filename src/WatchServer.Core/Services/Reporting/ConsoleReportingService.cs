using System;
using System.Threading;
using WatchServer.Core.Services.Configuration;

namespace WatchServer.Core.Services.Reporting
{
    public class ConsoleReportingService : ReportingServiceBase
    {
        private readonly IConfigurationService _configurationService;
        private Timer _transmitTimer;

        public ConsoleReportingService(IDateTimeService dateTimeService, IConfigurationService configurationService) : base(dateTimeService)
        {
            _configurationService = configurationService;
            Initialize();
        }

        private void Initialize()
        {
            _transmitTimer = new Timer(state => { TransmitReports(); }, null, 0, (int)TimeSpan.FromSeconds(_configurationService.GetSetting<int>("TransmitSeconds")).TotalMilliseconds);
        }

        public override void TransmitReports()
        {
            var reports = ExtractReports();
            foreach (var report in reports)
            {
                Console.WriteLine("{0:yyyy MMMM dd HH:mm:ss} {1} {2}", report.Key.Time, report.Key.Code, report.Value);
            }
        }
    }
}