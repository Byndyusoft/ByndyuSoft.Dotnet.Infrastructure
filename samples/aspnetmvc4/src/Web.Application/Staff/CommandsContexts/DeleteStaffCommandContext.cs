namespace Mvc4Sample.Web.Application.Staff.CommandsContexts
{
    using ByndyuSoft.Infrastructure.Domain.Commands;

    public class DeleteStaffCommandContext : ICommandContext
    {
        public int Id { get; set; } 
    }
}