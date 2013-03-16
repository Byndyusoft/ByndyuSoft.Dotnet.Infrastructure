namespace ByndyuSoft.Infrastructure.Raven
{
    using Domain;
    using global::Raven.Client;
    using JetBrains.Annotations;

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