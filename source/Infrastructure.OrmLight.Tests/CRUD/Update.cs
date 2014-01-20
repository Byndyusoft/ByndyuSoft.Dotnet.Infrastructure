namespace Infrastructure.OrmLight.Tests.CRUD
{
    using System.Data;
    using Dto;
    using NUnit.Framework;
    using ServiceStack.OrmLite;

    public class Update : InMemoryTestFixtureBase
    {
        [Test]
        public void UpdateProductName()
        {
            using (IDbConnection dbConnection = SqliteConnectionFactory.Create())
            {
                var product = new ProductDto {Name = "New Product"};

                dbConnection.Insert(product);

                product.Name = "Changed name";

                dbConnection.Update(product, dto => dto.Id == 1);

                Assert.NotNull(dbConnection.Single<ProductDto>(dto => dto.Name == product.Name));
            }
        }

        [Test]
        public void UpdateProductNameWithAnonumousObject()
        {
            using (IDbConnection dbConnection = SqliteConnectionFactory.Create())
            {
                var product = new ProductDto {Name = "New Product"};

                dbConnection.Insert(product);

                product.Name = "Changed name";

                dbConnection.Update<ProductDto>(new {product.Name}, dto => dto.Id == 1);

                Assert.NotNull(dbConnection.Single<ProductDto>(dto => dto.Name == product.Name));
            }
        }

        [Test]
        public void UpdateProductByUpdateOnly()
        {
            using (IDbConnection dbConnection = SqliteConnectionFactory.Create())
            {
                var product = new ProductDto {Name = "New Product"};

                dbConnection.Insert(product);

                product.Name = "Changed name";

                dbConnection.UpdateOnly(product, dto => new {dto.Name}, dto => dto.Id == 1);

                Assert.NotNull(dbConnection.Single<ProductDto>(dto => dto.Name == product.Name));
            }
        }
    }
}