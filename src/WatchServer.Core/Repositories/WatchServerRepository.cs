using System.Collections.Generic;
using System.Data.SqlClient;
using WatchServer.Core.Models;
using WatchServer.Core.Services.Configuration;

namespace WatchServer.Core.Repositories
{
    public class WatchServerRepository : RepositoryBase, IWatchServerRepository
    {
        private readonly IConfigurationService _configurationService;

        public WatchServerRepository(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public void ServerInsertUpdate(int serverID, string _machineName)
        {
            using (var connection =
                new SqlConnection(_configurationService.GetConnectionString("WatchServerSqlConnectionString")))
            {
                connection.Open();
                ExecNonQuery(connection, "ServerInsertUpdate", new[]
                {
                    new SqlParameter("ServerID", serverID),
                    new SqlParameter("Name", _machineName),
                });
            }
        }

        public ServerModel ServerGet(string serverId)
        {
            using (var connection = new SqlConnection(_configurationService.GetConnectionString("WatchServerSqlConnectionString")))
            {
                connection.Open();
                return GetSingle<ServerModel>(connection, "ServerGet", new[]
                {
                    new SqlParameter("ServerID", serverId),
                });
            }

        }

        public void ServerLogInsert(IDictionary<MetricInfo, object> reports, int serverID)
        {
            using (var connection = new SqlConnection(_configurationService.GetConnectionString("WatchServerSqlConnectionString")))
            {
                connection.Open();
                foreach (var report in reports)
                {
                    ExecNonQuery(connection, "ServerLogInsert", new[]
                    {
                        new SqlParameter("ServerID", serverID),
                        new SqlParameter("MetricID", (int)report.Key.Code),
                        new SqlParameter("LogDate", report.Key.Time),
                        new SqlParameter("Value", report.Value),
                    });
                }

            }

        }
    }
}