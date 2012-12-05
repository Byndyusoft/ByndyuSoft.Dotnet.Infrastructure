namespace ByndyuSoft.Infrastructure.NHibernate
{
    using System.Linq;
    using Domain;
    using JetBrains.Annotations;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TCriterion"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    [PublicAPI]
    public abstract class LinqQueryBase<TEntity, TCriterion, TResult> : IQuery<TCriterion, TResult>
        where TCriterion : ICriterion
        where TEntity : class, IEntity
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
        public virtual IQueryable<TEntity> Query
        {
            get { return _linq.Query<TEntity>(); }
        }

        public abstract TResult Ask(TCriterion criterion);
    }
}