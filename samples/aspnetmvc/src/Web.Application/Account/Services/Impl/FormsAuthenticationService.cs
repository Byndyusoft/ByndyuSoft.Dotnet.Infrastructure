namespace MvcSample.Web.Application.Account.Services.Impl
{
	using System;
	using System.Security.Principal;
	using System.Web;
	using System.Web.Security;
	using Domain.Entities;

	public class FormsAuthenticationService : IAuthenticationService
	{
		public void SignIn(User user, bool createPersistentCookie)
		{
			var accountEntry = new AccountEntry(user);

			var authTicket = new FormsAuthenticationTicket(1,
			                                               user.Login,
			                                               DateTime.Now,
			                                               DateTime.Now.AddMinutes(45),
			                                               createPersistentCookie,
			                                               accountEntry.Serialize());

			string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

			var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
			                 	{
			                 		Expires = DateTime.Now.Add(FormsAuthentication.Timeout),
			                 	};

			HttpContext.Current.Response.Cookies.Add(authCookie);

			var identity = new CustomIdentity(accountEntry, authTicket.Name);

			HttpContext.Current.User = new GenericPrincipal(identity, identity.GetRoles());
		}

		public void SignOut()
		{
			FormsAuthentication.SignOut();
		}
	}
}