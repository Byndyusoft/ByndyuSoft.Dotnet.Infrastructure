namespace Infrastructure.Dapper.Tests.QueryObject
{
    using ByndyuSoft.Infrastructure.Dapper;
    using ByndyuSoft.Infrastructure.Domain;

    public class DropProductTableQuery : DbConnectionQueryBase<DropProductTable, bool>
    {
        public DropProductTableQuery(IConnectionProvider connectionProvider)
            : base(connectionProvider)
        {
        }

        public override bool Ask(DropProductTable criterion)
        {
            return Connection.Execute(criterion) > 0;
        }
    }

    public class DropProductTable : QueryObject, ICriterion
    {
        public DropProductTable()
            : base(@"drop table Product")
        {

        }

    }
}