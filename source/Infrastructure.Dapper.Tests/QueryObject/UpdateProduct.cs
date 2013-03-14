namespace Infrastructure.Dapper.Tests.QueryObject
{
    using ByndyuSoft.Infrastructure.Dapper;
    using ByndyuSoft.Infrastructure.Dapper.Criteria;

    public class UpdateProduct
    {
        public QueryObject NameForCurrentProduct(object entity)
        {
            return new QueryObject(@"update Product
                                     set Name = @Name 
                                     where Product_Id = @Id", entity);
        }
    }

    public class UpdateProductNameQuery : DbConnectionQueryBase<UpdateEntity, bool>
    {
        public UpdateProductNameQuery(IConnectionProvider connectionProvider)
            : base(connectionProvider)
        {
        }

        public override bool Ask(UpdateEntity criterion)
        {
            return Connection.Execute(new UpdateProduct().NameForCurrentProduct(criterion.QueryParams)) > 0;
        }
    }
}