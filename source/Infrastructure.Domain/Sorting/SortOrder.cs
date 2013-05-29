namespace ByndyuSoft.Infrastructure.Domain.Sorting
{
    using JetBrains.Annotations;

    /// <summary>
    ///     Sort order enumeration
    /// </summary>
    [PublicAPI]
    public enum SortOrder
    {
        /// <summary>
        ///     Ascending order of sort
        /// </summary>
        [PublicAPI] Asc = 1,

        /// <summary>
        ///     Descending order of sort
        /// </summary>
        [PublicAPI] Desc = 2
    }
}