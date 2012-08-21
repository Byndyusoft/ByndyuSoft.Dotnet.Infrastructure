using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ByndyuSoft.Infrastructure.Common
{
    public static class PagedEnumerable
    {
        public static IPagedEnumerable<T> From<T>(IEnumerable<T> inner, int totalCount)
        {
            return new PagedEnumerableImpl<T>(inner, totalCount);
        }

        public static IPagedEnumerable<T> Empty<T>()
        {
            return From(Enumerable.Empty<T>(), 0);
        }

        #region Nested type: PagedEnumerableImpl

        private class PagedEnumerableImpl<T> : IPagedEnumerable<T>
        {
            private readonly IEnumerable<T> inner;
            private readonly int totalCount;

            public PagedEnumerableImpl(IEnumerable<T> inner, int totalCount)
            {
                this.inner = inner;
                this.totalCount = totalCount;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return inner.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public int TotalCount
            {
                get { return totalCount; }
            }
        }

        #endregion
    }
}