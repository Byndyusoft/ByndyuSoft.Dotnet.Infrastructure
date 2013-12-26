namespace Infrastructure.SQLinq.Dapper.Tests
{
    using System.Data;
    using ByndyuSoft.Infrastructure.Dapper;
    using Dto;
    using NUnit.Framework;
    using QueryObject;

    public class InMemoryTestFixtureBase
    {
        private readonly ProductDto _product = new ProductDto();

        protected const string FirstProductName = "Product #1";
        protected const string SecondProductName = "Product #2";
        protected const string ThirdProductName = "Product #3";

        [SetUp]
        public void Setup()
        {
            using (IDbConnection dbConnection = new SqliteConnectionFactory().Create())
            {
                var createProduct = new CreateProductTable();
                dbConnection.Execute(createProduct.Query());

                InsertProductWithName(dbConnection, FirstProductName);

                InsertProductWithName(dbConnection, SecondProductName);

                InsertProductWithName(dbConnection, ThirdProductName);
            }
        }

        protected void InsertProductWithName(IDbConnection dbConnection, string newName)
        {
            _product.Name = newName;

            dbConnection.Execute(new InsertProduct().Query(_product));
        }

        [TearDown]
        public void TearDown()
        {
            using (IDbConnection dbConnection = new SqliteConnectionFactory().Create())
            {
                var dropProductTable = new DropProductTable();
                dbConnection.Execute(dropProductTable.Query());
            }
        }
    }
}