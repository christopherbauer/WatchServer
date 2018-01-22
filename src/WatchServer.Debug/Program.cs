using System;
using WatchServer.Core.Services;
using WatchServer.Core.Services.Configuration;
using WatchServer.Core.Services.Reporting;
using System.Threading;

namespace WatchServer.Debug
{
    class Program
    {
        private static Timer transmitTimer;

        static void Main(string[] args)
        {
            var appSettingConfigurationService = new AppSettingConfigurationService();
            IReportingService reportingService = new ConsoleReportingService(new DateTimeService(), appSettingConfigurationService);
            IHeartbeatService cpuHeartbeatService = new CPUHeartbeatService(appSettingConfigurationService, reportingService);
            IHeartbeatService driveTotalUsedHeartbeatService = new DiskDriveTotalUsedHeartbeatService(appSettingConfigurationService, reportingService);
            IHeartbeatService driveSizeHeartbeatService = new DiskDriveSizeHeartbeatService(appSettingConfigurationService, reportingService);
            cpuHeartbeatService.StartCollecting();
            driveTotalUsedHeartbeatService.StartCollecting();
            driveSizeHeartbeatService.StartCollecting();

            Console.ReadLine();
        }
    }
}
