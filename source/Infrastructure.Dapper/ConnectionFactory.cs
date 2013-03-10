namespace ByndyuSoft.Infrastructure.Dapper
{
    using System.Configuration;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using StackExchange.Profiling;
    using StackExchange.Profiling.Data;

    /// <summary>
    ///     Create <see cref="IDbConnection" /> with <see cref="MiniProfiler" />
    /// </summary>
    public class ConnectionFactory : IConnectionFactory
    {
        public IDbConnection Create()
        {
            var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString);

            DbConnection dbConnection = MiniProfiler.Current == null
                                            ? (DbConnection) sqlConnection
                                            : new ProfiledDbConnection(sqlConnection, MiniProfiler.Current);

            dbConnection.Open();

            return dbConnection;
        }
    }
}