namespace Mvc4Sample.Web.Application.Account.Forms.Handlers
{
    using ByndyuSoft.Infrastructure.Web.Forms;
    using Services;

    public class SignOutHandler : IFormHandler<SignOut>
    {
        private readonly IAuthenticationService _authenticationService;

        public SignOutHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public virtual void Execute(SignOut command)
        {
            _authenticationService.SignOut();
        }
    }
}