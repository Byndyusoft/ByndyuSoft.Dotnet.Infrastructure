namespace Infrastructure.PetaPoco.Tests
{
    using System.Data;
    using System.Data.SQLite;
    using Dto;
    using NUnit.Framework;
    using global::PetaPoco;

    public class InMemoryTestFixtureBase
    {
        protected readonly IDbConnection DbConnection = new SQLiteConnection("Data Source=:memory:;pooling = true;");

        private readonly ProductDto _product = new ProductDto();

        protected const string FirstProductName = "Product #1";
        protected const string SecondProductName = "Product #2";
        protected const string ThirdProductName = "Product #3";

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            DbConnection.Open();
        }

        [SetUp]
        public void Setup()
        {
            using (var db = new Database(DbConnection))
            {
                db.Execute(@"CREATE TABLE Product (
                                    Product_Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    Name varchar(255) NOT NULL)");

                InsertProductWithName(db, FirstProductName);

                InsertProductWithName(db, SecondProductName);

                InsertProductWithName(db, ThirdProductName);
            }
        }

        protected void InsertProductWithName(Database db, string newName)
        {
            _product.Name = newName;

            db.Insert("Product", "Id", _product);
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new Database(DbConnection))
            {
                db.Execute(@"DROP TABLE Product");
            }
        }
    }
}