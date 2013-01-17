namespace Infrastructure.NHibernate.Tests.Map
{
    using System;
    using System.Linq;
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.NHibernate.Conventions;
    using ByndyuSoft.Infrastructure.NHibernate.Mappings;
    using NUnit.Framework;
    using TestingServices;
    using global::NHibernate;

    public class MappingTests : InMemoryTestFixtureBase<TestTreeClassMap, PrimaryKeyConvention>
    {
        [Test]
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
            Assert.AreNotSame(testTreeParent, parent);
            Assert.AreNotSame(testTreeChild, child);
            Assert.AreEqual(1, parent.Children.Count());
            Assert.AreEqual(child, parent.Children.First());
            Assert.IsNotEmpty(parent.Descendants.ToList());
            Assert.IsNotEmpty(child.Ancestors.ToList());
        }

        [Test]
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

            Assert.AreEqual(0, parent.Children.Count());
            Assert.AreEqual(0, parent.Descendants.Count());
            Assert.Null(child.Parent);
            Assert.AreEqual(0, parent.Ancestors.Count());
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