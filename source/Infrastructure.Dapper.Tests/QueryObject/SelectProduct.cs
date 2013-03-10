namespace Infrastructure.Dapper.Tests.QueryObject
{
    using ByndyuSoft.Infrastructure.Dapper;

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
            return new QueryObject(All().Sql + @" where p.Product_Id = @Id", new {Id = productId});
        }
    }
}