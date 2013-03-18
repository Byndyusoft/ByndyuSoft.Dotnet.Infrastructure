using System.Data;
using ByndyuSoft.Infrastructure.Domain;
using JetBrains.Annotations;

namespace ByndyuSoft.Infrastructure.Raven.DB
{
    [PublicAPI]
    public class RavenUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IRavenSessionFactory _sessionFactory;

        public RavenUnitOfWorkFactory(IRavenSessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public IUnitOfWork Create(IsolationLevel isolationLevel)
        {
            return new RavenUnitOfWork(_sessionFactory.OpenSession());
        }

        public IUnitOfWork Create()
        {
            return new RavenUnitOfWork(_sessionFactory.OpenSession());
        }
    }
}