namespace ByndyuSoft.Infrastructure.Common.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///     Various extension methods for converting data from/to base64 encoding.
    /// </summary>
    public static class Base64Extensions
    {
        /// <summary>
        ///     Converts binary data to base64 representation.
        /// </summary>
        /// <param name="bytes">Binary data to convert.</param>
        /// <returns>Base64-encoded string.</returns>
        public static string ToBase64(this IEnumerable<byte> bytes)
        {
            return Convert.ToBase64String(bytes.ToArray());
        }

        /// <summary>
        ///     Decodes base64-encoded string into binary data.
        /// </summary>
        /// <param name="string">Base64-encoded string.</param>
        /// <returns>Binary data encoded in specified string.</returns>
        public static IEnumerable<byte> FromBase64(this string @string)
        {
            return Convert.FromBase64String(@string);
        }
    }
}