using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace ByndyuSoft.Infrastructure.NHibernate.Conventions
{
	public class PrimaryKeyConvention : IIdConvention
	{
		#region IIdConvention Members

		public void Apply(IIdentityInstance instance)
		{
			string sequenceName = NameConventions.GetSequenceName(instance.EntityType);
			string columnName = NameConventions.GetPrimaryKeyColumnName(instance.EntityType);

			instance.Column(columnName);
			instance.GeneratedBy.Native(paramBuilder => paramBuilder.AddParam("sequence", sequenceName));
		}

		#endregion
	}
}