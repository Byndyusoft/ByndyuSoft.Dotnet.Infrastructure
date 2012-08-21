using System;
using System.Data;
using ByndyuSoft.Infrastructure.Domain;
using NHibernate;

namespace ByndyuSoft.Infrastructure.NHibernate
{
	///<summary>
	///</summary>
	public class NHibernateUnitOfWorkFactory : IUnitOfWorkFactory
	{
		private readonly ISessionFactory sessionSessionFactory;

		///<summary>
		/// ctor
		///</summary>
		///<param name="sessionFactory"></param>
		public NHibernateUnitOfWorkFactory(ISessionFactory sessionFactory)
		{
			sessionSessionFactory = sessionFactory;
		}

	    public IUnitOfWork Create(IsolationLevel isolationLevel)
	    {
	        return new NHibernateUnitOfWork(sessionSessionFactory.OpenSession(), isolationLevel);
	    }

		public IUnitOfWork Create()
		{
			return Create(IsolationLevel.ReadCommitted);
		}
	}
}