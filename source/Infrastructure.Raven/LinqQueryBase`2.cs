namespace ByndyuSoft.Infrastructure.Raven.DB
{
    using Domain;
    using JetBrains.Annotations;
    using global::Raven.Client.Linq;

    [PublicAPI]
    public abstract class LinqQueryBase<TCriterion, TResult> : IQuery<TCriterion, TResult>
        where TCriterion : ICriterion
    {
        public IRavenSessionFactory SessionFactory { get; set; }

        public abstract TResult Ask(TCriterion criterion);

        [PublicAPI]
        [NotNull]
        protected IRavenQueryable<TEntity> Query<TEntity>()
            where TEntity : class
        {
            return SessionFactory.OpenSession()
                                 .Query<TEntity>();
        }
    }
}