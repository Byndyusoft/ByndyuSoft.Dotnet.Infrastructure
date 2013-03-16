namespace ByndyuSoft.Infrastructure.Raven
{
    using global::Raven.Client;

    public interface IRavenSessionFactory
    {
        IDocumentSession OpenSession();
    }
}