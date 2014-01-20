namespace Mvc4Sample.Infrastructure.NHibernate.Staff.Commands
{
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.Domain.Commands;
    using Domain.Entities;
    using Web.Application.Staff.CommandsContexts;

    public class EditStaffCommand : ICommand<EditStaffCommandContext>
    {
        private readonly IRepository<Staff> _repository;

        public EditStaffCommand(IRepository<Staff> repository)
        {
            _repository = repository;
        }

        public void Execute(EditStaffCommandContext commandContext)
        {
            var staffForEditing = _repository.Get(commandContext.Form.Id);

            staffForEditing.SetName(commandContext.Form.Name);
            staffForEditing.SetQuantity(commandContext.Form.Quantity);
        }
    }
}