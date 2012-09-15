namespace Infrastructure.Common.Tests.Extensions
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Linq;
	using ByndyuSoft.Infrastructure.Common.Extensions;
	using Xunit;

	public class EnumExtensionsTests
	{
		public enum TestEnum
		{
			[Description("Desc1")] First = 1,
			[Description("Desc2")] Second = 2,
			[Description("Desc3")] Third = 3
		}

		[Fact]
		public void GetDescriptionMustReturnTextOfDescription()
		{
			string description = TestEnum.First.GetDescription();

			Assert.Equal("Desc1", description);
		}

		[Fact]
		public void GetDescriptionMustReturnNullIfItDoesNotExist()
		{
			object o = (TestEnum) 0;
			string description = ((Enum) o).GetDescription();

			Assert.Null(description);
		}

		[Fact]
		public void CreateListFromEnum()
		{
			IEnumerable<KeyValuePair<int, string>> result = EnumExtensions.ToKeyValuePairs<TestEnum>();

			Assert.Equal(3, result.Count());
			Assert.Equal(1, result.ElementAt(0).Key);
			Assert.Equal("Desc1", result.ElementAt(0).Value);
			Assert.Equal(2, result.ElementAt(1).Key);
			Assert.Equal("Desc2", result.ElementAt(1).Value);
			Assert.Equal(3, result.ElementAt(2).Key);
			Assert.Equal("Desc3", result.ElementAt(2).Value);
		}
	}
}