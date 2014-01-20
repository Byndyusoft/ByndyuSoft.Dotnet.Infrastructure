namespace Mvc4Sample.Infrastructure.NHibernate.Staff.Commands
{
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.Domain.Commands;
    using Domain.Entities;
    using Web.Application.Staff.CommandsContexts;

    public class CreateStaffCommand : ICommand<CreateStaffCommandContext>
    {
        private readonly IRepository<Staff> _repository;

        public CreateStaffCommand(IRepository<Staff> repository)
        {
            _repository = repository;
        }

        public void Execute(CreateStaffCommandContext commandContext)
        {
            _repository.Add(new Staff(commandContext.Form.Name, commandContext.Form.Quantity));
        }
    }
}