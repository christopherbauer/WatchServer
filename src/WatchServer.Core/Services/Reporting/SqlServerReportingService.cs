using System;
using WatchServer.Core.Repositories;

namespace WatchServer.Core.Services.Reporting
{
    public class SqlServerReportingService : ReportingServiceBase
    {
        //This is used to warn that an environment may not be reporting the correct server ID
        private string _machineName;

        private readonly IMachineIdentificationService _machineIdentificationService;
        private readonly IWatchServerRepository _watchServerRepository;

        public SqlServerReportingService(IMachineIdentificationService machineIdentificationService, IDateTimeService dateTimeService, IWatchServerRepository watchServerRepository) : base(dateTimeService)
        {
            _machineIdentificationService = machineIdentificationService;
            _watchServerRepository = watchServerRepository;
            Initialize();
        }

        private void Initialize()
        {
            _machineName = _machineIdentificationService.GetMachineName();
            if (!VerifyServerId())
            {
                RegisterServer();
            }
        }

        private void RegisterServer()
        {
            _watchServerRepository.ServerInsertUpdate(Convert.ToInt32(_machineIdentificationService.GetServerID()), _machineName);
        }


        private bool VerifyServerId()
        {
            return _watchServerRepository.ServerGet(_machineIdentificationService.GetServerID()) != null;
        }


        public override void TransmitReports()
        {
            var reports = ExtractReports();
            _watchServerRepository.ServerLogInsert(reports, Convert.ToInt32(_machineIdentificationService.GetServerID()));
        }
    }
}