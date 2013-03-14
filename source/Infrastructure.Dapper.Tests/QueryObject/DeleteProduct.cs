namespace Infrastructure.Dapper.Tests.QueryObject
{
    using ByndyuSoft.Infrastructure.Dapper;
    using ByndyuSoft.Infrastructure.Dapper.Criteria;
    using ByndyuSoft.Infrastructure.Domain;

    public class DeleteAllProductsQuery : DbConnectionQueryBase<RemoveEntity, bool>
    {
        public DeleteAllProductsQuery(IConnectionProvider connectionProvider)
            : base(connectionProvider)
        {
        }

        public override bool Ask(RemoveEntity criterion)
        {
            return Connection.Execute(new DeleteProduct()) > 0;
        }
    }

    public class DeleteProduct : QueryObject, ICriterion
    {
        public DeleteProduct()
            : base(@"delete from Product")
        {
        }
    }
}