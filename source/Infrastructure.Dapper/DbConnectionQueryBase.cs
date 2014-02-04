namespace ByndyuSoft.Infrastructure.Dapper
{
    using System.Data;

    using ByndyuSoft.Infrastructure.Domain;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TCriterion"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public abstract class DbConnectionQueryBase<TCriterion, TResult> : IQuery<TCriterion, TResult>
        where TCriterion : ICriterion
    {
        private readonly IConnectionProvider _connectionProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionProvider"></param>
        protected DbConnectionQueryBase(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        protected IDbConnection Connection
        {
            get
            {
                return _connectionProvider.CurrentConnection;
            }
        }

        public abstract TResult Ask(TCriterion criterion);
    }
}