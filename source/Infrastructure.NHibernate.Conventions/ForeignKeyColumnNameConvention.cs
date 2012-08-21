using System;
using FluentNHibernate;
using FluentNHibernate.Conventions;

namespace ByndyuSoft.Infrastructure.NHibernate.Conventions
{
	public class ForeignKeyColumnNameConvention : ForeignKeyConvention
	{
		protected override string GetKeyName(Member member, Type type)
		{
			string name = NameConventions.ReplaceCamelCaseWithUnderscore(member == null ? type.Name : member.Name);

			return string.Format("{0}_ID", name.ToUpper());
		}
	}
}