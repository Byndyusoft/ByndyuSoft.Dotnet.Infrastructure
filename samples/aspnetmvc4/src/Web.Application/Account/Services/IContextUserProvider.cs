namespace Mvc4Sample.Web.Application.Account.Services
{
    using Mvc4Sample.Domain.Entities;

    public interface IContextUserProvider
    {
        User ContextUser();
        User ContextUser(bool shouldThrow);
    }
}