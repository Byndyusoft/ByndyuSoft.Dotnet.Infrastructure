namespace ByndyuSoft.Infrastructure.NHibernate
{
    using System;
    using System.Data;
    using Domain;
    using global::NHibernate;
    using global::NHibernate.Context;

    internal class NHibernateUnitOfWork : IUnitOfWork
    {
        private readonly ISession _session;
        private ITransaction _transaction;

        public NHibernateUnitOfWork(ISession session, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            CurrentSessionContext.Bind(session);

            _session = session;
            _transaction = session.BeginTransaction(isolationLevel);
        }

        #region IUnitOfWork Members

        public void Dispose()
        {
            if (!_transaction.WasCommitted && !_transaction.WasRolledBack)
                _transaction.Rollback();
            _transaction.Dispose();
            _transaction = null;

            CurrentSessionContext.Unbind(_session.SessionFactory);
            _session.Dispose();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Save<TEntity>(TEntity entity)
            where TEntity : class, IEntity, new()
        {
            _session.Save(entity);
        }

        public void Delete<TEntity>(TEntity entity)
            where TEntity : class, IEntity, new()
        {
            _session.Delete(entity);
        }

        #endregion
    }
}