namespace MvcSample.Infrastructure.NHibernate
{
    using System;
    using ByndyuSoft.Infrastructure.NHibernate;
    using global::NHibernate;

    /// <summary>
    /// Провайдер для сессии на запрос.
    /// </summary>
    public class PerRequestSessionProvider : ISessionProvider, IDisposable
    {
        private readonly ISessionFactory sessionFactory;
        private bool disposed;
        private bool preventCommit;
        private ISession session;
        private ITransaction transaction;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="sessionFactory"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public PerRequestSessionProvider(ISessionFactory sessionFactory)
        {
            if (sessionFactory == null)
                throw new ArgumentNullException("sessionFactory");

            this.sessionFactory = sessionFactory;
        }

        public void Dispose()
        {
            if (disposed)
                return;

            if (session == null)
                return;

            try
            {
                if (preventCommit)
                    transaction.Rollback();
                else
                    transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                transaction.Dispose();
            }

            session.Dispose();
            session = null;
            transaction = null;
            disposed = true;
        }

        public ISession CurrentSession
        {
            get
            {
                if (disposed)
                    throw new InvalidOperationException("Object already disposed. Probably container has wrong lifestyle type");

                if (session != null)
                    return session;

                session = sessionFactory.OpenSession();
                transaction = session.BeginTransaction();

                return session;
            }
        }

        public void PreventCommit()
        {
            preventCommit = true;
        }
    }
}