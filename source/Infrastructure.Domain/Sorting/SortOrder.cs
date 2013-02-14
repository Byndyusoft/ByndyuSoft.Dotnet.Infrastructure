namespace ByndyuSoft.Infrastructure.Domain.Sorting
{
    using JetBrains.Annotations;

    /// <summary>
    ///   Перечисление, содержащее направления сортировки
    /// </summary>
    [PublicAPI]
    public enum SortOrder
    {
        /// <summary>
        ///   Сортировка по возрастанию
        /// </summary>
        [PublicAPI]
        Asc = 1,

        /// <summary>
        ///   Сортировка по убыванию
        /// </summary>
        [PublicAPI]
        Desc = 2
    }
}