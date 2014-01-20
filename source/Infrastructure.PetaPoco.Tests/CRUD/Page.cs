namespace Infrastructure.PetaPoco.Tests.CRUD
{
    using System.Linq;
    using Dto;
    using NUnit.Framework;
    using global::PetaPoco;

    public class Page : InMemoryTestFixtureBase
    {
        [Test]
        public void LessElementsThanPageSize()
        {
            using (var db = new Database(DbConnection))
            {
                var result = db.Page<ProductDto>(1, 20, "SELECT * FROM Product ORDER BY Name DESC");

                Assert.AreEqual(3, result.Items.Count);
            }
        }

        [Test]
        public void SecondPageSize()
        {
            using (var db = new Database(DbConnection))
            {
                var result = db.Page<ProductDto>(2, 1, "SELECT * FROM Product ORDER BY Name DESC");

                Assert.AreEqual(1, result.Items.Count);
                Assert.AreEqual(SecondProductName, result.Items.First().Name);
            }
        }

        [Test]
        public void NonExistingPage()
        {
            using (var db = new Database(DbConnection))
            {
                var result = db.Page<ProductDto>(4, 1, "SELECT * FROM Product ORDER BY Name DESC");

                Assert.AreEqual(0, result.Items.Count);
            }
        }
    }
}