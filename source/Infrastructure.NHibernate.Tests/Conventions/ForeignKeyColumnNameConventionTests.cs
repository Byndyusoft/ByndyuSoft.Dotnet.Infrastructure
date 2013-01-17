namespace Infrastructure.NHibernate.Tests.Conventions
{
    using ByndyuSoft.Infrastructure.NHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;
    using FluentNHibernate.MappingModel;
    using Moq;
    using NUnit.Framework;

    public class ForeignKeyColumnNameConventionTests
    {
        [Test]
        public void UpperCase()
        {
            var mockPropertyInstance = new Mock<IManyToOneInstance>();

            mockPropertyInstance.Setup(instance => instance.Class).Returns(new TypeReference(GetType()));

            new ForeignKeyColumnNameConvention().Apply(mockPropertyInstance.Object);

            mockPropertyInstance.Verify(instance => instance.Column("FOREIGN_KEY_COLUMN_NAME_CONVENTION_TESTS_ID"));
        }
    }
}