namespace ByndyuSoft.Infrastructure.Common.Extensions
{
    using System;
    using System.Collections.Generic;
	using System.Linq;
    using JetBrains.Annotations;

    /// <summary>
    /// Методы расширения для <see cref="IEnumerable{T}"/>
    /// </summary>
    [UsedImplicitly]
	public static class EnumerableExtensions
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="enumerable"></param>
		/// <param name="item"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static IEnumerable<T> Prepend<T>(this IEnumerable<T> enumerable, T item)
		{
            // TODO: add tests and XMLdoc-comments
			var tmp = new List<T> {item};
			tmp.AddRange(enumerable.Select(x => x));
			return tmp;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="enumerable"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static ICollection<T> ToHashSet<T>(this IEnumerable<T> enumerable)
		{
            // TODO: add tests and XMLdoc-comments
			return new HashSet<T>(enumerable);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="enumerable"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
		{
            // TODO: add tests and XMLdoc-comments
			return enumerable == null || enumerable.Any() == false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="enumerable"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static bool IsNotEmpty<T>(this IEnumerable<T> enumerable)
		{
            // TODO: add tests and XMLdoc-comments
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="accessor"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TSource> DistinctBy<TSource>(this IEnumerable<TSource> enumerable, Func<TSource, object> accessor)
        {
            // TODO: add tests and XMLdoc-comments
            return enumerable
                .Distinct(new PropertyEqualityComparer<TSource>(accessor));
        }

        private class PropertyEqualityComparer<TSource> : IEqualityComparer<TSource>
        {
            private readonly Func<TSource, object> _accessor;

            public PropertyEqualityComparer(Func<TSource, object> accessor)
            {
                _accessor = accessor;
            }

            public bool Equals(TSource x, TSource y)
            {
                return _accessor(x).Equals(_accessor(y));
            }

            public int GetHashCode(TSource obj)
            {
                return _accessor(obj).GetHashCode();
            }
        }
	}
}