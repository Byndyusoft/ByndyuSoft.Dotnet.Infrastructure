namespace ByndyuSoft.Infrastructure.NHibernate
{
    using Domain;
    using global::NHibernate;
    using JetBrains.Annotations;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TCriterion"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    [PublicAPI]
    public abstract class SessionQueryBase<TCriterion, TResult> : IQuery<TCriterion, TResult>
        where TCriterion : ICriterion
    {
        private readonly ISessionProvider _sessionProvider;

        protected SessionQueryBase(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual ISession Session
        {
            get { return _sessionProvider.CurrentSession; }
        }

        public abstract TResult Ask(TCriterion criterion);
    }
}