using System;
using FluentNHibernate;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace ByndyuSoft.Infrastructure.NHibernate.Conventions
{
	///<summary>
	/// Соглашение для названий внешнийх ключей
	///</summary>
	public class ForeignKeyConstraintNameConvention : IReferenceConvention, IHasManyToManyConvention, IJoinedSubclassConvention, IJoinConvention, ICollectionConvention
	{
		public void Apply(ICollectionInstance instance)
		{
			string constraint = GetConstraintName(instance.ChildType.Name, instance.EntityType.Name);
			instance.Key.ForeignKey(constraint);
		}

		public void Apply(IManyToManyCollectionInstance instance)
		{
			string childConstraint = GetManyToManyConstraintName(instance.TableName, instance.ChildType.Name);
			instance.Relationship.ForeignKey(childConstraint);

			string childConstraint2 = GetManyToManyConstraintName(instance.TableName, instance.EntityType.Name);
			instance.Key.ForeignKey(childConstraint2);
		}

		private static string GetManyToManyConstraintName(string tableName, string entityName)
		{
			return string.Format("FK_{0}_{1}", NameConventions.ReplaceCamelCaseWithUnderscore(tableName), NameConventions.ReplaceCamelCaseWithUnderscore(entityName)).ToUpper();
		}

		public void Apply(IJoinInstance instance)
		{
			//			Type type = instance.EntityType;
			//			string constraint = GetConstraintName(type.Name, ((Member) null).Name);
			//			instance.Key.ForeignKey(constraint);
		}

		public void Apply(IJoinedSubclassInstance instance)
		{
			//			Type type = instance.Type.BaseType;
			//			string constraint = GetConstraintName(type.Name, ((Member) null).Name);
			//			instance.Key.ForeignKey(constraint);
		}

		public void Apply(IManyToOneInstance instance)
		{
			Type type = instance.EntityType;
			Member member = instance.Property;
			string columnName = GetConstraintName(type.Name, member.Name);
			instance.ForeignKey(columnName);
		}

		private static string GetConstraintName(string child, string parent)
		{
			var constraintName = string.Format("FK_{0}_{1}", NameConventions.ReplaceCamelCaseWithUnderscore(child).ToUpper(), NameConventions.ReplaceCamelCaseWithUnderscore(parent).ToUpper());
			return constraintName;
		}
	}
}