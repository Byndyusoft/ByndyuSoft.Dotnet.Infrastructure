namespace Infrastructure.Dapper.Tests.QueryObject
{
    using ByndyuSoft.Infrastructure.Dapper;

    public class UpdateProduct
    {
        public QueryObject NameForAllProducts(string newName)
        {
            return new QueryObject(@"update Product
                                     set Name = @Name", new {Name = newName});
        }
    }
}