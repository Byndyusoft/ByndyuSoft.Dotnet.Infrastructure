namespace Infrastructure.Dapper.Tests
{
    using System.Data;
    using ByndyuSoft.Infrastructure.Dapper;
    using NUnit.Framework;
    using QueryObject;

    public class InMemoryTestFixtureBase
    {
        [SetUp]
        public void Setup()
        {
            using (IDbConnection dbConnection = new SqliteConnectionFactory().Create())
            {
                var createProduct = new CreateProductTable();
                dbConnection.Execute(createProduct.Query());
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (IDbConnection dbConnection = new SqliteConnectionFactory().Create())
            {
                var createProduct = new DeleteProduct();
                dbConnection.Execute(createProduct.All());

                var dropProductTable = new DropProductTable();
                dbConnection.Execute(dropProductTable.Query());
            }
        }
    }
}