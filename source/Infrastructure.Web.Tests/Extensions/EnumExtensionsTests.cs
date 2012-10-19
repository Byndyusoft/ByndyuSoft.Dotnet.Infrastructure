namespace Infrastructure.Web.Tests.Extensions
{
	using System.Linq;
	using ByndyuSoft.Infrastructure.Web.Extensions;
	using Xunit;

	public class EnumExtensionsTests
	{
		enum TestEnum
		{
			First,
			Second
		}

		[Fact]
		public void CreateSelectListFromEnum()
		{
			var selectedList = EnumExtensions.ToSelectedList<TestEnum>();

			var itesm = selectedList.Items.Cast<object>();

			Assert.Equal(2, itesm.Count());
		}
	}
}