using System;
using WatchServer.Core.Services.Configuration;

namespace WatchServer.Core.Services
{
    public class MachineIdentificationService : IMachineIdentificationService
    {
        private readonly IConfigurationService _configurationService;

        public MachineIdentificationService(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public string GetMachineName()
        {
            return Environment.MachineName;
        }

        public string GetServerID()
        {
            return _configurationService.GetSetting("ServerID");
        }
    }
}