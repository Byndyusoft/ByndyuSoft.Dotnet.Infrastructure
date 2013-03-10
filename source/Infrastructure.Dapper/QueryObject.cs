namespace ByndyuSoft.Infrastructure.Dapper
{
    using System;
    using JetBrains.Annotations;

    /// <summary>
    ///     Incapsulate SQL and Parameters for Dapper methods
    /// </summary>
    /// <remarks>
    ///     http://www.martinfowler.com/eaaCatalog/queryObject.html
    /// </remarks>
    public class QueryObject
    {
        /// <summary>
        ///     Create QueryObject for <paramref name="sql" /> string only
        /// </summary>
        /// <param name="sql">SQL string</param>
        public QueryObject([NotNull] string sql)
        {
            if (string.IsNullOrEmpty(sql))
                throw new ArgumentNullException("sql");

            Sql = sql;
        }

        /// <summary>
        ///     Create QueryObject for parameterized <paramref name="sql" />
        /// </summary>
        /// <param name="sql">SQL string</param>
        /// <param name="queryParams">Parameter list</param>
        public QueryObject([NotNull] string sql, [CanBeNull] object queryParams) : this(sql)
        {
            QueryParams = queryParams;
        }

        /// <summary>
        ///     SQL string
        /// </summary>
        [NotNull]
        public string Sql { get; private set; }

        /// <summary>
        ///     Parameter list
        /// </summary>
        [CanBeNull]
        public object QueryParams { get; private set; }
    }
}