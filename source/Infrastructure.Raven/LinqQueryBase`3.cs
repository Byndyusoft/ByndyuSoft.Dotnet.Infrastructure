namespace ByndyuSoft.Infrastructure.Raven
{
    using Domain;
    using JetBrains.Annotations;
    using global::Raven.Client.Linq;

    [PublicAPI]
    public abstract class LinqQueryBase<TEntity, TCriterion, TResult> : IQuery<TCriterion, TResult>
        where TEntity : class
        where TCriterion : ICriterion
    {
        public IRavenSessionFactory SessionFactory { get; set; }

        [PublicAPI]
        [NotNull]
        protected IRavenQueryable<TEntity> Query
        {
            get
            {
                return SessionFactory.OpenSession()
                    .Query<TEntity>();
            }
        }

        public abstract TResult Ask(TCriterion criterion);
    }
}