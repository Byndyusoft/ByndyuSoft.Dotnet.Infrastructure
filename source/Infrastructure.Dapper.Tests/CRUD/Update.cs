namespace Infrastructure.Dapper.Tests.CRUD
{
    using Dto;

    using NUnit.Framework;

    public class Update : InMemoryTestFixtureBase
    {
        [Test]
        public void UpdateProductName()
        {
            var product = new Product { Name = "New Product" };

            DapperRepository.Add(product);
            product.Name = "new name";
            DapperRepository.AddOrUpdate(product);
            Product result = DapperRepository.Get(product.Id);

            StringAssert.AreEqualIgnoringCase("new name", result.Name);
        }
    }
}