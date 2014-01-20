namespace Mvc4Sample.Web.Application.Account.Services.Impl
{
    using System;
    using System.Web;
    using ByndyuSoft.Infrastructure.Domain;
    using Mvc4Sample.Domain.Entities;

    public class ContextUserProvider : IContextUserProvider
    {
        private readonly IRepository<User> userRepository;

        public ContextUserProvider(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public User ContextUser()
        {
            return ContextUser(true);
        }

        public User ContextUser(bool shouldThrow)
        {
            var identity = HttpContext.Current.User.Identity as CustomIdentity;
            if (identity == null)
            {
                if (shouldThrow)
                    throw new NotSupportedException();
                return null;
            }
            return userRepository.Get(identity.Id);
        }
    }
}