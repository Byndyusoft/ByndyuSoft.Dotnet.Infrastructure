namespace Infrastructure.OrmLight.Tests
{
    using System.Data;
    using Dto;
    using NUnit.Framework;
    using ServiceStack.OrmLite;
    using ServiceStack.OrmLite.Sqlite;

    public class InMemoryTestFixtureBase
    {
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            OrmLiteConfig.DialectProvider = new SqliteOrmLiteDialectProvider();
        }

        [SetUp]
        public void Setup()
        {
            using (IDbConnection dbConnection = SqliteConnectionFactory.Create())
            {
                dbConnection.CreateTable<ProductDto>();
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (IDbConnection dbConnection = SqliteConnectionFactory.Create())
            {
                dbConnection.DeleteAll<ProductDto>();
                dbConnection.DropTable<ProductDto>();
            }
        }
    }
}