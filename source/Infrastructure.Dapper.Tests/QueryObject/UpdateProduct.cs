namespace Infrastructure.Dapper.Tests.QueryObject
{
    using ByndyuSoft.Infrastructure.Dapper;
    using ByndyuSoft.Infrastructure.Domain.Criteria;

    using Infrastructure.Dapper.Tests.Dto;

    public class UpdateProduct
    {
        public QueryObject NameForAllProducts(string newName)
        {
            return new QueryObject(@"update Product
                                     set Name = @Name", new { Name = newName });
        }
    }

    public class UpdateNameForAllProductsQuery : DbConnectionQueryBase<UpdateEntity<Product>, bool>
    {
        public UpdateNameForAllProductsQuery(IConnectionProvider connectionProvider)
            : base(connectionProvider)
        {
        }

        public override bool Ask(UpdateEntity<Product> criterion)
        {
            return Connection.Execute(new UpdateProduct().NameForAllProducts(criterion.Entity.Name)) > 0;
        }
    }
}