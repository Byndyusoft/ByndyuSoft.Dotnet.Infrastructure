namespace Infrastructure.Dapper.Tests.QueryObject
{
    using System;
    using System.Linq;

    using ByndyuSoft.Infrastructure.Dapper;
    using ByndyuSoft.Infrastructure.Domain.Criteria;

    using Dto;

    public class InsertProductQuery : DbConnectionQueryBase<InsertEntity<Product>, Product>
    {
        public InsertProductQuery(IConnectionProvider connectionProvider)
            : base(connectionProvider)
        {
        }

        public override Product Ask(InsertEntity<Product> criterion)
        {
            var id = Connection.Query<Int64>(new InsertProduct().Query(criterion.Entity)).Single();

            var product = criterion.Entity;
            product.Id = (int)id;

            return product;
        }
    }

    public class InsertProduct
    {
        public QueryObject Query(Product product)
        {
            return new QueryObject(@"insert into Product(Name) values (@Name);
                                     SELECT last_insert_rowid();", new { product.Name });
        }
    }
}