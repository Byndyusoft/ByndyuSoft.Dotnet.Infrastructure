using System;
using FluentNHibernate.Mapping;
using ByndyuSoft.Infrastructure.Domain;

namespace ByndyuSoft.Infrastructure.NHibernate.Mappings
{
	///<summary>
	/// Предоставляет базовый мапинг для <see cref="TEntity"/>
	///</summary>
	///<typeparam name="TEntity">Тип сущности, должен реализовать интерфейс <see cref="IEntity"/></typeparam>
	public abstract class EntityMap<TEntity> : ClassMap<TEntity> where TEntity : class, IEntity
	{
		protected EntityMap()
		{
// ReSharper disable DoNotCallOverridableMethodsInConstructor
			Id(x => x.Id);
// ReSharper restore DoNotCallOverridableMethodsInConstructor

			DynamicInsert();
			DynamicUpdate();
		}
	}
}