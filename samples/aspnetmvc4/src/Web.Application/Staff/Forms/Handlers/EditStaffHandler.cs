namespace Mvc4Sample.Web.Application.Staff.Forms.Handlers
{
    using ByndyuSoft.Infrastructure.Domain.Commands;
    using ByndyuSoft.Infrastructure.Web.Forms;
    using CommandsContexts;

    public class EditStaffHandler : IFormHandler<EditStaffForm>
    {
        private readonly ICommandBuilder _commandBuilder;

        public EditStaffHandler(ICommandBuilder commandBuilder)
        {
            _commandBuilder = commandBuilder;
        }

        public void Execute(EditStaffForm form)
        {
            _commandBuilder
                .Execute(new EditStaffCommandContext
                    {
                        Form = form
                    });
        }
    }
}