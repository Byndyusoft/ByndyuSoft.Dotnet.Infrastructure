namespace ByndyuSoft.Infrastructure.Raven.DB
{
    using Domain;
    using JetBrains.Annotations;
    using global::Raven.Client;

    [PublicAPI]
    public abstract class SessionQueryBase<TCriterion, TResult> : IQuery<TCriterion, TResult>
        where TCriterion : ICriterion
    {
        public IRavenSessionFactory SessionFactory { get; set; }

        [PublicAPI]
        [NotNull]
        protected IDocumentSession Session
        {
            get { return SessionFactory.OpenSession(); }
        }

        public abstract TResult Ask(TCriterion criterion);
    }
}