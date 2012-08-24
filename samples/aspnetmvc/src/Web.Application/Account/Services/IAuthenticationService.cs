namespace MvcSample.Web.Application.Account.Services
{
	using Domain.Entities;

	public interface IAuthenticationService
	{
		void SignIn(User user, bool createPersistentCookie);
		void SignOut();
	}
}