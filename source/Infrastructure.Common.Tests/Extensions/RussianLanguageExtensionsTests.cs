namespace Infrastructure.Common.Tests.Extensions
{
	using ByndyuSoft.Infrastructure.Common.Extensions;
	using Xunit;

	public class RussianLanguageExtensionsTests
	{
		[Fact]
		public void OneForm()
		{
			const int value = 41;

			string result = value.ToString("библиотека", "библиотеки", "библиотек");

			Assert.Equal("41 библиотека", result);
		}

		[Fact]
		public void TwoForm()
		{
			const int value = 42;

			string result = value.ToString("библиотека", "библиотеки", "библиотек");

			Assert.Equal("42 библиотеки", result);
		}

		[Fact]
		public void TreeForm()
		{
			const int value = 47;

			string result = value.ToString("библиотека", "библиотеки", "библиотек");

			Assert.Equal("47 библиотек", result);
		}

        [Fact]
        public void FormFor112()
        {
            const int value = 112;

            string result = value.ToString("библиотека", "библиотеки", "библиотек");

            Assert.Equal("112 библиотек", result);
        }

	}
}