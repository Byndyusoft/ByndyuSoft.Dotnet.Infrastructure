namespace ByndyuSoft.Infrastructure.Dapper
{
    using ByndyuSoft.Infrastructure.Domain;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IDapperRepository<TEntity> : IRepository<TEntity>
        where TEntity : IEntity
    {
        // <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// TODO tracking changes will be better solution
        void AddOrUpdate(TEntity entity);
    }
}