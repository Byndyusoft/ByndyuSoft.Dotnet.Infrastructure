namespace ByndyuSoft.Infrastructure.Web.Extensions
{
	using System;
	using System.Web.Mvc;

	public static class EnumExtensions
	{
		public static SelectList ToSelectedList<TEnum>() where TEnum : struct, IConvertible
		{
			return new SelectList(Common.Extensions.EnumExtensions.ToKeyValuePairs<TEnum>(), "Key", "Value");
		}
	}
}