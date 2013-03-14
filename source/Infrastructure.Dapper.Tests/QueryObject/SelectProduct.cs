namespace Infrastructure.Dapper.Tests.QueryObject
{
    using System.Collections.Generic;
    using System.Linq;

    using ByndyuSoft.Infrastructure.Dapper;
    using ByndyuSoft.Infrastructure.Domain.Criteria;

    using Infrastructure.Dapper.Tests.Dto;

    public class SelectProduct
    {
        public QueryObject All()
        {
            return new QueryObject(@"select p.Product_Id as Id,
                                            p.Name
                                     from Product p ");
        }

        public QueryObject ById(int productId)
        {
            return new QueryObject(All().Sql + @" where p.Product_Id = @Id", new { Id = productId });
        }
    }

    public class SelectAllProductsQuery : DbConnectionQueryBase<AllEntities, IEnumerable<Product>>
    {
        public SelectAllProductsQuery(IConnectionProvider connectionProvider)
            : base(connectionProvider)
        {
        }

        public override IEnumerable<Product> Ask(AllEntities criterion)
        {
            return Connection.Query<Product>(new SelectProduct().All());
        }
    }

    public class SelectProductByIdQuery : DbConnectionQueryBase<FindById, Product>
    {
        public SelectProductByIdQuery(IConnectionProvider connectionProvider)
            : base(connectionProvider)
        {
        }

        public override Product Ask(FindById criterion)
        {
            return Connection.Query<Product>(new SelectProduct().ById(criterion.Id)).SingleOrDefault();
        }
    }
}