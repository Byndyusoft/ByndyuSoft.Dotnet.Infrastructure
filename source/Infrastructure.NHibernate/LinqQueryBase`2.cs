namespace ByndyuSoft.Infrastructure.NHibernate
{
    using System.Linq;
    using Domain;
    using JetBrains.Annotations;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TCriterion"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    [PublicAPI]
    public abstract class LinqQueryBase<TCriterion, TResult> : IQuery<TCriterion, TResult>
        where TCriterion : ICriterion
    {
        private readonly ILinqProvider _linq;

        protected LinqQueryBase(ILinqProvider linq)
        {
            _linq = linq;
        }

        /// <summary>
        /// 
        /// </summary>
        [PublicAPI]
        public virtual IQueryable<TEntity> Query<TEntity>()
            where TEntity : class, IEntity, new()
        {
            return _linq.Query<TEntity>();
        }

        public abstract TResult Ask(TCriterion criterion);
    }
}