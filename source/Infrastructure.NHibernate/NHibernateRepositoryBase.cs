namespace ByndyuSoft.Infrastructure.NHibernate
{
    using System;
    using Domain;
    using global::NHibernate;

    ///<summary>
    ///</summary>
    public abstract class NHibernateRepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly ISessionProvider _sessionProvider;

        ///<summary>
        ///</summary>
        ///<param name="sessionProvider"> </param>
        ///<exception cref="ArgumentNullException">
        ///  <c>sessionProvider</c>
        ///  is null.</exception>
        protected NHibernateRepositoryBase(ISessionProvider sessionProvider)
        {
            if (sessionProvider == null)
                throw new ArgumentNullException("sessionProvider");

            _sessionProvider = sessionProvider;
        }

        protected ISession Session
        {
            get { return _sessionProvider.CurrentSession; }
        }

        #region IRepository<TEntity> Members

        public virtual TEntity Get(int id)
        {
            return Session.Get<TEntity>(id);
        }

        public virtual void Add(TEntity entity)
        {
            Session.SaveOrUpdate(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            Session.Delete(entity);
        }

        #endregion
    }
}