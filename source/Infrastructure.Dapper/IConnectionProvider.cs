namespace ByndyuSoft.Infrastructure.Dapper
{
    using System.Data;

    /// <summary>
    /// 
    /// </summary>
    public interface IConnectionProvider
    {
        /// <summary>
        /// 
        /// </summary>
        IDbConnection CurrentConnection { get; }
    }
}