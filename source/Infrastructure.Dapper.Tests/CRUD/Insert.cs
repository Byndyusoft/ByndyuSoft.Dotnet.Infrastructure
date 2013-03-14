namespace Infrastructure.Dapper.Tests.CRUD
{
    using Dto;
    using NUnit.Framework;

    public class Insert : InMemoryTestFixtureBase
    {
        [Test]
        public void InsertAndFetchNewId()
        {
            var product = new Product { Name = "New Product" };

            DapperRepository.Add(product);

            Assert.AreNotEqual(0, product.Id);
        }
    }
}