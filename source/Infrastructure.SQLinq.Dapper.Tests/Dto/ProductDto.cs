namespace Infrastructure.SQLinq.Dapper.Tests.Dto
{
    using global::SQLinq;

    [SQLinqTable("Product")]
    public class ProductDto
    {
        [SQLinqColumn("Product_Id")]
        public long Product_Id { get; set; }

        public string Name { get; set; }
    }
}