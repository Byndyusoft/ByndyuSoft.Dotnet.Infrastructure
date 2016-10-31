namespace ByndyuSoft.Infrastructure.Common.Extensions
{
    using System;
    using System.Collections.Generic;
	using System.Collections.Specialized;
	using System.Linq;
    using JetBrains.Annotations;

	///<summary>
	/// Класс свойств расширений для коллекций строк
	///</summary>
	[PublicAPI]
	public static class StringExtensions
	{
		///<summary>
		/// Объединяет коллекцию строк в одну строку использую разделитель
		///</summary>
		///<param name="source"></param>
		///<param name="separator"></param>
		///<returns></returns>
        [PublicAPI]
		public static string Join(this IEnumerable<string> source, string separator)
		{
			return string.Join(separator, source);
		}

		///<summary>
		/// Объединяет коллекцию строк в одну строку использую разделитель
		///</summary>
		///<param name="source"></param>
		///<param name="separator"></param>
		///<returns></returns>
        [PublicAPI]
		public static string Join(this StringCollection source, string separator)
		{
			return string.Join(separator, source.Cast<string>());
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="value"></param>
        /// <param name="comparisonType"></param>
        /// <returns></returns>
        [PublicAPI]
        public static bool Contains(this string input, string value, StringComparison comparisonType)
        {
            if (string.IsNullOrEmpty(input) == false)
                return input.IndexOf(value, comparisonType) != -1;

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [PublicAPI]
        public static bool LikewiseContains(this string input, string value)
        {
            return Contains(input, value, StringComparison.OrdinalIgnoreCase);
        }
	}
}