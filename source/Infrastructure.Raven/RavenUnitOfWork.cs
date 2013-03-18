using System;
using ByndyuSoft.Infrastructure.Domain;
using Raven.Client;

namespace ByndyuSoft.Infrastructure.Raven.DB
{
    public class RavenUnitOfWork : IUnitOfWork
    {
        private readonly IDocumentSession _session;

        public RavenUnitOfWork(IDocumentSession session)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            _session = session;
        }

        public void Dispose()
        {
            _session.Dispose();
        }

        public void Commit()
        {
            _session.SaveChanges();
        }

        public void Save<TEntity>(TEntity entity)
            where TEntity : class, IEntity, new()
        {
            _session.Store(entity);
        }

        public void Delete<TEntity>(TEntity entity)
            where TEntity : class, IEntity, new()
        {
            var inbase = _session.Load<TEntity>(entity.Id);
            if (inbase != null)
                _session.Delete(inbase);
        }
    }
}