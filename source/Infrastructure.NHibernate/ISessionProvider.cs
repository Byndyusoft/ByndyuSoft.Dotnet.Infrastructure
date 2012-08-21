using System;
using NHibernate;

namespace ByndyuSoft.Infrastructure.NHibernate
{
	///<summary>
	///</summary>
	public interface ISessionProvider
	{
		///<summary>
		///</summary>
		///<returns></returns>
		ISession CurrentSession { get; }
	}
}