namespace Infrastructure.Common.Tests
{
    using ByndyuSoft.Infrastructure.Common;
    using NUnit.Framework;

    public class RangeTests
    {
        [Test]
        public void RangeIsValidIfMaxGtMin()
        {
            var range = new Range<int>(-100, 100);
            Assert.True(range.IsValid);
        }

        [Test]
        public void RangeIsInvalidIfMinGtMax()
        {
            var range = new Range<int>(100, -100);
            Assert.False(range.IsValid);
        }

        [Test]
        public void ZeroLengthRangeIsValid()
        {
            var range = new Range<int>(0, 0);
            Assert.True(range.IsValid);
        }
    }
}