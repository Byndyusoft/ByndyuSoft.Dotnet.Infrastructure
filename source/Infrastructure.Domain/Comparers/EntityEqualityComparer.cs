namespace ByndyuSoft.Infrastructure.Domain.Comparers
{
    using System.Collections;

    /// <summary>
    /// 
    /// </summary>
    public class EntityEqualityComparer : IEqualityComparer
    {
        public new bool Equals(object x, object y)
        {
            if (x == null || y == null)
                return false;

            if (x is IEntity && y is IEntity)
                return ((IEntity) x).Id == ((IEntity) y).Id;

            return x.Equals(y);
        }

        public int GetHashCode(object obj)
        {
            return ((IEntity) obj).Id.GetHashCode();
        }
    }
}