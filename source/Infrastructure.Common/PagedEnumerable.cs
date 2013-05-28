namespace ByndyuSoft.Infrastructure.Common
{
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;

	/// <summary>
	/// 
	/// </summary>
	public static class PagedEnumerable
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="inner"></param>
		/// <param name="totalCount"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static IPagedEnumerable<T> From<T>(IEnumerable<T> inner, int totalCount)
		{
			return new PagedEnumerableImpl<T>(inner, totalCount);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static IPagedEnumerable<T> Empty<T>()
		{
			return From(Enumerable.Empty<T>(), 0);
		}

		private class PagedEnumerableImpl<T> : IPagedEnumerable<T>
		{
			private readonly IEnumerable<T> _inner;
			private readonly int _totalCount;

			public PagedEnumerableImpl(IEnumerable<T> inner, int totalCount)
			{
				_inner = inner;
				_totalCount = totalCount;
			}

			public IEnumerator<T> GetEnumerator()
			{
				return _inner.GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}

			public int TotalCount
			{
				get { return _totalCount; }
			}
		}
	}
}