using System;

namespace ByndyuSoft.Infrastructure.Domain
{
	///<summary>
	/// Единица работы
	///</summary>
	public interface IUnitOfWork : IDisposable
	{
		///<summary>
		/// Сохранить ВСЕ изменения в базу
		///</summary>
		void Commit();

		/// <summary>
		/// Пометить сущность для сохранения в базу
		/// </summary>
		void Save<TEntity>(TEntity entity) where TEntity : IEntity;

		/// <summary>
		/// Пометить сущность для удаления из базы
		/// </summary>
		void Delete<TEntity>(TEntity entity) where TEntity : IEntity;
	}
}