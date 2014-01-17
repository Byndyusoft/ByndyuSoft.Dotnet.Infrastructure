namespace Mvc4Sample.Web.Application.Staff.Forms
{
    using ByndyuSoft.Infrastructure.Web.Forms;

    public class CreateStaffForm : IForm
    {
        public string Name { get; set; }

        public int Quantity { get; set; }
    }
}