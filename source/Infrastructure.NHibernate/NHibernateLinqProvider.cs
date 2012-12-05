namespace ByndyuSoft.Infrastructure.NHibernate
{
    using System.Linq;
    using Domain;
    using JetBrains.Annotations;
    using global::NHibernate.Linq;

    /// <summary>
    /// 
    /// </summary>
    [PublicAPI]
    public class NHibernateLinqProvider : ILinqProvider
    {
        private readonly ISessionProvider _sessionProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionProvider"></param>
        public NHibernateLinqProvider(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        #region ILinqProvider Members

        public IQueryable<TEntity> Query<TEntity>()
            where TEntity : class, IEntity, new()
        {
            return _sessionProvider.CurrentSession.Query<TEntity>();
        }

        #endregion
    }
}