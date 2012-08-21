using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace ByndyuSoft.Infrastructure.NHibernate.Conventions
{
	public class ColumnNameUpperCaseConvention : IPropertyConvention
	{
		public void Apply(IPropertyInstance instance)
		{
			var name = NameConventions.ReplaceCamelCaseWithUnderscore(instance.Name);

			instance.Column(name.ToUpper());
		}
	}
}