using System;
using System.Reflection;

namespace ByndyuSoft.Infrastructure.Common.Extensions
{
	/// <summary>
	/// Методы расширения для <see cref="ICustomAttributeProvider"/>
	/// </summary>
	public static class CustomAttributeProviderExtensions
	{
		///<summary>
		/// Строготипизированная версия метода GetCustomAttributes
		///</summary>
		///<param name="attributeProvider"></param>
		///<param name="inherit"></param>
		///<typeparam name="T"></typeparam>
		///<returns></returns>
		public static T[] GetCustomAttributes<T>(this ICustomAttributeProvider attributeProvider, bool inherit) where T : Attribute
		{
			return (T[])attributeProvider.GetCustomAttributes(typeof(T), inherit);
		}
	}
}