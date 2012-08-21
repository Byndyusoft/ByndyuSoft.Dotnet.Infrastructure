using System;
using System.Text.RegularExpressions;

namespace ByndyuSoft.Infrastructure.NHibernate.Conventions
{
	public static class NameConventions
	{
		public static string GetTableName(Type type)
		{
			return ReplaceCamelCaseWithUnderscore(type.Name);
		}

		internal static string ReplaceCamelCaseWithUnderscore(string name)
		{
			return Regex.Replace(name, "([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", "$1_").ToUpper();
		}

		public static string GetSequenceName(Type type)
		{
			return string.Format("{0}_SEQ", GetTableName(type));
		}

		public static string GetPrimaryKeyColumnName(Type type)
		{
			return string.Format("{0}_ID", GetTableName(type));
		}
	}
}