namespace Infrastructure.Dapper.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    using ByndyuSoft.Infrastructure.Dapper;
    using ByndyuSoft.Infrastructure.Dapper.Criteria;
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.Domain.Criteria;

    using Infrastructure.Dapper.Tests.Dto;

    using NUnit.Framework;

    using QueryObject;

    public class InMemoryTestFixtureBase
    {
        private IConnectionProvider connectionProvider;
        private IQueryBuilder queryBuilder;

        protected IDapperRepository<Product> DapperRepository { get; private set; }

        [SetUp]
        public void Setup()
        {
            connectionProvider = new DefaultDapperConnectionProvider(new SqliteConnectionFactory());
            queryBuilder = new QueryBuilderStub(connectionProvider);
            DapperRepository = new DapperRepository<Product>(queryBuilder);

            queryBuilder.For<bool>().With(new CreateProductTable());
        }

        [TearDown]
        public void TearDown()
        {
            queryBuilder.For<bool>().With(new RemoveEntity(null));
            queryBuilder.For<bool>().With(new DropProductTable());
            connectionProvider.Dispose();
        }
    }

    public class QueryBuilderStub : IQueryBuilder
    {
        private readonly IConnectionProvider provider;

        public QueryBuilderStub(IConnectionProvider provider)
        {
            this.provider = provider;
        }

        public IQueryFor<TResult> For<TResult>()
        {
            return new QueryForStub<TResult>(provider);
        }
    }

    public class QueryForStub<TResult> : IQueryFor<TResult>
    {
        private readonly IConnectionProvider provider;

        public QueryForStub(IConnectionProvider provider)
        {
            this.provider = provider;
        }

        public TResult With<TCriterion>(TCriterion criterion)
            where TCriterion : ICriterion
        {
            var resultType = typeof(TResult);
            var criterionType = typeof(TCriterion);
            object result = default(TResult);

            if (ReferenceEquals(resultType, typeof(IEnumerable<Product>)))
                result = new SelectAllProductsQuery(this.provider).Ask(criterion as AllEntities);

            if (ReferenceEquals(resultType, typeof(Product))
                && ReferenceEquals(criterionType, typeof(FindById)))
                result = new SelectProductByIdQuery(this.provider).Ask(criterion as FindById);

            if (ReferenceEquals(resultType, typeof(Product))
                && ReferenceEquals(criterionType, typeof(InsertEntity)))
                result = new InsertProductQuery(this.provider).Ask(criterion as InsertEntity);

            if (ReferenceEquals(resultType, typeof(bool))
                && ReferenceEquals(criterionType, typeof(RemoveEntity)))
                result = new DeleteAllProductsQuery(this.provider).Ask(criterion as RemoveEntity);

            if (ReferenceEquals(resultType, typeof(bool))
                && ReferenceEquals(criterionType, typeof(UpdateEntity)))
                result = new UpdateProductNameQuery(this.provider).Ask(criterion as UpdateEntity);

            if (ReferenceEquals(resultType, typeof(bool))
                && ReferenceEquals(criterionType, typeof(CreateProductTable)))
                result = new CreateProductTableQuery(this.provider).Ask(criterion as CreateProductTable);

            if (ReferenceEquals(resultType, typeof(bool))
                && ReferenceEquals(criterionType, typeof(DropProductTable)))
                result = new DropProductTableQuery(this.provider).Ask(criterion as DropProductTable);

            return (TResult)result;
        }
    }
}