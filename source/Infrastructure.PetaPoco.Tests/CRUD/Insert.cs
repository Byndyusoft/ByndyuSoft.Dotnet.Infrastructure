namespace Infrastructure.PetaPoco.Tests.CRUD
{
    using Dto;
    using NUnit.Framework;
    using global::PetaPoco;

    public class Insert : InMemoryTestFixtureBase
    {
        [Test]
        public void InsertNewProduct()
        {
            using (var db = new Database(DbConnection))
            {
                var product = new ProductDto {Name = "New Product"};

                db.Insert("Product", "Id", product);

                Assert.AreNotEqual(0, product.Id);
            }
        }

        [Test]
        public void InsertNewProductAttributesBinding()
        {
            using (var db = new Database(DbConnection))
            {
                var product = new ProductDto {Name = "New Product"};

                db.Insert(product);

                Assert.AreNotEqual(0, product.Id);
            }
        }
    }
}