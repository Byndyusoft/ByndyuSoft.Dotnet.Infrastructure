namespace Infrastructure.NHibernate.Tests.Query
{
    using System.Linq;
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.Domain.Criterion;
    using ByndyuSoft.Infrastructure.Domain.Extensions;
    using ByndyuSoft.Infrastructure.NHibernate;
    using ByndyuSoft.Infrastructure.NHibernate.Conventions;
    using ByndyuSoft.Infrastructure.NHibernate.Mappings;
    using NUnit.Framework;
    using TestingServices;
    using global::NHibernate;
    using global::NHibernate.Linq;

    public class QueryTests : InMemoryTestFixtureBase<TestClassMap, PrimaryKeyConvention>
    {
        [Test]
        public void All()
        {
            var test1 = new TestClass();
            var test2 = new TestClass();

            using (var tx = Session.BeginTransaction())
            {
                Session.Save(test1);
                Session.Save(test2);
                tx.Commit();
            }
            Session.Flush();
            Session.Clear();

            using (var tx = Session.BeginTransaction())
            {
                ILinqProvider linqProvider = new StubLinqProvider(Session);
                IQueryFactory queryFactory = new QueryFactoryStub(linqProvider);

                var result = new QueryFor<IQueryable<TestClass>>(queryFactory).All();

                Assert.AreEqual(2, result.Count());
            }
        }
    }

    public class QueryFactoryStub : IQueryFactory
    {
        private readonly ILinqProvider _linqProvider;

        public QueryFactoryStub(ILinqProvider linqProvider)
        {
            _linqProvider = linqProvider;
        }

        public IQuery<TCriterion, TResult> Create<TCriterion, TResult>() where TCriterion : ICriterion
        {
            return (IQuery<TCriterion, TResult>) new QueryStub(_linqProvider);
        }
    }

    public class QueryStub : LinqQueryBase<TestClass, AllEntities, IQueryable<TestClass>>
    {
        public QueryStub(ILinqProvider linq)
            : base(linq)
        {
        }

        public override IQueryable<TestClass> Ask(AllEntities criterion)
        {
            return Query;
        }
    }

    public class StubLinqProvider : ILinqProvider
    {
        private readonly ISession session;

        public StubLinqProvider(ISession session)
        {
            this.session = session;
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntity, new()
        {
            return session.Query<TEntity>();
        }
    }

    public class TestClass : IEntity
    {
        public virtual string Name { get; set; }
        public virtual int Id { get; set; }
    }

    public class TestClassMap : EntityMap<TestClass>
    {
        public TestClassMap()
        {
            Map(x => x.Name)
                .Default("Имя");
        }
    }
}