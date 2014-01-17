namespace Mvc4Sample.Infrastructure.NHibernate.Queries.User
{
    using System.Linq;
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.NHibernate;
    using Mvc4Sample.Domain.Entities;
    using Web.Application.Account.Criteria;

    public class FindByLoginOrEmailQuery : LinqQueryBase<User, FindByLogin, User>
    {
        public FindByLoginOrEmailQuery(ILinqProvider linqProvider)
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