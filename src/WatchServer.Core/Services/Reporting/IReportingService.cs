using System.Collections.Generic;

namespace WatchServer.Core.Services.Reporting
{
    public interface IReportingService {

        void WriteMetric<T>(MetricCode code, T value);

        IDictionary<MetricInfo, object> ExtractReports();
        void TransmitReports();
    }
}