namespace Mvc4Sample.Web.Application.Account.Services
{
    using Mvc4Sample.Domain.Entities;

    public interface IAuthenticationService
    {
        void SignIn(User user, bool createPersistentCookie);
        void SignOut();
    }
}