namespace ByndyuSoft.Infrastructure.Domain.Sorting
{
    /// <summary>
    /// </summary>
    public static class SortOrderExtensions
    {
        /// <summary>
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        public static SortOrder Invert(this SortOrder sortOrder)
        {
            return sortOrder == SortOrder.Asc
                       ? SortOrder.Desc
                       : SortOrder.Asc;
        }

        /// <summary>
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="default"></param>
        /// <returns></returns>
        public static SortOrder Invert(this SortOrder? sortOrder, SortOrder @default = SortOrder.Asc)
        {
            return sortOrder.GetValueOrDefault(@default) == SortOrder.Asc
                       ? SortOrder.Desc
                       : SortOrder.Asc;
        }
    }
}