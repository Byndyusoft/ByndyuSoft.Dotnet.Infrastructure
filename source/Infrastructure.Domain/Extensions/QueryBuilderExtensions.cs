namespace ByndyuSoft.Infrastructure.Domain.Extensions
{
    using JetBrains.Annotations;

    /// <summary>
    /// </summary>
    [PublicAPI]
    public static class QueryBuilderExtensions
    {
        /// <summary>
        /// </summary>
        /// <param name="queryBuilder"></param>
        /// <param name="criterion"></param>
        /// <typeparam name="TCriterion"></typeparam>
        /// <returns></returns>
        [PublicAPI]
        public static int Count<TCriterion>(this IQueryBuilder queryBuilder, TCriterion criterion)
            where TCriterion : class, ICriterion
        {
            return queryBuilder
                .For<int>()
                .With(criterion);
        }
    }
}