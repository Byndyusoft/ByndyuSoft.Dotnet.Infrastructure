using ByndyuSoft.Infrastructure.Domain;
using Raven.Client;
using JetBrains.Annotations;

namespace ByndyuSoft.Infrastructure.Raven.DB
{
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