namespace ByndyuSoft.Infrastructure.NHibernate
{
    using System;
    using JetBrains.Annotations;
    using global::NHibernate;
    using global::NHibernate.Context;

    ///<summary>
    ///</summary>
    [UsedImplicitly]
    public class SessionProvider : ISessionProvider
    {
        private readonly ISessionFactory _sessionFactory;

        ///<summary>
        ///  ctor
        ///</summary>
        ///<param name="sessionFactory"> </param>
        public SessionProvider(ISessionFactory sessionFactory)
        {
            this._sessionFactory = sessionFactory;
        }

        #region ISessionProvider Members

        public ISession CurrentSession
        {
            get
            {
                if (CurrentSessionContext.HasBind(_sessionFactory))
                    return _sessionFactory.GetCurrentSession();

                throw new InvalidOperationException(
                    "Database access logic cannot be used, if session not opened. Implicitly session usage not allowed now. Please open session explicitly through UnitOfWorkFactory.StartLongConversation method");
            }
        }

        #endregion
    }
}