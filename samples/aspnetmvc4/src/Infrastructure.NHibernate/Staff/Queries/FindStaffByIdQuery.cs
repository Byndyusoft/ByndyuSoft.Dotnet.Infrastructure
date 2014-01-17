namespace Mvc4Sample.Infrastructure.NHibernate.Staff.Queries
{
    using System.Linq;
    using ByndyuSoft.Infrastructure.NHibernate;
    using Domain.Entities;
    using Web.Application.Staff.Criteria;
    using global::NHibernate.Linq;

    public class FindStaffByIdQuery : SessionQueryBase<FindStaffById, Staff>
    {
        public FindStaffByIdQuery(ISessionProvider sessionProvider)
            : base(sessionProvider)
        {
        }

        public override Staff Ask(FindStaffById criterion)
        {
            return Session.Query<Staff>()
                          .SingleOrDefault(x => x.Id == criterion.Id);
        }
    }
}