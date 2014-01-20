namespace Infrastructure.SQLinq.Dapper.Tests
{
    using System.Data;
    using System.Data.SQLite;
    using ByndyuSoft.Infrastructure.Dapper;

    public class SqliteConnectionFactory : IConnectionFactory
    {
        public IDbConnection Create()
        {
            IDbConnection dbConnection = new SQLiteConnection("Data Source=:memory:;pooling = true;");

            dbConnection.Open();

            return dbConnection;
        }
    }
}