namespace Infrastructure.PetaPoco.Tests.CRUD
{
    using System.Linq;
    using Dto;
    using NUnit.Framework;
    using global::PetaPoco;

    public class Query : InMemoryTestFixtureBase
    {
        [Test]
        public void SelectAllProductsDto()
        {
            using (var db = new Database(DbConnection))
            {
                var productDtos = db.Query<ProductDto>("SELECT Product_Id as Id, Name FROM Product");

                Assert.AreEqual(3, productDtos.Count());
            }
        }

        [Test]
        public void Single()
        {
            using (var db = new Database(DbConnection))
            {
                var productDto = db.Single<ProductDto>("SELECT Product_Id as Id, Name FROM Product WHERE Product_Id = @0", 1);

                Assert.IsNotNull(productDto);
            }
        }
    }
}