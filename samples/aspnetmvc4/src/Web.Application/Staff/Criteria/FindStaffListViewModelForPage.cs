namespace Mvc4Sample.Web.Application.Staff.Criteria
{
    using ByndyuSoft.Infrastructure.Domain;

    public class FindStaffListViewModelForPage : ICriterion
    {
        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}