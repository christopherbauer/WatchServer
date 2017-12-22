using System.Data;
using System.Data.SqlClient;
using WatchServer.Core.Extensions;

namespace WatchServer.Core.Repositories
{
    public class RepositoryBase : ISqlServerRepository
    {
        public T GetSingle<T>(SqlConnection connection, string storedProcedureName, SqlParameter[] sqlParameters) where T : new()
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = storedProcedureName;

                command.Parameters.AddRange(sqlParameters);

                using (var reader = command.ExecuteReader())
                {
                    return reader.MapToSingle<T>();
                }
            }
        }
        public void ExecNonQuery(SqlConnection connection, string storedProcedureName, SqlParameter[] sqlParameters)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = storedProcedureName;

                command.Parameters.AddRange(sqlParameters);

                command.ExecuteNonQuery();
            }
        }

    }
}