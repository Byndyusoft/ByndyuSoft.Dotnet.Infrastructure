using Raven.Client;

namespace ByndyuSoft.Infrastructure.Raven.DB
{
    public interface IRavenSessionFactory
    {
        IDocumentSession OpenSession();
    }
}