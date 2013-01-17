namespace MvcSample.Infrastructure.NHibernate.Queries.User
{
    using System.Collections.Generic;
    using System.Linq;
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.Domain.Criterion;
    using ByndyuSoft.Infrastructure.NHibernate;
    using Domain.Entities;
    using Web.Application;

    public class AllUsersQuery : LinqQueryBase<User, AllEntities, IEnumerable<User>>
    {
        public AllUsersQuery(ILinqProvider linq) : base(linq)
        {
        }

        public override IEnumerable<User> Ask(AllEntities criterion)
        {
            return Query.ToList();
        }
    }
}