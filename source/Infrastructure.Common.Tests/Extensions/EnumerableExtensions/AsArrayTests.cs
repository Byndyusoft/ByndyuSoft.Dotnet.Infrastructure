namespace Infrastructure.Common.Tests.Extensions.EnumerableExtensions
{
    using System.Collections.Generic;
    using System.Linq;
    using ByndyuSoft.Infrastructure.Common.Extensions;
    using NUnit.Framework;

    public class AsArrayTests
    {
        [Test]
        public void ConvertListToArray()
        {
            IEnumerable<int> enumerable = new List<int> {1, 2};

            int[] result = enumerable.AsArray();

            Assert.AreEqual(2, result.Length);
        }

        [Test]
        public void IfPassNullThenReturnEmptyArray()
        {
            int[] result = ((IEnumerable<int>) null).AsArray();

            Assert.AreEqual(0, result.Length);
        }

        [Test]
        public void ConvertIEnumerableToArray()
        {
            var list = new List<int> {1, 2};
            IEnumerable<int> enumerable = list.Where(x => x > 0).AsEnumerable();

            int[] result = enumerable.AsArray();

            Assert.AreEqual(2, result.Length);
        }
    }
}