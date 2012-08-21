using System;
using System.ComponentModel;

namespace ByndyuSoft.Infrastructure.Common.Extensions
{
	/// <summary>
	/// Расширения для конвертации типов
	/// </summary>
	public static class ObjectExtensions
	{
		/// <summary>
		/// Пытается конвертировать объект в тип объекта <paramref name="converted"/>
		/// </summary>
		/// <typeparam name="T">Любой тип</typeparam>
		/// <param name="toConvert">Объект, который будет сконвертирован</param>
		/// <param name="converted">Объект, в который будет происходить конвертация</param>
		/// <returns>True, если конвертация прошла успешно, иначе false</returns>
		public static bool TryConvertInto<T>(this object toConvert, out T converted)
		{
			converted = default(T);

			if (toConvert == null || string.IsNullOrEmpty(toConvert.ToString()))
				return false;

			TypeConverter converter = TypeDescriptor.GetConverter(typeof (T));
			if (converter.IsValid(toConvert))
			{
				try
				{
					converted = (T) converter.ConvertFromInvariantString(toConvert.ToString());
					return true;
				}
				catch
				{
				}
			}
			return false;
		}

		/// <summary>
		/// Пытается конвертировать объект в тип объекта <paramref name="{T}"/>
		/// </summary>
		/// <typeparam name="T">Любой тип</typeparam>
		/// <param name="toConvert">Объект, который будет сконвертирован</param>
		/// <returns>True, если конвертация прошла успешно, иначе false</returns>
		public static T Value<T>(this object toConvert)
		{
			T result;

			if (toConvert == null ||
			    string.IsNullOrEmpty(toConvert.ToString()) ||
			    !toConvert.TryConvertInto(out result))
				return default(T);

			return result;
		}

		/// <summary>
		/// Check is value empty or not
		/// </summary>
		/// <param name="toCheck">Список строк</param>
		/// <returns>True, если список равен null или не содержит элементов, иначе false</returns>
		public static bool IsEmptyObject(this object toCheck)
		{
			return toCheck == null || string.IsNullOrEmpty(toCheck.ToString());
		}
	}
}