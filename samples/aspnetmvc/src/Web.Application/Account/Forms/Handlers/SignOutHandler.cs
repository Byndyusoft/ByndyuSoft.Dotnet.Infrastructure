namespace MvcSample.Web.Application.Account.Forms.Handlers
{
	using ByndyuSoft.Infrastructure.Web.Forms;
	using Services;

	public class SignOutHandler : IFormHandler<SignOut>
	{
		private readonly IAuthenticationService service;

		public SignOutHandler(IAuthenticationService service)
		{
			this.service = service;
		}

		public virtual void Execute(SignOut command)
		{
			service.SignOut();
		}
	}
}