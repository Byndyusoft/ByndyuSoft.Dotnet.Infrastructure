namespace Mvc4Sample.Infrastructure.OrmLite.Staff.Commands
{
    using ByndyuSoft.Infrastructure.Dapper;
    using ByndyuSoft.Infrastructure.Domain.Commands;
    using Dtos;
    using ServiceStack.OrmLite;
    using Web.Application.Staff.CommandsContexts;

    public class DeleteStaffCommand : ICommand<DeleteStaffCommandContext>
    {
        public void Execute(DeleteStaffCommandContext commandContext)
        {
            using (var connection = new ConnectionFactory().Create())
            {
                connection.Delete<StaffDto>(x => x.STAFF_ID == commandContext.Id);
            }
        }
    }
}