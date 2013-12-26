namespace Infrastructure.SQLinq.Dapper
{
    using System.Data;
    using System.Data.SqlClient;
    using global::SQLinq;

    public static class SqLinqExtensions
    {
        public static int Count<T>(this SQLinq<T> query, IDbConnection connection)
        {
            var queryResult = query.ToSQL();

            queryResult.Select = new[] {"COUNT(*)"};

            var sqlParameters = queryResult.Parameters;

            var sqlCode = queryResult.ToQuery();

            var cmd = new SqlCommand(sqlCode, (SqlConnection) connection);

            foreach (var p in sqlParameters)
            {
                cmd.Parameters.AddWithValue(p.Key, p.Value);
            }

            return (int) cmd.ExecuteScalar();
        }

        public static SQLinq<T> Page<T>(this SQLinq<T> query, int page, int pageSize)
        {
            return query
                .Skip(pageSize*(page - 1))
                .Take(pageSize);
        }
    }
}