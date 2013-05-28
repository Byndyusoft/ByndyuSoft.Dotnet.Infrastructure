namespace ByndyuSoft.Infrastructure.Common
{
	using System;

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Range<T> : IEquatable<Range<T>>
		where T : IComparable<T>
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		public Range(T min, T max) : this()
		{
			Min = min;
			Max = max;
		}

		/// <summary>
		/// 
		/// </summary>
		public Range()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public T Min { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public T Max { get; set; }

		/// <summary>
		/// 
		/// </summary>
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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
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