using System;
using FluentNHibernate.Conventions.Instances;
using FluentNHibernate.MappingModel;
using ByndyuSoft.Infrastructure.NHibernate.Conventions;
using Moq;
using Xunit;

namespace ByndyuSoft.Infrastructure.NHibernate.Tests.Conventions
{
	public class ForeignKeyColumnNameConventionTests
	{
		[Fact]
		public void UpperCase()
		{
			var mockPropertyInstance = new Mock<IManyToOneInstance>();

			mockPropertyInstance.Setup(instance => instance.Class).Returns(new TypeReference(GetType()));

			new ForeignKeyColumnNameConvention().Apply(mockPropertyInstance.Object);

			mockPropertyInstance.Verify(instance => instance.Column("FOREIGN_KEY_COLUMN_NAME_CONVENTION_TESTS_ID"));
		}
	}
}