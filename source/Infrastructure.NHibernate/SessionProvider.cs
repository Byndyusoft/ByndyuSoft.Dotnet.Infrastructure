using System;
using JetBrains.Annotations;
using NHibernate;
using NHibernate.Context;

namespace ByndyuSoft.Infrastructure.NHibernate
{
	///<summary>
	///</summary>
	[UsedImplicitly]
	public class SessionProvider : ISessionProvider
	{
		private readonly ISessionFactory sessionFactory;

		///<summary>
		/// ctor
		///</summary>
		///<param name="sessionFactory"></param>
		public SessionProvider(ISessionFactory sessionFactory)
		{
			this.sessionFactory = sessionFactory;
		}

		public ISession CurrentSession
		{
			get
			{
				if (CurrentSessionContext.HasBind(sessionFactory))
					return sessionFactory.GetCurrentSession();

				throw new InvalidOperationException("Database access logic cannot be used, if session not opened. Implicitly session usage not allowed now. Please open session explicitly through UnitOfWorkFactory.StartLongConversation method");
			}
		}
	}
}