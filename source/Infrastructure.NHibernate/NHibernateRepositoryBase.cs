using System;
using ByndyuSoft.Infrastructure.Domain;
using NHibernate;

namespace ByndyuSoft.Infrastructure.NHibernate
{
	///<summary>
	///</summary>
	public abstract class NHibernateRepositoryBase<TEntity> : IRepository<TEntity>
		where TEntity : class, IEntity
	{
	    private readonly ISessionProvider sessionProvider;

	    ///<summary>
	    ///</summary>
	    ///<param name="sessionProvider"></param>
	    ///<exception cref="ArgumentNullException"><c>sessionProvider</c> is null.</exception>
	    protected NHibernateRepositoryBase(ISessionProvider sessionProvider)
		{
			if (sessionProvider == null)
				throw new ArgumentNullException("sessionProvider");

			this.sessionProvider = sessionProvider;
		}

		protected ISession Session
		{
			get { return sessionProvider.CurrentSession; }
		}

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
	}

    /// <summary>
    /// Стандартный репозиторий для NHibernate
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public sealed class NHibernateRepository<TEntity> : NHibernateRepositoryBase<TEntity> where TEntity : class, IEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="sessionProvider"></param>
        public NHibernateRepository(ISessionProvider sessionProvider) : base(sessionProvider)
        {
        }
    }
}