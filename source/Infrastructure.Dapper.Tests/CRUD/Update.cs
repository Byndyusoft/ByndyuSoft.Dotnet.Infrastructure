namespace Infrastructure.Dapper.Tests.CRUD
{
    using ByndyuSoft.Infrastructure.Domain.Criteria;
    using ByndyuSoft.Infrastructure.Domain.Extensions;

    using Dto;

    using NUnit.Framework;

    public class Update : InMemoryTestFixtureBase
    {
        [Test]
        public void UpdateProductName()
        {
            var product = new Product { Name = "New Product" };

            QueryBuilder.For<Product>().With(new InsertEntity<Product>(product));

            product.Name = "new name";
            QueryBuilder.For<bool>().With(new UpdateEntity<Product>(product));

            Product result = QueryBuilder.For<Product>().ById(product.Id);

            StringAssert.AreEqualIgnoringCase("new name", result.Name);
        }
    }
}