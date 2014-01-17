namespace Mvc4Sample.Web.Application.Staff
{
    using System.Web.Mvc;
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.Web.Forms;
    using Criteria;
    using Domain.Entities;
    using Forms;
    using Microsoft.Web.Mvc;
    using ViewModels;

    [CustomAuthorize]
    public class StaffController : FormControllerBase
    {
        private readonly IQueryBuilder _queryBuilder;

        public StaffController(IFormHandlerFactory formHandlerFactory, IQueryBuilder queryBuilder) : base(formHandlerFactory)
        {
            _queryBuilder = queryBuilder;
        }

        [HttpGet]
        public ActionResult CreateStaff()
        {
            return View(new CreateStaffForm());
        }

        [HttpPost]
        public ActionResult CreateStaff(CreateStaffForm form)
        {
            return Form(form, this.RedirectToAction(x => x.List(1)));
        }

        [HttpGet]
        public ActionResult EditStaff(int id)
        {
            var staffForEditing = _queryBuilder
                .For<Staff>()
                .With(new FindStaffById {Id = id});

            return View(new EditStaffForm
                {
                    Id = staffForEditing.Id,
                    Name = staffForEditing.Name,
                    Quantity = staffForEditing.Quantity
                });
        }

        [HttpPost]
        public ActionResult EditStaff(EditStaffForm form)
        {
            return Form(form, this.RedirectToAction(x => x.List(1)));
        }

        [HttpPost]
        public ActionResult DeleteStaff(DeleteStaff form, int page = 1)
        {
            return Form(form, this.RedirectToAction(x => x.List(page)));
        }

        [HttpGet]
        public ActionResult List(int page = 1)
        {
            return View(_queryBuilder
                            .For<StaffListViewModel>()
                            .With(new FindStaffListViewModelForPage {Page = page, PageSize = 5}));
        }
    }
}