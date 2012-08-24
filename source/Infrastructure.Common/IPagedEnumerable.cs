namespace ByndyuSoft.Infrastructure.Common
{
	using System.Collections.Generic;

	public interface IPagedEnumerable<out T> : IEnumerable<T>
	{
		int TotalCount { get; }
	}
}