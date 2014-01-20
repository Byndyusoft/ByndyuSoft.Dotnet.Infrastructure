namespace Mvc4Sample.Web.Application.Staff.Forms.Handlers
{
    using ByndyuSoft.Infrastructure.Domain.Commands;
    using ByndyuSoft.Infrastructure.Web.Forms;
    using CommandsContexts;

    public class DeleteStaffHandler : IFormHandler<DeleteStaff>
    {
        private readonly ICommandBuilder _commandBuilder;

        public DeleteStaffHandler(ICommandBuilder commandBuilder)
        {
            _commandBuilder = commandBuilder;
        }

        public void Execute(DeleteStaff form)
        {
            _commandBuilder
                .Execute(new DeleteStaffCommandContext {Id = form.Id});
        }
    }
}