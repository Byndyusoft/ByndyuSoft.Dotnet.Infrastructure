namespace ByndyuSoft.Infrastructure.Domain.Extensions
{
    /// <summary>
    /// </summary>
    public static class QueryBuilderExtensions
    {
        /// <summary>
        /// </summary>
        /// <param name="queryBuilder"></param>
        /// <param name="criterion"></param>
        /// <typeparam name="TCriterion"></typeparam>
        /// <returns></returns>
        public static int Count<TCriterion>(this IQueryBuilder queryBuilder, TCriterion criterion)
            where TCriterion : class, ICriterion
        {
            return queryBuilder
                .For<int>()
                .With(criterion);
        }
    }
}