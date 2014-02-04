namespace ByndyuSoft.Infrastructure.Dapper
{
    using System;
    using System.Data;

    /// <summary>
    /// 
    /// </summary>
    public class DefaultDapperConnectionProvider : IConnectionProvider
    {
        private readonly IConnectionFactory _connectionFactory;
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool _disposed;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionFactory"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public DefaultDapperConnectionProvider(IConnectionFactory connectionFactory)
        {
            if (connectionFactory == null)
            {
                throw new ArgumentNullException("connectionFactory");
            }

            _connectionFactory = connectionFactory;
        }

        public IDbConnection CurrentConnection
        {
            get
            {
                if (_connection != null)
                {
                    return _connection;
                }

                _connection = _connectionFactory.Create();
                _transaction = _connection.BeginTransaction();

                return _connection;
            }
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            if (_connection == null)
            {
                return;
            }

            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
            }

            _connection.Dispose();
            _connection = null;
            _transaction = null;
            _disposed = true;
        }
    }
}