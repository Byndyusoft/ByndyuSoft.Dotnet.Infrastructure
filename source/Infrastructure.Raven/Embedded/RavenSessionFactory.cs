using JetBrains.Annotations;
using Raven.Client;
using Raven.Client.Embedded;

namespace ByndyuSoft.Infrastructure.Raven.DB.Embedded
{
    [UsedImplicitly]
    public class RavenSessionFactory : IRavenSessionFactory
    {
        private readonly IDocumentStore _documentStore;

        public RavenSessionFactory(string path)
        {
            _documentStore = new EmbeddableDocumentStore {DataDirectory = path};
            _documentStore.Initialize();
        }

        public IDocumentSession OpenSession()
        {
            return _documentStore.OpenSession();
        }
    }
}