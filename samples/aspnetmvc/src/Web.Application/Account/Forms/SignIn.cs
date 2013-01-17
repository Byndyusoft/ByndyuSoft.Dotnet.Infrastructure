namespace MvcSample.Web.Application.Account.Forms
{
    using ByndyuSoft.Infrastructure.Web.Forms;

    public class SignIn : IForm
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}