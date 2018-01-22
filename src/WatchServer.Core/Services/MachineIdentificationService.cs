using System;
using WatchServer.Core.Services.Configuration;

namespace WatchServer.Core.Services
{
    public class MachineIdentificationService : IMachineIdentificationService
    {
        private readonly IConfigurationService _configurationService;
        private string _machineName;

        public MachineIdentificationService(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public string GetMachineName()
        {
            if (string.IsNullOrEmpty(_machineName))
            {
                _machineName = Environment.MachineName;
            }
            return _machineName;
        }

        private string _serverId;
        public string GetServerID()
        {
            if (string.IsNullOrEmpty(_serverId))
            {
                _serverId = _configurationService.GetSetting("ServerID");
            }
            return _serverId;
        }
    }
}