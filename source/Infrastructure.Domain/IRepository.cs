namespace ByndyuSoft.Infrastructure.Domain
{
    using System.Collections.Generic;

    /// <summary>
    ///     Интерфейс репозитория
    /// </summary>
    /// <typeparam name="TEntity"> Тип сущности доменной модели </typeparam>
    public interface IRepository<TEntity>
        where TEntity : IEntity
    {
        /// <summary>
        ///     Получить все сущности
        /// </summary>
        /// <returns> Список сущностей </returns>
        IEnumerable<TEntity> All();

        /// <summary>
        ///     Получить сущность по идентификатору. В ряде случаев использование Load более предпочтительно.
        ///     Подробнее http://ayende.com/Blog/archive/2009/04/30/nhibernate-ndash-the-difference-between-get-load-and-querying-by.aspx
        /// </summary>
        /// <param name="id"> Идектификатор сущности </param>
        /// <returns> Сущность с указанным Id, если существует. Иначе - null. </returns>
        TEntity Get(int id);

        /// <summary>
        ///     Сохранить сущность
        /// </summary>
        /// <param name="entity"> Сущность </param>
        void Add(TEntity entity);

        /// <summary>
        ///     Удалить сущность
        /// </summary>
        /// <param name="entity"> Сущность </param>
        void Remove(TEntity entity);
    }
}