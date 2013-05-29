namespace ByndyuSoft.Infrastructure.Web.Extensions
{
    using System;
    using System.Web.Mvc;

    /// <summary>
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static SelectList ToSelectedList<TEnum>() 
            where TEnum : struct, IConvertible
        {
            return new SelectList(Common.Extensions.EnumExtensions.ToKeyValuePairs<TEnum>(), "Key", "Value");
        }
    }
}