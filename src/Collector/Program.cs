using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WatchServer.Core;
using WatchServer.Core.Repositories;
using WatchServer.Core.Services;
using WatchServer.Core.Services.Configuration;
using WatchServer.Core.Services.Reporting;

namespace Collector
{
    using System;
    using System.Threading;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            var appSettingConfigurationService = new AppSettingConfigurationService();
            IReportingService reportingService = new SqlServerReportingService(new MachineIdentificationService(appSettingConfigurationService), new DateTimeService(), new WatchServerRepository(appSettingConfigurationService));
            ServicesToRun = new ServiceBase[]
            {
                new CPUCollectorService(new CPUHeartbeatService(reportingService))
            };
            ServiceBase.Run(ServicesToRun);
            var transmitTimer = new Timer(state => { reportingService.ExtractReports(); }, null, TimeSpan.FromSeconds(2).Milliseconds, TimeSpan.FromSeconds(2).Milliseconds);
        }
    }
}
