using System;
using JetBrains.Annotations;
using NHibernate;

namespace ByndyuSoft.Infrastructure.NHibernate
{
	public class StaticSessionProvider : ISessionProvider
	{
		private readonly ISession session;
		private readonly object lockObject = new object();

		public StaticSessionProvider([NotNull] ISession session)
		{
			if (session == null)
				throw new ArgumentNullException("session");

			this.session = session;
		}

		public ISession CurrentSession
		{
			get
			{
				lock (lockObject)
				{
					return session;
				}
			}
		}
	}
}