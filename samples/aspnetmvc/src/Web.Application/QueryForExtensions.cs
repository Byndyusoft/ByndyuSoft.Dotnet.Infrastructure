namespace MvcSample.Web.Application
{
    using System.Collections.Generic;
    using ByndyuSoft.Infrastructure.Domain;

    public static class QueryForExtensions
    {
        public static IEnumerable<T> All<T>(this IQueryFor<IEnumerable<T>> queryRegions)
        {
            return queryRegions.With(new AllEntities());
        }
    }
}