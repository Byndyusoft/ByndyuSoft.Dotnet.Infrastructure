namespace Mvc4Sample.Infrastructure.OrmLite.Staff.Commands
{
    using ByndyuSoft.Infrastructure.Domain.Commands;
    using Domain.Entities;
    using Dtos;
    using ServiceStack.OrmLite;
    using ServiceStack.OrmLite.SqlServer;
    using Web.Application.Staff.Commands.Contexts;

    public class CreateStaffCommand : ICommand<CreateStaffCommandContext>
    {
        public void Execute(CreateStaffCommandContext commandContext)
        {
            OrmLiteConfig.DialectProvider = new SqlServerOrmLiteDialectProvider();

            using (var connection = ConnectionFactory.Open())
            {
                var staff = new Staff(commandContext.Form.Name, commandContext.Form.Quantity);

                connection.InsertOnly(new StaffDto {NAME = staff.Name, QUANTITY = staff.Quantity, CREATED_AT = staff.CreatedAt}, ev => ev.Insert(p => new {p.NAME, p.QUANTITY, p.CREATED_AT}));
            }
        }
    }
}