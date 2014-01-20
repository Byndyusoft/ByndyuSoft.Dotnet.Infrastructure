namespace Mvc4Sample.Web.Application.Staff.Forms
{
    using ByndyuSoft.Infrastructure.Web.Forms;

    public class EditStaffForm : IForm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }
    }
}