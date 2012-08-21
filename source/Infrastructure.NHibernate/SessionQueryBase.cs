namespace ByndyuSoft.Infrastructure.NHibernate
{
    using Domain;
    using global::NHibernate;

    public abstract class SessionQueryBase<TCriterion, TResult> : IQuery<TCriterion, TResult>
        where TCriterion : ICriterion
    {
        private readonly ISessionProvider sessionProvider;

        protected SessionQueryBase(ISessionProvider sessionProvider)
        {
            this.sessionProvider = sessionProvider;
        }

        public virtual ISession Session
        {
            get { return sessionProvider.CurrentSession; }
        }

        public abstract TResult Ask(TCriterion criterion);
    }
}