namespace ByndyuSoft.Infrastructure.Domain.Comparers
{
    using System.Collections.Generic;
    using JetBrains.Annotations;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    [PublicAPI]
    public class EntityEqualityComparer<TEntity> : IEqualityComparer<TEntity>
        where TEntity : class, IEntity
    {
        public bool Equals(TEntity x, TEntity y)
        {
            if (x == null || y == null)
                return false;

            return x.Id == y.Id;
        }

        public int GetHashCode(TEntity obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}