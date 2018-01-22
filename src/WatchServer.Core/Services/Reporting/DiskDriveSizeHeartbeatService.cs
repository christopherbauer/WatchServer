using System;
using System.IO;
using System.Threading;
using WatchServer.Core.Services.Configuration;

namespace WatchServer.Core.Services.Reporting
{
    public class DiskDriveSizeHeartbeatService : HeartbeatServiceBase
    {
        private DriveInfo _driveInfo;

        public DiskDriveSizeHeartbeatService(IConfigurationService configurationService, IReportingService reportingService) : base(configurationService, reportingService)
        {
            
        }
        
        public override void WriteMetric()
        {
            ReportingService.WriteMetric(MetricCode.DriveSize, _driveInfo.TotalSize / 1000000000);
        }

        public override void StartCollecting()
        {
            _driveInfo = new DriveInfo("C");

            var dueTime = (int)TimeSpan.FromHours(12).TotalMilliseconds;
            _timer = new Timer(state => WriteMetric(), null, 0, dueTime);
        }
    }
}