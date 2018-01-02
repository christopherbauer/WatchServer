using System;
using System.Threading;

namespace WatchServer.Core.Services.Reporting
{
    public class ConsoleReportingService : ReportingServiceBase
    {
        private Timer transmitTimer;

        public ConsoleReportingService(IDateTimeService dateTimeService) : base(dateTimeService)
        {
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