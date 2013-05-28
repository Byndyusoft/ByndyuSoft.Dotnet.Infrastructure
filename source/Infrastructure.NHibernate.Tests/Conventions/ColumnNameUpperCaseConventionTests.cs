namespace Infrastructure.NHibernate.Tests.Conventions
{
    using ByndyuSoft.Infrastructure.NHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class ColumnNameUpperCaseConventionTests
    {
        [Test]
        public void UpperCase()
        {
            var mockPropertyInstance = new Mock<IPropertyInstance>();
            mockPropertyInstance
                .Setup(x => x.Name)
                .Returns("Test");

            new ColumnNameUpperCaseConvention().Apply(mockPropertyInstance.Object);

            mockPropertyInstance.Verify(x => x.Column("TEST"));
        }

        [Test]
        public void CamelCaseReplacedByUnderscore()
        {
            var mockPropertyInstance = new Mock<IPropertyInstance>();
            mockPropertyInstance
                .Setup(x => x.Name)
                .Returns("CamelCase");

            new ColumnNameUpperCaseConvention().Apply(mockPropertyInstance.Object);

            mockPropertyInstance.Verify(x => x.Column("CAMEL_CASE"));
        }
    }
}