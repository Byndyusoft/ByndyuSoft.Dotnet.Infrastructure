namespace ByndyuSoft.Infrastructure.Common.Extensions
{
	using System.Collections.Generic;
	using System.Linq;

	public static class EnumerableExtensions
	{
		public static IEnumerable<T> Prepend<T>(this IEnumerable<T> enumerable, T item)
		{
			var tmp = new List<T> {item};
			tmp.AddRange(enumerable.Select(x => x));
			return tmp;
		}

		public static ICollection<T> ToHashSet<T>(this IEnumerable<T> enumerable)
		{
			return new HashSet<T>(enumerable);
		}

		public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
		{
			return enumerable == null || enumerable.Any() == false;
		}

		public static bool IsNotEmpty<T>(this IEnumerable<T> enumerable)
		{
			return enumerable != null && enumerable.Any();
		}
	}
}