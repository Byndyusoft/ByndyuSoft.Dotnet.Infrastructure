namespace Mvc4Sample.Web.Application.Staff.Forms.Handlers
{
    using ByndyuSoft.Infrastructure.Domain.Commands;
    using ByndyuSoft.Infrastructure.Web.Forms;
    using Commands.Contexts;

    public class CreateStaffHandler : IFormHandler<CreateStaffForm>
    {
        private readonly ICommandBuilder _commandBuilder;

        public CreateStaffHandler(ICommandBuilder commandBuilder)
        {
            _commandBuilder = commandBuilder;
        }

        public void Execute(CreateStaffForm form)
        {
            _commandBuilder
                .Execute(new CreateStaffCommandContext
                    {
                        Form = form
                    });
        }
    }
}