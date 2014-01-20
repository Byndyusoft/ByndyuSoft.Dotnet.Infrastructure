namespace Infrastructure.OrmLight.Tests.Dto
{
    using ServiceStack.DataAnnotations;

    public class ProductDto
    {
        [AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}