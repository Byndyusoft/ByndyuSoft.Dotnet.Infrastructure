namespace ByndyuSoft.Infrastructure.Common
{
	using System;

	public class Range<T> : IEquatable<Range<T>>
		where T : IComparable<T>
	{
		public Range(T min, T max) : this()
		{
			Min = min;
			Max = max;
		}

		public Range()
		{
		}

		public T Min { get; set; }
		public T Max { get; set; }

		public bool IsValid
		{
			get { return Min.CompareTo(Max) <= 0; }
		}

		public bool Equals(Range<T> other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Equals(other.Min, Min) && Equals(other.Max, Max);
		}

		public bool In(T value)
		{
			return value.CompareTo(Min) >= 0 && value.CompareTo(Max) <= 0;
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as Range<T>);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (Min.GetHashCode()*397) ^ Max.GetHashCode();
			}
		}
	}
}