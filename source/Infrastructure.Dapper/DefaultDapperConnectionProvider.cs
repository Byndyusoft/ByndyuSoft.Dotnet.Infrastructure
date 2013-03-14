namespace ByndyuSoft.Infrastructure.Dapper
{
    using System;
    using System.Data;

    using ByndyuSoft.Infrastructure.Common;

    /// <summary>
    /// 
    /// </summary>
    public class DefaultDapperConnectionProvider : Disposable, IConnectionProvider
    {
        private readonly IConnectionFactory connectionFactory;
        private IDbConnection connection;
        private IDbTransaction transaction;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionFactory"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public DefaultDapperConnectionProvider(IConnectionFactory connectionFactory)
        {
            if (connectionFactory == null)
                throw new ArgumentNullException("connectionFactory");

            this.connectionFactory = connectionFactory;
        }

        public IDbConnection CurrentConnection
        {
            get
            {
                if (connection != null)
                    return connection;

                connection = connectionFactory.Create();
                transaction = connection.BeginTransaction();

                return connection;
            }
        }

        protected override void DisposeCore()
        {
            if (connection == null)
                return;

            try
            {
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                transaction.Dispose();
            }

            connection.Dispose();
            connection = null;
            transaction = null;
        }
    }
}