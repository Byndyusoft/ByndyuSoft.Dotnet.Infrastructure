namespace ByndyuSoft.Infrastructure.Common
{
	using System;
	using System.Globalization;
	using JetBrains.Annotations;

    /// <summary>
    ///     Check object invariants
    /// </summary>
    public static class Check
	{
		/// <summary>
		/// Check is object null.
		/// </summary>
		/// <param name="obj">Object to check</param>
		/// <param name="paramName">Name of object parameter</param>
		public static void IsNotNull([NotNull] object obj, [InvokerParameterName] string paramName)
		{
			if (obj == null)
			{
				throw new ArgumentNullException(paramName, string.Format(CultureInfo.CurrentCulture, "Parameter {0} is null", paramName));
			}
		}
	}
}