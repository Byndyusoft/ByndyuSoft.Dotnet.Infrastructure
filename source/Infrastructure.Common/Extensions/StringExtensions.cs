using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace ByndyuSoft.Infrastructure.Common.Extensions
{
	///<summary>
	/// Класс свойств расширений для коллекций строк
	///</summary>
	public static class StringExtensions
	{
		///<summary>
		/// Объединяет коллекцию строк в одну строку использую разделитель
		///</summary>
		///<param name="source"></param>
		///<param name="separator"></param>
		///<returns></returns>
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
		public static string Join(this StringCollection source, string separator)
		{
			return string.Join(separator, source.Cast<string>());
		}
	}
}