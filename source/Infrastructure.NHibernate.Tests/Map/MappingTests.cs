namespace Infrastructure.NHibernate.Tests.Map
{
    using System;
    using System.Linq;
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.NHibernate.Conventions;
    using ByndyuSoft.Infrastructure.NHibernate.Mappings;
    using TestingServices;
    using Xunit;
    using global::NHibernate;

    public class MappingTests : InMemoryTestFixtureBase<TestTreeClassMap, PrimaryKeyConvention>
    {
        [Fact]
        public void HistoryEntryMustBeCreated()
        {
            var testTreeParent = new TestTreeClass();
            var testTreeChild = new TestTreeClass();

            testTreeParent.AddChild(testTreeChild);
            using (ITransaction tx = Session.BeginTransaction())
            {
                Session.Save(testTreeParent);
                tx.Commit();
            }

            Session.Clear();
            TestTreeClass child;
            TestTreeClass parent;
            using (ITransaction tx = Session.BeginTransaction())
            {
                child = Session.Get<TestTreeClass>(testTreeChild.Id);
                parent = Session.Get<TestTreeClass>(testTreeParent.Id);
                tx.Rollback();
            }
            Assert.NotSame(testTreeParent, parent);
            Assert.NotSame(testTreeChild, child);
            Assert.Equal(1, parent.Children.Count());
            Assert.Equal(child, parent.Children.First());
            Assert.NotEmpty(parent.Descendants.ToList());
            Assert.NotEmpty(child.Ancestors.ToList());
        }

        [Fact]
        public void ClearDescendantsAndAncestorsThenClearParrent()
        {
            var testTreeParent = new TestTreeClass();
            var testTreeChild = new TestTreeClass();
            testTreeParent.AddChild(testTreeChild);
            using (ITransaction tx = Session.BeginTransaction())
            {
                Session.Save(testTreeParent);
                tx.Commit();
            }
            Session.Flush();
            Session.Clear();

            Console.WriteLine("BEFORE CLEAR PARENT");
            using (ITransaction tx = Session.BeginTransaction())
            {
                Session.Get<TestTreeClass>(testTreeChild.Id).ClearParent();
                tx.Commit();
            }
            Session.Flush();
            Session.Clear();
            Console.WriteLine("AFTER CLEAR PARENT");

            TestTreeClass child;
            TestTreeClass parent;
            using (ITransaction tx = Session.BeginTransaction())
            {
                child = Session.Get<TestTreeClass>(testTreeChild.Id);
                parent = Session.Get<TestTreeClass>(testTreeParent.Id);
                tx.Rollback();
            }

            Assert.Equal(0, parent.Children.Count());
            Assert.Equal(0, parent.Descendants.Count());
            Assert.Null(child.Parent);
            Assert.Equal(0, parent.Ancestors.Count());
        }
    }

    public class TestTreeClass : TreeNode<TestTreeClass>, IEntity
    {
        public virtual string Name { get; set; }
        public virtual int Id { get; set; }
    }

    public class TestTreeClassMap : EntityMap<TestTreeClass>
    {
        public TestTreeClassMap()
        {
            Map(x => x.Name)
                .Default("Имя");

            this.TreeMap("TestTreeClass_HIERARCHY");
        }
    }
}