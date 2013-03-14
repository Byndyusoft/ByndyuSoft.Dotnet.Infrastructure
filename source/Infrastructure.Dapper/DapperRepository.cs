namespace ByndyuSoft.Infrastructure.Dapper
{
    using ByndyuSoft.Infrastructure.Domain;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public sealed class DapperRepository<TEntity> : DapperRepositoryBase<TEntity>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        public DapperRepository(IQueryBuilder query)
            : base(query)
        {
        }
    }
}