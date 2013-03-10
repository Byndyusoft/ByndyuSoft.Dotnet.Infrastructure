namespace Infrastructure.Dapper.Tests.CRUD
{
    using System;
    using System.Data;
    using System.Linq;
    using ByndyuSoft.Infrastructure.Dapper;
    using Dto;
    using NUnit.Framework;
    using QueryObject;

    public class Update : InMemoryTestFixtureBase
    {
        [Test]
        public void UpdateProductName()
        {
            using (IDbConnection dbConnection = new SqliteConnectionFactory().Create())
            {
                var insertProduct = new InsertProduct();
                var product = new ProductDto {Name = "Product Name"};
                product.Id = (int) dbConnection.Query<Int64>(insertProduct.Query(product)).Single();

                var updateProduct = new UpdateProduct();
                dbConnection.Execute(updateProduct.NameForAllProducts("new name"));

                var selectProduct = new SelectProduct();
                ProductDto result = dbConnection.Query<ProductDto>(selectProduct.ById(product.Id)).Single();

                StringAssert.AreEqualIgnoringCase("new name", result.Name);
            }
        }
    }
}