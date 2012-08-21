using System;
using System.Linq;
using ByndyuSoft.Infrastructure.Domain;
using NHibernate.Linq;

namespace ByndyuSoft.Infrastructure.NHibernate
{
	public class NHibernateLinqProvider : ILinqProvider
	{
		private readonly ISessionProvider sessionProvider;

		public NHibernateLinqProvider(ISessionProvider sessionProvider)
		{
			this.sessionProvider = sessionProvider;
		}

		public IQueryable<T> Query<T>()
		{
			return sessionProvider.CurrentSession.Query<T>();
		}
	}
}