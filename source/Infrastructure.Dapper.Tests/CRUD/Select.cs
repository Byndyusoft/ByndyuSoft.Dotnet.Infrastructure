namespace Infrastructure.Dapper.Tests.CRUD
{
    using System.Collections.Generic;
    using System.Linq;

    using ByndyuSoft.Infrastructure.Domain.Criteria;

    using Dto;

    using NUnit.Framework;

    using ByndyuSoft.Infrastructure.Domain.Extensions;

    public class Select : InMemoryTestFixtureBase
    {
        [Test]
        public void SelectProductDtoById()
        {
            var product = new Product { Name = "Product #1" };

            QueryBuilder.For<Product>().With(new InsertEntity<Product>(product));

            var actualProduct = QueryBuilder.For<Product>().ById(product.Id);

            Assert.NotNull(actualProduct);
            Assert.AreEqual(1, actualProduct.Id);
            Assert.AreEqual("Product #1", actualProduct.Name);
        }

        [Test]
        public void SelectAllProductsDto()
        {
            QueryBuilder.For<Product>().With(new InsertEntity<Product>(new Product { Name = "Product #1" }));
            QueryBuilder.For<Product>().With(new InsertEntity<Product>(new Product { Name = "Product #2" }));
            QueryBuilder.For<Product>().With(new InsertEntity<Product>(new Product { Name = "Product #3" }));

            var products = QueryBuilder.For<IEnumerable<Product>>().All();

            Assert.NotNull(products);
            Assert.AreEqual(3, products.Count());
        }
    }
}