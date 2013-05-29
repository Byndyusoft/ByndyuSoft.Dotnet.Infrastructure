namespace ByndyuSoft.Infrastructure.Domain.Criteria
{
    /// <summary>
    ///     Критерий для поиска по идентификатору
    /// </summary>
    public class FindById : ICriterion
    {
        internal FindById(int id)
        {
            Id = id;
        }

        /// <summary>
        ///     Идентификатор доменной сущности
        /// </summary>
        public int Id { get; private set; }
    }
}