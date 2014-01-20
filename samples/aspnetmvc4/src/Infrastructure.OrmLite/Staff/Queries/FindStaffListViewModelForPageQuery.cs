namespace Mvc4Sample.Infrastructure.OrmLite.Staff.Queries
{
    using System.Linq;
    using ByndyuSoft.Infrastructure.Dapper;
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.Web.Mvc.Paging;
    using Dtos;
    using ServiceStack.OrmLite;
    using Web.Application.Staff.Criteria;
    using Web.Application.Staff.ViewModels;

    public class FindStaffListViewModelForPageQuery : IQuery<FindStaffListViewModelForPage, StaffListViewModel>
    {
        public StaffListViewModel Ask(FindStaffListViewModelForPage criterion)
        {
            using (var connection = new ConnectionFactory().Create())
            {
                var totalCount = connection.Scalar<int>("SELECT COUNT(*) FROM STAFF");

                var staffOnPage = connection.Select<StaffDto>("SELECT * FROM STAFF ORDER BY CREATED_AT DESC OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY", new
                    {
                        offset = (criterion.Page - 1)*criterion.PageSize,
                        pageSize = criterion.PageSize
                    });

                return new StaffListViewModel
                    {
                        Staff = staffOnPage
                            .Select(x => new StaffViewModel
                                {
                                    Id = x.STAFF_ID,
                                    Name = x.NAME,
                                    Quantity = x.QUANTITY,
                                    CreatedAt = x.CREATED_AT
                                }),
                        PageInfo = new PageInfo(criterion.Page - 1, criterion.PageSize, totalCount)
                    };
            }
        }
    }
}