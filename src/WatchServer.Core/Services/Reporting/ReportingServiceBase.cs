using System.Collections.Generic;

namespace WatchServer.Core.Services.Reporting
{
    public abstract class ReportingServiceBase : IReportingService
    {
        private static readonly object lockObject = new object();
        protected readonly IDateTimeService DateTimeService;

        protected ReportingServiceBase(IDateTimeService dateTimeService)
        {
            DateTimeService = dateTimeService;
        }

        public IDictionary<MetricInfo, object> Reports { get; } = new Dictionary<MetricInfo, object>();

        public void WriteMetric<T>(MetricCode code, T value) {
            lock (lockObject)
            {
                Reports.Add(new MetricInfo(code, DateTimeService.GetCurrentUTCDate()), value);
            }
        }

        public IDictionary<MetricInfo, object> ExtractReports()
        {
            lock (lockObject)
            {
                var extractedReports = new Dictionary<MetricInfo, object>(Reports);
                Reports.Clear();
                return extractedReports;
            }
        }

        public abstract void TransmitReports();
    }
}