using System;
using System.Data;
using ByndyuSoft.Infrastructure.Domain;
using NHibernate;
using NHibernate.Context;

namespace ByndyuSoft.Infrastructure.NHibernate
{
	internal class NHibernateUnitOfWork : IUnitOfWork
	{
		private readonly ISession session;
	    private ITransaction transaction;

	    public void Dispose()
		{
		    if (!transaction.WasCommitted && !transaction.WasRolledBack)
		        transaction.Rollback();
		    transaction.Dispose();
			transaction = null;

			CurrentSessionContext.Unbind(session.SessionFactory);
			session.Dispose();
		}

		public void Commit()
		{
			transaction.Commit();
		}

		public void Save<TEntity>(TEntity entity) where TEntity : IEntity
		{
			session.Save(entity);
		}

		public void Delete<TEntity>(TEntity entity) where TEntity : IEntity
		{
			session.Delete(entity);
		}

	    public NHibernateUnitOfWork(ISession session, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted) 
	    {
            if (session == null)
                throw new ArgumentNullException("session");

            CurrentSessionContext.Bind(session);

            this.session = session;
            transaction = session.BeginTransaction(isolationLevel);
	    }
	}
}