namespace Infrastructure.Common.Tests
{
    using ByndyuSoft.Infrastructure.Common;
    using NUnit.Framework;

    public class NullableRangeTests
    {
        [Test]
        public void CheckOpenLeftRange()
        {
            var range = new NullableRange<int>(null, 0);
            Assert.True(range.In(-100));
        }

        [Test]
        public void CheckOpenLeftRange2()
        {
            var range = new NullableRange<int>(null, 0);
            Assert.False(range.In(100));
        }

        [Test]
        public void CheckOpenLeftRangeWithNull()
        {
            var range = new NullableRange<int>(null, 0);
            Assert.True(range.In(null));
        }

        [Test]
        public void CheckOpenRightRange()
        {
            var range = new NullableRange<int>(0, null);
            Assert.True(range.In(100));
        }

        [Test]
        public void CheckOpenRightRange2()
        {
            var range = new NullableRange<int>(0, null);
            Assert.False(range.In(-100));
        }

        [Test]
        public void CheckOpenRightRangeWithNull()
        {
            var range = new NullableRange<int>(0, null);
            Assert.True(range.In(null));
        }

        [Test]
        public void CheckOpenRange()
        {
            var range = new NullableRange<int>(null, null);
            Assert.True(range.In(0));
        }

        [Test]
        public void CheckNullInOpenRange()
        {
            var range = new NullableRange<int>(null, null);
            Assert.True(range.In(null));
        }

        [Test]
        public void CheckNullInClosedRange()
        {
            var range = new NullableRange<int>(-100, 100);
            Assert.True(range.In(null));
        }

        [Test]
        public void CheckClosedRange()
        {
            var range = new NullableRange<int>(-100, 100);
            Assert.True(range.In(0));
        }

        [Test]
        public void LeftOpenRangeIsValid()
        {
            var range = new NullableRange<int>(null, 100);
            Assert.True(range.IsValid);
        }

        [Test]
        public void RightOpenRangeIsValid()
        {
            var range = new NullableRange<int>(-100, null);
            Assert.True(range.IsValid);
        }

        [Test]
        public void OpenRangeIsValid()
        {
            var range = new NullableRange<int>();
            Assert.True(range.IsValid);
        }

        [Test]
        public void ClosedRangeIsValidIfMaxGtMin()
        {
            var range = new NullableRange<int>(-100, 100);
            Assert.True(range.IsValid);
        }

        [Test]
        public void ClosedRangeIsInvalidIfMinGtMax()
        {
            var range = new NullableRange<int>(100, -100);
            Assert.False(range.IsValid);
        }

        [Test]
        public void ZeroLengthRangeIsValid()
        {
            var range = new NullableRange<int>(0, 0);
            Assert.True(range.IsValid);
        }
    }
}