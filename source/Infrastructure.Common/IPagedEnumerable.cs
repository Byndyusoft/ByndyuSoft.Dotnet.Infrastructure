namespace ByndyuSoft.Infrastructure.Common
{
	using System.Collections.Generic;

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IPagedEnumerable<out T> : IEnumerable<T>
	{
	    /// <summary>
	    ///     Total number of entries across all pages.
	    /// </summary>
	    int TotalCount { get; }
	}
}