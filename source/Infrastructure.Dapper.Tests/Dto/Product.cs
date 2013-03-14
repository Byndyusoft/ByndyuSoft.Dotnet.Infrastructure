namespace Infrastructure.Dapper.Tests.Dto
{
    using ByndyuSoft.Infrastructure.Domain;

    public class Product: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}