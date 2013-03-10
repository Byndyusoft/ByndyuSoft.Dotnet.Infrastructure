namespace Infrastructure.Dapper.Tests.QueryObject
{
    using ByndyuSoft.Infrastructure.Dapper;

    public class DropProductTable
    {
        public QueryObject Query()
        {
            return new QueryObject("drop table Product");
        }
    }
}