namespace Infrastructure.Common.Tests.Extensions.EnumerableExtensions
{
    using System.Collections.Generic;
    using System.Linq;
    using ByndyuSoft.Infrastructure.Common.Extensions;
    using Xunit;

    public class AsArrayTests
    {
        [Fact]
        public void ConvertListToArray()
        {
            IEnumerable<int> enumerable = new List<int> {1, 2};

            int[] result = enumerable.AsArray();

            Assert.Equal(2, result.Length);
        }

        [Fact]
        public void IfPassNullThenReturnEmptyArray()
        {
            int[] result = ((IEnumerable<int>) null).AsArray();

            Assert.Equal(0, result.Length);
        }

        [Fact]
        public void ConvertIEnumerableToArray()
        {
            var list = new List<int> {1, 2};
            IEnumerable<int> enumerable = list.Where(x => x > 0).AsEnumerable();
            
            int[] result = enumerable.AsArray();

            Assert.Equal(2, result.Length);
        }
    }
}