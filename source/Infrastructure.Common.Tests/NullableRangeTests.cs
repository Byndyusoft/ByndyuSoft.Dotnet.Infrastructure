using ByndyuSoft.Infrastructure.Common;
using Xunit;

namespace ByndyuSoft.Infrastructure.Common.Tests
{
	public class NullableRangeTests
	{
		[Fact]
		public void CheckOpenLeftRange()
		{
			var range = new NullableRange<int>(null, 0);
			Assert.True(range.In(-100));
		}

		[Fact]
		public void CheckOpenLeftRange2()
		{
			var range = new NullableRange<int>(null, 0);
			Assert.False(range.In(100));
		}

		[Fact]
		public void CheckOpenLeftRangeWithNull()
		{
			var range = new NullableRange<int>(null, 0);
			Assert.True(range.In(null));
		}

		[Fact]
		public void CheckOpenRightRange()
		{
			var range = new NullableRange<int>(0, null);
			Assert.True(range.In(100));
		}

		[Fact]
		public void CheckOpenRightRange2()
		{
			var range = new NullableRange<int>(0, null);
			Assert.False(range.In(-100));
		}

		[Fact]
		public void CheckOpenRightRangeWithNull()
		{
			var range = new NullableRange<int>(0, null);
			Assert.True(range.In(null));
		}

		[Fact]
		public void CheckOpenRange()
		{
			var range = new NullableRange<int>(null, null);
			Assert.True(range.In(0));
		}

		[Fact]
		public void CheckNullInOpenRange()
		{
			var range = new NullableRange<int>(null, null);
			Assert.True(range.In(null));
		}

		[Fact]
		public void CheckNullInClosedRange()
		{
			var range = new NullableRange<int>(-100, 100);
			Assert.True(range.In(null));
		}

		[Fact]
		public void CheckClosedRange()
		{
			var range = new NullableRange<int>(-100, 100);
			Assert.True(range.In(0));
		}

		[Fact]
		public void LeftOpenRangeIsValid()
		{
			var range = new NullableRange<int>(null, 100);
			Assert.True(range.IsValid);
		}

		[Fact]
		public void RightOpenRangeIsValid()
		{
			var range = new NullableRange<int>(-100, null);
			Assert.True(range.IsValid);
		}

		[Fact]
		public void OpenRangeIsValid()
		{
			var range = new NullableRange<int>();
			Assert.True(range.IsValid);
		}

		[Fact]
		public void ClosedRangeIsValidIfMaxGtMin()
		{
			var range = new NullableRange<int>(-100, 100);
			Assert.True(range.IsValid);
		}

		[Fact]
		public void ClosedRangeIsInvalidIfMinGtMax()
		{
			var range = new NullableRange<int>(100, -100);
			Assert.False(range.IsValid);
		}

		[Fact]
		public void ZeroLengthRangeIsValid()
		{
			var range = new NullableRange<int>(0, 0);
		    Assert.True(range.IsValid);
		}
	}
}