namespace Infrastructure.Common.Tests
{
	using ByndyuSoft.Infrastructure.Common;
	using Xunit;

	public class RangeTests
	{
		[Fact]
		public void RangeIsValidIfMaxGtMin()
		{
			var range = new Range<int>(-100, 100);
			Assert.True(range.IsValid);
		}

		[Fact]
		public void RangeIsInvalidIfMinGtMax()
		{
			var range = new Range<int>(100, -100);
			Assert.False(range.IsValid);
		}

		[Fact]
		public void ZeroLengthRangeIsValid()
		{
			var range = new Range<int>(0, 0);
			Assert.True(range.IsValid);
		}
	}
}