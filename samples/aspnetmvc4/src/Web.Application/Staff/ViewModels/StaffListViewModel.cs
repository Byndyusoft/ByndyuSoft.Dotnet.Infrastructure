namespace Mvc4Sample.Web.Application.Staff.ViewModels
{
    using System.Collections.Generic;
    using ByndyuSoft.Infrastructure.Web.Mvc.Paging;

    public class StaffListViewModel
    {
        public IEnumerable<StaffViewModel> Staff { get; set; }

        public PageInfo PageInfo { get; set; }
    }
}