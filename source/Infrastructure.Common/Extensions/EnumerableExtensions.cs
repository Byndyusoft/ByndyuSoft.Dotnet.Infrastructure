namespace ByndyuSoft.Infrastructure.Common.Extensions
{
	using System.Collections.Generic;
	using System.Linq;
    using JetBrains.Annotations;

    /// <summary>
    /// Методы расширения для <see cref="IEnumerable{T}"/>
    /// </summary>
    [UsedImplicitly]
	public static class EnumerableExtensions
	{
		public static IEnumerable<T> Prepend<T>(this IEnumerable<T> enumerable, T item)
		{
            // TODO: add test and XML-comments
			var tmp = new List<T> {item};
			tmp.AddRange(enumerable.Select(x => x));
			return tmp;
		}

		public static ICollection<T> ToHashSet<T>(this IEnumerable<T> enumerable)
		{
            // TODO: add test and XML-comments
			return new HashSet<T>(enumerable);
		}

		public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
		{
            // TODO: add test and XML-comments
			return enumerable == null || enumerable.Any() == false;
		}

		public static bool IsNotEmpty<T>(this IEnumerable<T> enumerable)
		{
            // TODO: add test and XML-comments
			return enumerable != null && enumerable.Any();
		}

        /// <summary>
        /// Преобразовать перечисление в массив
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        [NotNull]
        public static T[] AsArray<T>([CanBeNull] this IEnumerable<T> source)
        {
            return source != null
                ? (source as T[] ?? source.ToArray())
                : new T[0];
        }
	}
}