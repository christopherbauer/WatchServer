using System.Data.SqlClient;

namespace WatchServer.Core.Repositories
{
    public interface ISqlServerRepository
    {
        T GetSingle<T>(SqlConnection connection, string storedProcedureName, SqlParameter[] sqlParameters) where T : new();
        void ExecNonQuery(SqlConnection connection, string storedProcedureName, SqlParameter[] sqlParameters);
    }
}