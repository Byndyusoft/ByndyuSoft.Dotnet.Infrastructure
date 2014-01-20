namespace Infrastructure.OrmLight.Tests.CRUD
{
    using System.Data;
    using Dto;
    using NUnit.Framework;
    using ServiceStack.OrmLite;

    public class Delete : InMemoryTestFixtureBase
    {
        [Test]
        public void DeleteProduct()
        {
            using (IDbConnection dbConnection = SqliteConnectionFactory.Create())
            {
                var product = new ProductDto {Name = "New Product"};

                dbConnection.Insert(product);

                dbConnection.Delete<ProductDto>(dto => dto.Id == dbConnection.LastInsertId());

                Assert.IsNull(dbConnection.SingleById<ProductDto>(1));
            }
        }
    }
}