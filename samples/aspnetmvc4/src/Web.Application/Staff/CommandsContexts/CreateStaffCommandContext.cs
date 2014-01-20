namespace Mvc4Sample.Web.Application.Staff.CommandsContexts
{
    using ByndyuSoft.Infrastructure.Domain.Commands;
    using Forms;

    public class CreateStaffCommandContext : ICommandContext
    {
        public CreateStaffForm Form { get; set; }
    }
}