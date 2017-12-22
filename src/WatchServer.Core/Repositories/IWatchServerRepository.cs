using System.Collections.Generic;
using WatchServer.Core.Models;

namespace WatchServer.Core.Repositories
{
    public interface IWatchServerRepository
    {
        void ServerInsertUpdate(int serverID, string _machineName);
        ServerModel ServerGet(string serverId);
        void ServerLogInsert(IDictionary<MetricInfo, object> reports, int serverID);
    }
}