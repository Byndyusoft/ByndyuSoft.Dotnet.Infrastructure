namespace ByndyuSoft.Infrastructure.Common.Extensions
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Linq;
	using System.Reflection;
	using JetBrains.Annotations;

	///<summary>
	/// Методы расширения для перечислений
	///</summary>
	public static class EnumExtensions
	{
		/// <summary>
		/// Взять значение атрибута Description
		/// </summary>
		/// <param name="member">элемент перечисления</param>
		/// <returns></returns>
		[CanBeNull]
		public static string GetDescription(this Enum member)
		{
			if (member.GetType().GetTypeInfo().IsEnum == false)
				throw new ArgumentOutOfRangeException("member", "member is not enum");

			FieldInfo fieldInfo = member.GetType().GetTypeInfo().GetField(member.ToString());

			if (fieldInfo == null)
				return null;

			DescriptionAttribute[] attributes = fieldInfo.GetCustomAttributes<DescriptionAttribute>(false);

			if (attributes.Length > 0)
				return attributes[0].Description;

			return member.ToString();
		}

		/// <summary>
		/// Создать список из перечисления
		/// </summary>
		public static IEnumerable<KeyValuePair<int, string>> ToKeyValuePairs<TEnum>() where TEnum : struct, IConvertible
		{
			if (typeof (TEnum).GetTypeInfo().IsEnum == false)
				throw new ArgumentException("TEnum must be an enumerated type");

			List<KeyValuePair<int, string>> items = Enum.GetValues(typeof (TEnum))
				.Cast<Enum>()
				.Select(x => new KeyValuePair<int, string>(int.Parse(x.ToString("D")), x.GetDescription()))
				.ToList();

			return items;
		}
	}
}