using System;
using System.Data;

namespace ByndyuSoft.Infrastructure.Domain
{
	///<summary>
	/// Фабрика uow
	///</summary>
	public interface IUnitOfWorkFactory
	{
	    ///<summary>
		/// Создает uow, если у uow не будет вызван метод <see cref="IUnitOfWork.Commit"/>, то автоматически будет выполнен rollback
		///</summary>
		///<param name="isolationLevel"></param>
		///<returns></returns>
		IUnitOfWork Create(IsolationLevel isolationLevel);
		///<summary>
		/// Создает uow, если у uow не будет вызван метод <see cref="IUnitOfWork.Commit"/>, то автоматически будет выполнен rollback
		///</summary>
		///<returns></returns>
		IUnitOfWork Create();
	}
}