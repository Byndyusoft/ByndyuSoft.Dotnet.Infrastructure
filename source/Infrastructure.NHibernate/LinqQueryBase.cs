namespace ByndyuSoft.Infrastructure.NHibernate
{
    using System.Linq;
    using Domain;

    public abstract class LinqQueryBase<TEntity, TCriterion, TResult> : IQuery<TCriterion, TResult>
        where TCriterion : ICriterion
        where TEntity : IEntity
    {
        private readonly ILinqProvider linq;

        protected LinqQueryBase(ILinqProvider linq)
        {
            this.linq = linq;
        }

        public virtual IQueryable<TEntity> Query
        {
            get { return linq.Query<TEntity>(); }
        }

        public abstract TResult Ask(TCriterion criterion);
    }
}