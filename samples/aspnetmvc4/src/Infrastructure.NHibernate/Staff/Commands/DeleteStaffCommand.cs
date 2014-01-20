namespace Mvc4Sample.Infrastructure.NHibernate.Staff.Commands
{
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.Domain.Commands;
    using Domain.Entities;
    using Web.Application.Staff.CommandsContexts;

    public class DeleteStaffCommand : ICommand<DeleteStaffCommandContext>
    {
        private readonly IRepository<Staff> _repository;

        public DeleteStaffCommand(IRepository<Staff> repository)
        {
            _repository = repository;
        }

        public void Execute(DeleteStaffCommandContext commandContext)
        {
            _repository.Remove(_repository.Get(commandContext.Id));
        }
    }
}