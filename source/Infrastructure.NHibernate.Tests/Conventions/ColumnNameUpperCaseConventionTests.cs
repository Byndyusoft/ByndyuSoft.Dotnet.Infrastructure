namespace Infrastructure.NHibernate.Tests.Conventions
{
    using ByndyuSoft.Infrastructure.NHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;
    using Moq;
    using Xunit;

    public class ColumnNameUpperCaseConventionTests
    {
        [Fact]
        public void UpperCase()
        {
            var mockPropertyInstance = new Mock<IPropertyInstance>();
            mockPropertyInstance.Setup(instance => instance.Name).Returns("Test");

            new ColumnNameUpperCaseConvention().Apply(mockPropertyInstance.Object);

            mockPropertyInstance.Verify(instance => instance.Column("TEST"));
        }

        [Fact]
        public void CamelCaseReplacedByUnderscore()
        {
            var mockPropertyInstance = new Mock<IPropertyInstance>();
            mockPropertyInstance.Setup(instance => instance.Name).Returns("CamelCase");

            new ColumnNameUpperCaseConvention().Apply(mockPropertyInstance.Object);

            mockPropertyInstance.Verify(instance => instance.Column("CAMEL_CASE"));
        }
    }
}