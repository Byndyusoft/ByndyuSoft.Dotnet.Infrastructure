using System;
using System.Collections;
using System.Collections.Generic;

namespace ByndyuSoft.Infrastructure.Domain.Comparers
{
	public class EntityEqualityComparer : IEqualityComparer
	{
		public new bool Equals(object x, object y)
		{
			if (x == null || y == null)
				return false;

			if (x is IEntity && y is IEntity)
				return ((IEntity)x).Id == ((IEntity)y).Id;

			return x.Equals(y);
		}

		public int GetHashCode(object obj)
		{
			throw new NotImplementedException();
		}
	}

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