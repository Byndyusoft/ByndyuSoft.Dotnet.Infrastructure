namespace ByndyuSoft.Infrastructure.NHibernate
{
    using Domain;
    using JetBrains.Annotations;

    /// <summary>
    ///   Стандартный репозиторий для NHibernate
    /// </summary>
    /// <typeparam name="TEntity"> </typeparam>
    [UsedImplicitly]
    public sealed class NHibernateRepository<TEntity> : NHibernateRepositoryBase<TEntity>
        where TEntity : class, IEntity
    {
        /// <summary>
        ///   Конструктор
        /// </summary>
        /// <param name="sessionProvider"> </param>
        public NHibernateRepository(ISessionProvider sessionProvider)
            : base(sessionProvider)
        {
        }
    }
}