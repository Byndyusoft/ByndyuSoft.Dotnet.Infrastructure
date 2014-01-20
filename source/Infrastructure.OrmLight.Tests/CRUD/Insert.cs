namespace Infrastructure.OrmLight.Tests.CRUD
{
    using System.Data;
    using System.Linq;
    using Dto;
    using NUnit.Framework;
    using ServiceStack.OrmLite;

    public class Insert : InMemoryTestFixtureBase
    {
        [Test]
        public void InsertAndFetchNewId()
        {
            using (IDbConnection dbConnection = SqliteConnectionFactory.Create())
            {
                var product = new ProductDto {Name = "New Product"};

                dbConnection.Insert(product);

                var result = dbConnection
                    .Select<ProductDto>(p => p.Name == product.Name)
                    .First();

                Assert.AreNotEqual(0, result.Id);
            }
        }
    }
}