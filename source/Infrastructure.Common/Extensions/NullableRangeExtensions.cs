using System;

namespace ByndyuSoft.Infrastructure.Common.Extensions
{
	public static class NullableRangeExtensions
	{
		public static bool In(this NullableRange<decimal> @this, decimal? value, decimal dispersion)
		{
			return new NullableRange<decimal>(
				@this.Min.HasValue ? (long) Math.Round(@this.Min.Value * (1 - dispersion)) : (decimal?) null,
				@this.Max.HasValue ? (long) Math.Round(@this.Max.Value * (1 + dispersion)) : (decimal?) null)
				.In(value);
		}

		public static bool In(this NullableRange<int> @this, int? value, decimal dispersion)
		{
			return In(new NullableRange<decimal>(@this.Min, @this.Max), value, dispersion);
		}

		public static bool In(this NullableRange<long> @this, long? value, decimal dispersion)
		{
			return In(new NullableRange<decimal>(@this.Min, @this.Max), value, dispersion);
		}
	}
}