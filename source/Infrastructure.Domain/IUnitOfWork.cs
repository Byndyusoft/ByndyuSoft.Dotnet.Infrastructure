namespace ByndyuSoft.Infrastructure.Domain
{
    using System;

    /// <summary>
    ///     Единица работы
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        ///     Сохранить ВСЕ изменения в базу
        /// </summary>
        void Commit();

        /// <summary>
        ///     Пометить сущность для сохранения в базу
        /// </summary>
        void Save<TEntity>(TEntity entity)
            where TEntity : class, IEntity, new();

        /// <summary>
        ///     Пометить сущность для удаления из базы
        /// </summary>
        void Delete<TEntity>(TEntity entity)
            where TEntity : class, IEntity, new();
    }
}