namespace ByndyuSoft.Infrastructure.Common
{
	using System;

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class NullableRange<T> : IEquatable<NullableRange<T>> 
        where T : struct, IComparable<T>
	{
	    /// <summary>
	    ///     Creates instance of <see cref="NullableRange{T}" /> with boundaries specified.
	    /// </summary>
        /// <param name="min">Inclusive lower boundary value of newly created range.</param>
        /// <param name="max">Inclusive upper boundary value of newly created range.</param>
	    public NullableRange(T? min, T? max)
            : this()
		{
			Min = min;
			Max = max;
		}

	    /// <summary>
	    ///     Creates empty instance of <see cref="NullableRange{T}" />.
	    /// </summary>
	    public NullableRange()
		{
		}

	    /// <summary>
	    ///     Inclusive lower boundary value of this range.
	    /// </summary>
	    public T? Min { get; set; }

	    /// <summary>
	    ///     Inclusive upper boundary value of this range.
	    /// </summary>
	    public T? Max { get; set; }

	    /// <summary>
        ///     Returns <value>true</value> if this range have valid boundary values, otherwise <value>false</value>.
	    /// </summary>
	    public bool IsValid
		{
			get
			{
				return !Min.HasValue ||
				       !Max.HasValue ||
				       Min.Value.CompareTo(Max.Value) <= 0;
			}
		}

		public bool Equals(NullableRange<T> other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Min.Equals(Min) && other.Max.Equals(Max);
		}

	    /// <summary>
	    ///     Checks whether value given lies within boundaries of this range.
	    /// </summary>
	    /// <param name="value">Value to check.</param>
        /// <returns><value>True</value> if range contains value, otherwise <value>false</value>.</returns>
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
				return ((Min.HasValue ? Min.Value.GetHashCode() : 0)*397) ^ (Max.HasValue ? Max.Value.GetHashCode() : 0);
			}
		}
	}
}