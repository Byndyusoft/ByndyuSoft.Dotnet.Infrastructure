namespace Infrastructure.PetaPoco.Tests.CRUD
{
    using System.Linq;
    using Dto;
    using NUnit.Framework;
    using global::PetaPoco;

    public class Fetch : InMemoryTestFixtureBase
    {
        [Test]
        public void FetchProductDtoByName()
        {
            using (var db = new Database(DbConnection))
            {
                ProductDto productDto = db.Fetch<ProductDto>("SELECT Product_Id as Id, Name FROM Product WHERE Name=@0", FirstProductName).Single();

                Assert.AreEqual(1, productDto.Id);
                Assert.AreEqual(FirstProductName, productDto.Name);
            }
        }

        [Test]
        public void FetchAllProductsDto()
        {
            using (var db = new Database(DbConnection))
            {
                var productDtos = db.Fetch<ProductDto>("SELECT Product_Id as Id, Name FROM Product");

                Assert.AreEqual(3, productDtos.Count());
            }
        }
    }
}