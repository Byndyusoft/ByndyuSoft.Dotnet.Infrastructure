namespace ByndyuSoft.Infrastructure.Common
{
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;

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
	}
}