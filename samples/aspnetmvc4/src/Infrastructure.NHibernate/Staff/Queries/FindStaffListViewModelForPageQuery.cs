namespace Mvc4Sample.Infrastructure.NHibernate.Staff.Queries
{
    using System.Linq;
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.NHibernate;
    using ByndyuSoft.Infrastructure.Web.Mvc.Paging;
    using Domain.Entities;
    using Web.Application.Infrastructure;
    using Web.Application.Staff.Criteria;
    using Web.Application.Staff.ViewModels;

    public class FindStaffListViewModelForPageQuery : LinqQueryBase<Staff, FindStaffListViewModelForPage, StaffListViewModel>
    {
        public FindStaffListViewModelForPageQuery(ILinqProvider linq) : base(linq)
        {
        }

        public override StaffListViewModel Ask(FindStaffListViewModelForPage criterion)
        {
            int totalCount = Query.Count();

            return new StaffListViewModel
                {
                    Staff = Query.OrderByDescending(x => x.CreatedAt)
                                 .Page(criterion.Page, criterion.PageSize)
                                 .AsEnumerable()
                                 .Select(x => new StaffViewModel
                                     {
                                         Id = x.Id,
                                         Name = x.Name,
                                         Quantity = x.Quantity,
                                         CreatedAt = x.CreatedAt
                                     }),
                    PageInfo = new PageInfo(criterion.Page - 1, criterion.PageSize, totalCount)
                };
        }
    }
}