namespace Mvc4Sample.Infrastructure.OrmLite
{
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    public static class ConnectionFactory
    {
        public static IDbConnection Open()
        {
            IDbConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString);

            dbConnection.Open();

            return dbConnection;
        }
    }
}