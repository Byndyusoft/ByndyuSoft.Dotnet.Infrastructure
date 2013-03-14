namespace Infrastructure.Dapper.Tests.QueryObject
{
    using ByndyuSoft.Infrastructure.Dapper;
    using ByndyuSoft.Infrastructure.Domain;

    public class CreateProductTableQuery : DbConnectionQueryBase<CreateProductTable, bool>
    {
        public CreateProductTableQuery(IConnectionProvider connectionProvider)
            : base(connectionProvider)
        {
        }

        public override bool Ask(CreateProductTable criterion)
        {
            return Connection.Execute(criterion) == 0;
        }
    }

    public class CreateProductTable : QueryObject, ICriterion
    {
        public CreateProductTable()
            : base(@"CREATE TABLE Product (
                                    Product_Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    Name varchar(255) NOT NULL)")
        {
        }
    }
}