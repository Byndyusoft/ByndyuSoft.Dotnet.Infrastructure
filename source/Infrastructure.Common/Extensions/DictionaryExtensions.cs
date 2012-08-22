using System;
using System.Collections.Generic;

namespace ByndyuSoft.Infrastructure.Common.Extensions
{
	///<summary>
	/// Методы расширения для <see cref="IDictionary{TKey,TValue}"/>
	///</summary>
	public static class DictionaryExtensions
	{
		/// <summary>
		/// Метод получения значения из словаря
		/// </summary>
		/// <typeparam name="TKey">Тип ключа</typeparam>
		/// <typeparam name="TValue">Тип значения</typeparam>
		/// <param name="dictionary">словарь</param>
		/// <param name="key">ключ</param>
		/// <returns>значение из словаря или значения по умолчанию, если ключ не найден в словаре</returns>
		public static TValue Get<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
		{
			TValue result;
		    dictionary.TryGetValue(key, out result);
		    return result;
		}

		/// <summary>
		/// Метод получения значения из словаря
		/// </summary>
		/// <typeparam name="TKey">Тип ключа</typeparam>
		/// <typeparam name="TValue">Тип значения</typeparam>
		/// <param name="dictionary">словарь</param>
		/// <param name="key">ключ</param>
		/// <param name="defaultValue">значение по умолчанию</param>
		/// <returns>значение из словаря или значения по умолчанию, если ключ не найден в словаре</returns>
		public static TValue Get<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
		{
			TValue result;
			return dictionary.TryGetValue(key, out result) ? result : defaultValue;
		}

		/// <summary>
		/// Метод получения значения из словаря
		/// </summary>
		/// <typeparam name="TKey">Тип ключа</typeparam>
		/// <typeparam name="TValue">Тип значения</typeparam>
		/// <param name="dictionary">словарь</param>
		/// <param name="key">ключ</param>
		/// <param name="defaultValue">Делегат для получения значения по умолчанию</param>
		/// <returns>значение из словаря или значения по умолчанию, если ключ не найден в словаре</returns>
		public static TValue Get<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> defaultValue)
		{
			TValue result;
			return dictionary.TryGetValue(key, out result) ? result : defaultValue();
		}
	}
}