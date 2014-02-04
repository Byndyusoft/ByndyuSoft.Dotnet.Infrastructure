namespace Infrastructure.Dapper.Tests.CRUD
{
    using ByndyuSoft.Infrastructure.Domain.Criteria;

    using Dto;

    using NUnit.Framework;

    public class Insert : InMemoryTestFixtureBase
    {
        [Test]
        public void InsertAndFetchNewId()
        {
            var product = new Product { Name = "New Product" };

            QueryBuilder.For<Product>().With(new InsertEntity<Product>(product));

            Assert.AreNotEqual(0, product.Id);
        }
    }
}