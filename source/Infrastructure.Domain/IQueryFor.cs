namespace ByndyuSoft.Infrastructure.Domain
{
    using JetBrains.Annotations;

    /// <summary>
    ///     Интерфейс для задания критериев запроса
    /// </summary>
    /// <typeparam name="T">Тип возращаемого запросом значения</typeparam>
    public interface IQueryFor<out T>
    {
        /// <summary>
        ///     Добавить критерии запроса
        /// </summary>
        /// <param name="criterion"></param>
        /// <typeparam name="TCriterion"></typeparam>
        /// <returns></returns>
        [CanBeNull]
        T With<TCriterion>(TCriterion criterion)
            where TCriterion : ICriterion;
    }
}