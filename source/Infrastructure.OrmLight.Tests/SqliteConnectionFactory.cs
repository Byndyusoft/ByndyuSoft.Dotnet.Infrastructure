namespace Infrastructure.OrmLight.Tests
{
    using System.Data;
    using System.Data.SQLite;

    public static class SqliteConnectionFactory
    {
        public static IDbConnection Create()
        {
            IDbConnection dbConnection = new SQLiteConnection("Data Source=:memory:;pooling = true;");

            dbConnection.Open();

            return dbConnection;
        }
    }
}