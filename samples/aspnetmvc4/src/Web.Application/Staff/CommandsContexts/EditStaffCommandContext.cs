namespace Mvc4Sample.Web.Application.Staff.CommandsContexts
{
    using ByndyuSoft.Infrastructure.Domain.Commands;
    using Forms;

    public class EditStaffCommandContext : ICommandContext
    {
        public EditStaffForm Form { get; set; }
    }
}