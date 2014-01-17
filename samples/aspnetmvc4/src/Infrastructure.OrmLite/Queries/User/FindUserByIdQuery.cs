namespace Mvc4Sample.Infrastructure.NHibernate.Queries.User
{
    using System.Linq;
    using ByndyuSoft.Infrastructure.Domain.Criteria;
    using ByndyuSoft.Infrastructure.NHibernate;
    using Mvc4Sample.Domain.Entities;
    using global::NHibernate.Linq;

    public class FindUserByIdQuery : SessionQueryBase<FindById, User>
    {
        public FindUserByIdQuery(ISessionProvider sessionProvider) : base(sessionProvider)
        {
        }

        public override User Ask(FindById criterion)
        {
            return Session.Query<User>()
                .SingleOrDefault(x => x.Id == criterion.Id);
        }
    }
}