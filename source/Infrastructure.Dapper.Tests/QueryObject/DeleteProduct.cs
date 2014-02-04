namespace Infrastructure.Dapper.Tests.QueryObject
{
    using ByndyuSoft.Infrastructure.Dapper;
    using ByndyuSoft.Infrastructure.Domain.Criteria;

    using Infrastructure.Dapper.Tests.Dto;

    public class DeleteProductQuery : DbConnectionQueryBase<DeleteEntity<Product>, bool>
    {
        public DeleteProductQuery(IConnectionProvider connectionProvider)
            : base(connectionProvider)
        {
        }

        public override bool Ask(DeleteEntity<Product> criterion)
        {
            return Connection.Execute(new DeleteProduct().ById(criterion.Entity.Id)) > 0;
        }
    }

    public class DeleteProduct
    {
        public QueryObject All()
        {
            return new QueryObject("delete from Product");
        }

        public QueryObject ById(int productId)
        {
            return new QueryObject("delete from Product where Product.Product_Id = @Id", new { Id = productId });
        }
    }
}