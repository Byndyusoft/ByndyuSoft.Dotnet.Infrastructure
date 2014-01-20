namespace Mvc4Sample.Infrastructure.OrmLite.Staff.Commands
{
    using ByndyuSoft.Infrastructure.Dapper;
    using ByndyuSoft.Infrastructure.Domain.Commands;
    using Dtos;
    using ServiceStack.OrmLite;
    using ServiceStack.OrmLite.SqlServer;
    using Web.Application.Staff.Commands.Contexts;

    public class EditStaffCommand : ICommand<EditStaffCommandContext>
    {
        public void Execute(EditStaffCommandContext commandContext)
        {
            OrmLiteConfig.DialectProvider = new SqlServerOrmLiteDialectProvider();

            using (var connection = new ConnectionFactory().Create())
            {
                connection.UpdateOnly(
                    new StaffDto
                        {
                            NAME = commandContext.Form.Name,
                            QUANTITY = commandContext.Form.Quantity
                        },
                    staffDto => new
                        {
                            staffDto.NAME,
                            staffDto.QUANTITY
                        },
                    staffDto => staffDto.STAFF_ID == commandContext.Form.Id);
            }
        }
    }
}