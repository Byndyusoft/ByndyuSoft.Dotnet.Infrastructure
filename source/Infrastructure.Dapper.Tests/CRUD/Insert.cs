namespace Infrastructure.Dapper.Tests.CRUD
{
    using System;
    using System.Data;
    using System.Linq;
    using ByndyuSoft.Infrastructure.Dapper;
    using Dto;
    using NUnit.Framework;
    using QueryObject;

    public class Insert : InMemoryTestFixtureBase
    {
        [Test]
        public void InsertAndFetchNewId()
        {
            using (IDbConnection dbConnection = new SqliteConnectionFactory().Create())
            {
                var insertProduct = new InsertProduct();
                var product = new ProductDto {Name = "New Product"};

                product.Id = (int) dbConnection.Query<Int64>(insertProduct.Query(product)).Single();

                Assert.AreNotEqual(0, product.Id);
            }
        }
    }
}