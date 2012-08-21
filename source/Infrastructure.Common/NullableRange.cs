using System;

namespace ByndyuSoft.Infrastructure.Common
{
	public class NullableRange<T> : IEquatable<NullableRange<T>> where T : struct, IComparable<T>
	{
		public NullableRange(T? min, T? max) : this()
		{
			Min = min;
			Max = max;
		}

		public NullableRange()
		{
		}

		public T? Min { get; set; }
		public T? Max { get; set; }

		public bool IsValid
		{
			get
			{
				return !Min.HasValue ||
				       !Max.HasValue ||
				       Min.Value.CompareTo(Max.Value) <= 0;
			}
		}

		#region IEquatable<NullableRange<T>> Members

		public bool Equals(NullableRange<T> other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Min.Equals(Min) && other.Max.Equals(Max);
		}

		#endregion

		public bool In(T? value)
		{
			return !value.HasValue ||
			       ((!Min.HasValue || value.Value.CompareTo(Min.Value) >= 0) &&
			        (!Max.HasValue || value.Value.CompareTo(Max.Value) <= 0));
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as NullableRange<T>);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((Min.HasValue ? Min.Value.GetHashCode() : 0) * 397) ^ (Max.HasValue ? Max.Value.GetHashCode() : 0);
			}
		}
	}
}