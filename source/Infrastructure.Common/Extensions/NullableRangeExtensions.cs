namespace ByndyuSoft.Infrastructure.Common.Extensions
{
	using System;

    /// <summary>
    ///     Provides various extension methods for <see cref="NullableRange{T}" /> class.
    /// </summary>
    public static class NullableRangeExtensions
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="this"></param>
		/// <param name="value"></param>
		/// <param name="dispersion"></param>
		/// <returns></returns>
		public static bool In(this NullableRange<decimal> @this, decimal? value, decimal dispersion)
		{
			return new NullableRange<decimal>(
				@this.Min.HasValue ? (long) Math.Round(@this.Min.Value*(1 - dispersion)) : (decimal?) null,
				@this.Max.HasValue ? (long) Math.Round(@this.Max.Value*(1 + dispersion)) : (decimal?) null)
				.In(value);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="this"></param>
		/// <param name="value"></param>
		/// <param name="dispersion"></param>
		/// <returns></returns>
		public static bool In(this NullableRange<int> @this, int? value, decimal dispersion)
		{
			return In(new NullableRange<decimal>(@this.Min, @this.Max), value, dispersion);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="this"></param>
		/// <param name="value"></param>
		/// <param name="dispersion"></param>
		/// <returns></returns>
		public static bool In(this NullableRange<long> @this, long? value, decimal dispersion)
		{
			return In(new NullableRange<decimal>(@this.Min, @this.Max), value, dispersion);
		}
	}
}