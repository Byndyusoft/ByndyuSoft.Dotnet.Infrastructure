namespace Infrastructure.SQLinq.Dapper.Tests.CRUD
{
    using System.Data;
    using System.Linq;
    using Dto;
    using NUnit.Framework;
    using global::SQLinq;
    using global::SQLinq.Dapper;

    public class Select : InMemoryTestFixtureBase
    {
        [Test]
        public void SelectProductDtoById()
        {
            using (IDbConnection dbConnection = new SqliteConnectionFactory().Create())
            {
                var query = new SQLinq<ProductDto>()
                    .Where(x => x.Product_Id == 1);

                var firstProduct = dbConnection.Query(query).First();

                Assert.AreEqual(FirstProductName, firstProduct.Name);
            }
        }

        [Test]
        public void SelectAllProductsDto()
        {
            using (IDbConnection dbConnection = new SqliteConnectionFactory().Create())
            {
                var query = new SQLinq<ProductDto>();

                Assert.AreEqual(3, dbConnection.Query(query).Count());
            }
        }

        [Test]
        public void SelectWithEndsWith()
        {
            using (IDbConnection dbConnection = new SqliteConnectionFactory().Create())
            {
                var query = new SQLinq<ProductDto>()
                    .Where(x => x.Name.EndsWith(ThirdProductName));

                Assert.AreEqual(1, dbConnection.Query(query).Count());
            }
        }
    }
}