namespace Infrastructure.PetaPoco.Tests.Dto
{
    using global::PetaPoco;

    [TableName("Product")]
    [PrimaryKey("Id")]
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}