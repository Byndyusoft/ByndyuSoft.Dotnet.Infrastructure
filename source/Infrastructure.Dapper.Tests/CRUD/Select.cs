namespace Infrastructure.Dapper.Tests.CRUD
{
    using System.Linq;

    using Dto;

    using NUnit.Framework;

    public class Select : InMemoryTestFixtureBase
    {
        [Test]
        public void SelectProductDtoById()
        {
            var product = new Product { Name = "Product #1" };
            DapperRepository.Add(product);

            var actualProduct = DapperRepository.Get(product.Id);

            Assert.AreEqual(1, actualProduct.Id);
            Assert.AreEqual("Product #1", actualProduct.Name);
        }

        [Test]
        public void SelectAllProductsDto()
        {
            DapperRepository.Add(new Product { Name = "Product #1" });
            DapperRepository.Add(new Product { Name = "Product #2" });
            DapperRepository.Add(new Product { Name = "Product #3" });

            var products = DapperRepository.All();

            Assert.AreEqual(3, products.Count());
        }
    }
}