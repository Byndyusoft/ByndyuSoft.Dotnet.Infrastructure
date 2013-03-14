namespace ByndyuSoft.Infrastructure.Dapper
{
    using System.Collections.Generic;
    using System.Linq;

    using ByndyuSoft.Infrastructure.Dapper.Criteria;
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.Domain.Extensions;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class DapperRepositoryBase<TEntity> : IDapperRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly IQueryBuilder query;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        protected DapperRepositoryBase(IQueryBuilder query)
        {
            this.query = query;
        }

        public IEnumerable<TEntity> All()
        {
            return (query.For<IEnumerable<TEntity>>()
                        .All() ?? Enumerable.Empty<TEntity>())
                .ToArray();
        }

        public TEntity Get(int id)
        {
            return query.For<TEntity>()
                .ById(id);
        }

        public void Add(TEntity entity)
        {
            query.For<TEntity>()
                .With(new InsertEntity(entity));
        }

        public void Remove(TEntity entity)
        {
            query.For<bool>()
                .With(new RemoveEntity(entity));
        }

        public void AddOrUpdate(TEntity entity)
        {
            if (Get(entity.Id) == null)
            {
                Add(entity);
            }
            else
            {
                query.For<bool>()
                    .With(new UpdateEntity(entity));
            }
        }
    }
}