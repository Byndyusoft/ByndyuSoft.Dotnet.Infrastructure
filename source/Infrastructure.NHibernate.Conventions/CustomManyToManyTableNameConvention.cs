using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Inspections;

namespace ByndyuSoft.Infrastructure.NHibernate.Conventions
{
	///<summary>
	/// Соглашение для генерации имен таблиц many-to-many
	///</summary>
	public class CustomManyToManyTableNameConvention : ManyToManyTableNameConvention
	{
		protected override string GetBiDirectionalTableName(IManyToManyCollectionInspector collection, IManyToManyCollectionInspector otherSide)
		{
			return GetTableName(collection.EntityType, otherSide.EntityType);
		}

		protected override string GetUniDirectionalTableName(IManyToManyCollectionInspector collection)
		{
			return GetTableName(collection.EntityType, collection.ChildType);
		}

		private static string GetTableName(Type entityType, Type otherSideType)
		{
			return NameConventions.GetTableName(entityType) + "_" + NameConventions.GetTableName(otherSideType);
		}
	}
}