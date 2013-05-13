namespace ByndyuSoft.Infrastructure.Domain.Criteria
{
    using System;

    /// <summary>
    /// критерий для создания сущности
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class InsertEntity<TEntity> : ICriterion
        where TEntity : IEntity
    {
        public InsertEntity(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            Entity = entity;
        }

        public TEntity Entity { get; protected set; }
    }
}