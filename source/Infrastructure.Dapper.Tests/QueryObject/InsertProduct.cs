namespace Infrastructure.Dapper.Tests.QueryObject
{
    using System;
    using System.Linq;

    using ByndyuSoft.Infrastructure.Dapper;
    using ByndyuSoft.Infrastructure.Dapper.Criteria;
    using ByndyuSoft.Infrastructure.Domain;

    using Dto;

    public class InsertProductQuery : DbConnectionQueryBase<InsertEntity, Product>
    {
        public InsertProductQuery(IConnectionProvider connectionProvider)
            : base(connectionProvider)
        {
        }

        public override Product Ask(InsertEntity criterion)
        {
            var id = Connection.Query<Int64>(new InsertProduct(criterion.QueryParams)).Single();

            var product = criterion.QueryParams as Product;
            product.Id = (int)id;

            return product;
        }
    }

    public class InsertProduct : QueryObject, ICriterion
    {
        public InsertProduct(object queryParams)
            : base(@"insert into Product(Name) values (@Name);
                     SELECT last_insert_rowid();", queryParams)
        {

        }

    }
}