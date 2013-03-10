namespace Infrastructure.Dapper.Tests.CRUD
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using ByndyuSoft.Infrastructure.Dapper;
    using Dto;
    using NUnit.Framework;
    using QueryObject;

    public class Select : InMemoryTestFixtureBase
    {
        [Test]
        public void SelectProductDtoById()
        {
            using (IDbConnection dbConnection = new SqliteConnectionFactory().Create())
            {
                var product1 = new ProductDto {Name = "Product #1"};
                dbConnection.Execute(new InsertProduct().Query(product1));

                QueryObject byId = new SelectProduct().ById(1);
                ProductDto productDto = dbConnection.Query<ProductDto>(byId).SingleOrDefault();

                Assert.AreEqual(1, productDto.Id);
                Assert.AreEqual("Product #1", productDto.Name);
            }
        }

        [Test]
        public void SelectAllProductsDto()
        {
            using (IDbConnection dbConnection = new SqliteConnectionFactory().Create())
            {
                var product1 = new ProductDto {Name = "Product #1"};
                dbConnection.Execute(new InsertProduct().Query(product1));

                var product2 = new ProductDto {Name = "Product #2"};
                dbConnection.Execute(new InsertProduct().Query(product2));

                var product3 = new ProductDto {Name = "Product #3"};
                dbConnection.Execute(new InsertProduct().Query(product3));

                QueryObject all = new SelectProduct().All();

                IEnumerable<ProductDto> productDtos = dbConnection.Query<ProductDto>(all);

                Assert.AreEqual(3, productDtos.Count());
            }
        }
    }
}