namespace Infrastructure.PetaPoco.Tests.CRUD
{
    using System.Linq;
    using Dto;
    using NUnit.Framework;
    using global::PetaPoco;

    public class Delete : InMemoryTestFixtureBase
    {
        [Test]
        public void DeleteProduct()
        {
            using (var db = new Database(DbConnection))
            {
                db.Delete("Product", "Product_Id", null, 1);

                Assert.AreEqual(2, db.Query<ProductDto>("SELECT Product_Id as Id, Name FROM Product").Count());
            }
        }
    }
}