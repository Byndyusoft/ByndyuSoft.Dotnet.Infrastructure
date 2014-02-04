namespace Infrastructure.Dapper.Tests.CRUD
{
    using ByndyuSoft.Infrastructure.Domain.Criteria;

    using Infrastructure.Dapper.Tests.Dto;

    using NUnit.Framework;

    public class Delete : InMemoryTestFixtureBase
    {
        [Test]
        public void DeleteProductById()
        {
            var product = new Product { Name = "New Product" };

            QueryBuilder.For<Product>().With(new InsertEntity<Product>(product));

            var isDeleted = QueryBuilder.For<bool>().With(new DeleteEntity<Product>(product));

            Assert.True(isDeleted);
            Assert.False(QueryBuilder.For<bool>().With(new DeleteEntity<Product>(product)));
        }
    }
}