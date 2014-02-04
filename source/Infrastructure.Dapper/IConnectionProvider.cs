namespace ByndyuSoft.Infrastructure.Dapper
{
    using System;
    using System.Data;

    /// <summary>
    /// 
    /// </summary>
    public interface IConnectionProvider: IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        IDbConnection CurrentConnection { get; }
    }
}