namespace ByndyuSoft.Infrastructure.Domain.Criteria
{
    /// <summary>
    /// критерий для удаления сущности
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class DeleteEntity<TEntity> : InsertEntity<TEntity>
        where TEntity : IEntity
    {
        public DeleteEntity(TEntity entity)
            : base(entity)
        {

        }
    }
}