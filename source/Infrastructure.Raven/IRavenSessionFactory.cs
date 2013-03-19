namespace ByndyuSoft.Infrastructure.Raven.DB
{
    using global::Raven.Client;

    public interface IRavenSessionFactory
    {
        IDocumentSession OpenSession();
    }
}