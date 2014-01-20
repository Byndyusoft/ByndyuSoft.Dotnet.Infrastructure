namespace Mvc4Sample.Infrastructure.NHibernate.User.Queries
{
    using System.Linq;
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.NHibernate;
    using Domain.Entities;
    using Web.Application.Account.Criteria;

    public class FindByLoginQuery : LinqQueryBase<User, FindByLogin, User>
    {
        public FindByLoginQuery(ILinqProvider linqProvider)
            : base(linqProvider)
        {
        }

        public override User Ask(FindByLogin criterion)
        {
            return Query
                .SingleOrDefault(x => x.Login == criterion.Login);
        }
    }
}