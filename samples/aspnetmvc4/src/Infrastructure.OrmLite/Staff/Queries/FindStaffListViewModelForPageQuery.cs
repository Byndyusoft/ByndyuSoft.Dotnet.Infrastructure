namespace Mvc4Sample.Infrastructure.OrmLite.Staff.Queries
{
    using System.Linq;
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.Web.Mvc.Paging;
    using Web.Application.Staff.Criteria;
    using Web.Application.Staff.ViewModels;

    public class FindStaffListViewModelForPageQuery : IQuery<FindStaffListViewModelForPage, StaffListViewModel>
    {
        public StaffListViewModel Ask(FindStaffListViewModelForPage criterion)
        {
            return new StaffListViewModel
                {
                    Staff = Enumerable.Empty<StaffViewModel>(),
                    PageInfo = new PageInfo(criterion.Page - 1, criterion.PageSize, 0)
                };
        }
    }
}