namespace Mvc4Sample.Infrastructure.OrmLite.Staff.Commands
{
    using ByndyuSoft.Infrastructure.Dapper;
    using ByndyuSoft.Infrastructure.Domain.Commands;
    using Domain.Entities;
    using Dtos;
    using ServiceStack.OrmLite;
    using Web.Application.Staff.CommandsContexts;

    public class CreateStaffCommand : ICommand<CreateStaffCommandContext>
    {
        public void Execute(CreateStaffCommandContext commandContext)
        {
            using (var connection = new ConnectionFactory().Create())
            {
                var staff = new Staff(commandContext.Form.Name, commandContext.Form.Quantity);

                connection.InsertOnly(
                    new StaffDto
                        {
                            NAME = staff.Name,
                            QUANTITY = staff.Quantity,
                            CREATED_AT = staff.CreatedAt
                        },
                    ev => ev.Insert(p => new
                        {
                            p.NAME,
                            p.QUANTITY,
                            p.CREATED_AT
                        }));
            }
        }
    }
}