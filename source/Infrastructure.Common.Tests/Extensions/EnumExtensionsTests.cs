namespace Infrastructure.Common.Tests.Extensions
{
	using System;
	using System.ComponentModel;
	using ByndyuSoft.Infrastructure.Common.Extensions;
	using Xunit;

	public class EnumExtensionsTests
	{
		public enum TestEnum
		{
			[Description("Desc")] First = 1
		}

		[Fact]
		public void GetDescriptionMustReturnTextOfDescription()
		{
			string description = TestEnum.First.GetDescription();

			Assert.Equal("Desc", description);
		}

		[Fact]
		public void GetDescriptionMustReturnNullIfItDoesNotExist()
		{
			object o = (TestEnum) 0;
			string description = ((Enum) o).GetDescription();

			Assert.Null(description);
		}
	}
}