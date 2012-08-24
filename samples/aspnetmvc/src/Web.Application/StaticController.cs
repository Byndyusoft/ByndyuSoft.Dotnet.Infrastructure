namespace MvcSample.Web.Application
{
	using System.Web.Mvc;
	using Account;
	using Microsoft.Web.Mvc;

	public class StaticController : Controller
	{
		public ActionResult Index()
		{
			return this.RedirectToAction<AccountController>(x => x.Profile());
		}
	}
}