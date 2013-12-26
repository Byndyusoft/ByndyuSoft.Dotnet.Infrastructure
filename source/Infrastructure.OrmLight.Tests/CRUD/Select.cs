namespace Infrastructure.OrmLight.Tests.CRUD
{
    using System.Data;
    using Dto;
    using NUnit.Framework;
    using ServiceStack.OrmLite;

    public class Select : InMemoryTestFixtureBase
    {
        [Test]
        public void SelectWithLogicalExpression()
        {
            using (IDbConnection dbConnection = SqliteConnectionFactory.Create())
            {
                var product1 = new ProductDto {Name = "Product #1"};
                dbConnection.Insert(product1);

                Assert.AreEqual(0, dbConnection.Select<ProductDto>(dto => dto.Name == "Other name").Count);
                Assert.AreEqual(1, dbConnection.Select<ProductDto>(dto => dto.Name == "Product #1").Count);
            }
        }

        [Test]
        public void SelectWithInExpression()
        {
            using (IDbConnection dbConnection = SqliteConnectionFactory.Create())
            {
                var product1 = new ProductDto {Name = "Product #1"};
                dbConnection.Insert(product1);

                var product2 = new ProductDto {Name = "Product #2"};
                dbConnection.Insert(product2);

                var product3 = new ProductDto {Name = "Product #3"};
                dbConnection.Insert(product3);

                Assert.AreEqual(3, dbConnection.Select<ProductDto>(dto => Sql.In(dto.Name, "Product #1", "Product #2", "Product #3", "Other")).Count);
            }
        }

        [Test]
        public void SelectWithStartsWith()
        {
            using (IDbConnection dbConnection = SqliteConnectionFactory.Create())
            {
                var product1 = new ProductDto {Name = "Product #1"};
                dbConnection.Insert(product1);

                Assert.AreEqual(1, dbConnection.Select<ProductDto>(dto => dto.Name.StartsWith("P")).Count);
                Assert.AreEqual(0, dbConnection.Select<ProductDto>(dto => dto.Name.StartsWith("G")).Count);
            }
        }

        [Test]
        public void SelectWithEndsWith()
        {
            using (IDbConnection dbConnection = SqliteConnectionFactory.Create())
            {
                var product1 = new ProductDto {Name = "Product #1"};
                dbConnection.Insert(product1);

                Assert.AreEqual(1, dbConnection.Select<ProductDto>(dto => dto.Name.EndsWith("1")).Count);
                Assert.AreEqual(0, dbConnection.Select<ProductDto>(dto => dto.Name.EndsWith("G")).Count);
            }
        }

        [Test]
        public void SelectWithContains()
        {
            using (IDbConnection dbConnection = SqliteConnectionFactory.Create())
            {
                var product1 = new ProductDto {Name = "Product #1"};
                dbConnection.Insert(product1);

                Assert.AreEqual(1, dbConnection.Select<ProductDto>(dto => dto.Name.Contains("odu")).Count);
                Assert.AreEqual(0, dbConnection.Select<ProductDto>(dto => dto.Name.Contains("odu ")).Count);
            }
        }
    }
}