namespace Infrastructure.Dapper.Tests
{
    using System.Collections.Generic;

    using ByndyuSoft.Infrastructure.Dapper;
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.Domain.Criteria;

    using Infrastructure.Dapper.Tests.Dto;

    using NUnit.Framework;

    using QueryObject;

    public class InMemoryTestFixtureBase
    {
        private IConnectionProvider connectionProvider;
        protected IQueryBuilder QueryBuilder;

        [SetUp]
        public void Setup()
        {
            connectionProvider = new DefaultDapperConnectionProvider(new SqliteConnectionFactory());
            QueryBuilder = new QueryBuilderStub(connectionProvider);

            connectionProvider.CurrentConnection.Execute(new CreateProductTable().Query());
        }

        [TearDown]
        public void TearDown()
        {
            connectionProvider.CurrentConnection.Execute(new DeleteProduct().All());
            connectionProvider.CurrentConnection.Execute(new DropProductTable().Query());

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
            {
                result = new SelectAllProductsQuery(this.provider).Ask(criterion as AllEntities);
            }

            if (ReferenceEquals(resultType, typeof(Product))
                && ReferenceEquals(criterionType, typeof(FindById)))
            {
                result = new SelectProductByIdQuery(this.provider).Ask(criterion as FindById);
            }

            if (ReferenceEquals(resultType, typeof(Product))
                && ReferenceEquals(criterionType, typeof(InsertEntity<Product>)))
            {
                result = new InsertProductQuery(this.provider).Ask(criterion as InsertEntity<Product>);
            }

            if (ReferenceEquals(resultType, typeof(bool))
                && ReferenceEquals(criterionType, typeof(DeleteEntity<Product>)))
            {
                result = new DeleteProductQuery(this.provider).Ask(criterion as DeleteEntity<Product>);
            }

            if (ReferenceEquals(resultType, typeof(bool))
                && ReferenceEquals(criterionType, typeof(UpdateEntity<Product>)))
            {
                result = new UpdateNameForAllProductsQuery(this.provider).Ask(criterion as UpdateEntity<Product>);
            }

            return (TResult)result;
        }
    }
}