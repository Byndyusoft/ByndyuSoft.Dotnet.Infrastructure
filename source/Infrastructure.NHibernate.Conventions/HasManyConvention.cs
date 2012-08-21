using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace ByndyuSoft.Infrastructure.NHibernate.Conventions
{
	/// <summary>
	/// Конвенция по-умолчанию для one-to-many и many-to-many ассоциаций.
	/// </summary>
	public class HasManyConvention : IHasManyConvention, IHasManyToManyConvention
	{
		public void Apply(IOneToManyCollectionInstance instance)
		{
			instance.Access.ReadOnlyPropertyThroughCamelCaseField();
			instance.Cascade.AllDeleteOrphan();
			instance.AsSet();
			instance.BatchSize(25);
			if (instance.OtherSide == null)
			{
				instance.Not.Inverse();
			}
			else
			{
				instance.Inverse();
			}
			instance.Not.KeyNullable();
		}

		public void Apply(IManyToManyCollectionInstance instance)
		{
			instance.Access.ReadOnlyPropertyThroughCamelCaseField();
			instance.Cascade.SaveUpdate();
			instance.AsSet();
			instance.BatchSize(25);
		}
	}
}