namespace Infrastructure.Dapper.Tests.QueryObject
{
    using ByndyuSoft.Infrastructure.Dapper;

    public class DeleteProduct
    {
        public QueryObject All()
        {
            return new QueryObject("delete from Product");
        }
    }
}