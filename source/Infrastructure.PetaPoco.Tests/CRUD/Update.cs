namespace Infrastructure.PetaPoco.Tests.CRUD
{
    using Dto;
    using NUnit.Framework;
    using global::PetaPoco;

    public class Update : InMemoryTestFixtureBase
    {
        private const string ChangedName = "Changed name";

        [Test]
        public void UpdateProductName()
        {
            using (var db = new Database(DbConnection))
            {
                db.Update<ProductDto>("SET Name=@0 WHERE Name=@1", ChangedName, SecondProductName);

                var secondProduct = db.Single<ProductDto>("SELECT Product_Id as Id, Name FROM Product WHERE Product_Id = @0", 2);

                Assert.AreEqual(ChangedName, secondProduct.Name);
            }
        }
    }
}