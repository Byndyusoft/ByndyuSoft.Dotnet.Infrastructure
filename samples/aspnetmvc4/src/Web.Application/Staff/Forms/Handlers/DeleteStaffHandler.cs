namespace Mvc4Sample.Web.Application.Staff.Forms.Handlers
{
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.Web.Forms;
    using Domain.Entities;

    public class DeleteStaffHandler : IFormHandler<DeleteStaff>
    {
        private readonly IRepository<Staff> _repository;

        public DeleteStaffHandler(IRepository<Staff> repository)
        {
            _repository = repository;
        }

        public void Execute(DeleteStaff form)
        {
            _repository.Remove(_repository.Get(form.Id));
        }
    }
}