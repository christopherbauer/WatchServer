using System;
using System.IO;
using System.Threading;
using WatchServer.Core.Services.Configuration;

namespace WatchServer.Core.Services.Reporting
{
    public class DiskDriveTotalUsedHeartbeatService : HeartbeatServiceBase
    {
        private DriveInfo _driveInfo;

        public DiskDriveTotalUsedHeartbeatService(IConfigurationService configurationService, IReportingService reportingService) : base(configurationService, reportingService)
        {
        }

        public override void WriteMetric()
        {
            ReportingService.WriteMetric(MetricCode.DriveUsed, (_driveInfo.TotalSize - _driveInfo.TotalFreeSpace)/ 1000000000);
        }

        public override void StartCollecting()
        {
            _driveInfo = new DriveInfo("C");

            var dueTime = (int)TimeSpan.FromMinutes(5).TotalMilliseconds;
            _timer = new Timer(state => WriteMetric(), null, 0, dueTime);
        }
    }
}