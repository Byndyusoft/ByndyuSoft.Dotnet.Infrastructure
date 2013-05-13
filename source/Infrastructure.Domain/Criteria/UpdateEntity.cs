namespace ByndyuSoft.Infrastructure.Domain.Criteria
{
    /// <summary>
    /// критерий для обнавления сущности
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class UpdateEntity<TEntity> : InsertEntity<TEntity>
        where TEntity : IEntity
    {
        public UpdateEntity(TEntity entity)
            : base(entity)
        {

        }
    }
}