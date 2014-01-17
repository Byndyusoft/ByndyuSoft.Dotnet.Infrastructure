namespace Mvc4Sample.Web.Application.Infrastructure
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Helpers;

    public static class AnyQueriesExtensions
    {
        public static IOrderedQueryable<T> Page<T>(this IOrderedQueryable<T> query, int page, int countOnPage)
        {
            return (IOrderedQueryable<T>) query.Skip(countOnPage*(page - 1)).Take(countOnPage);
        }

        public static IOrderedQueryable<T> Order<T, TKey>(this IQueryable<T> query, Expression<Func<T, TKey>> keySelector, SortDirection sortDirection)
        {
            return sortDirection == SortDirection.Descending ? query.OrderByDescending(keySelector) : query.OrderBy(keySelector);
        }

        public static IOrderedQueryable<T> Then<T, TKey>(this IOrderedQueryable<T> query, Expression<Func<T, TKey>> keySelector, SortDirection sortDirection)
        {
            return sortDirection == SortDirection.Descending ? query.ThenByDescending(keySelector) : query.ThenBy(keySelector);
        }
    }
}