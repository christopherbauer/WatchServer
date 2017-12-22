using System;
using WatchServer.Core.Repositories;
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
            IReportingService reportingService = new SqlServerReportingService(new MachineIdentificationService(appSettingConfigurationService), new DateTimeService(), new WatchServerRepository(appSettingConfigurationService));
            ICPUHeartbeatService heartbeatService = new CPUHeartbeatService(reportingService);
            heartbeatService.StartCollecting();
            var transmitTimer = new Timer(state => { reportingService.TransmitReports(); }, null, 0, (int) TimeSpan.FromSeconds(5).TotalMilliseconds);

            Console.ReadLine();
            Console.WriteLine(transmitTimer.ToString());
        }
    }
}
