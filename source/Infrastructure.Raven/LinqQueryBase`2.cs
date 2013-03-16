namespace ByndyuSoft.Infrastructure.Raven
{
    using Domain;    
    using global::Raven.Client.Linq;
    using JetBrains.Annotations;

    [PublicAPI]
    public abstract class LinqQueryBase<TCriterion, TResult> : IQuery<TCriterion, TResult>
        where TCriterion : ICriterion
    {
        public IRavenSessionFactory SessionFactory { get; set; }

        [PublicAPI]
        [NotNull]        
        protected IRavenQueryable<TEntity> Query<TEntity>()
            where TEntity : class
        {
            return SessionFactory.OpenSession()
                .Query<TEntity>();
        }

        public abstract TResult Ask(TCriterion criterion);
    }
}