namespace Infrastructure.Common.Tests.Extensions
{
    using ByndyuSoft.Infrastructure.Common.Extensions;
    using NUnit.Framework;

    public class RussianLanguageExtensionsTests
    {
        [Test]
        public void OneForm()
        {
            const int value = 41;

            string result = value.ToString("библиотека", "библиотеки", "библиотек");

            Assert.AreEqual("41 библиотека", result);
        }

        [Test]
        public void TwoForm()
        {
            const int value = 42;

            string result = value.ToString("библиотека", "библиотеки", "библиотек");

            Assert.AreEqual("42 библиотеки", result);
        }

        [Test]
        public void TreeForm()
        {
            const int value = 47;

            string result = value.ToString("библиотека", "библиотеки", "библиотек");

            Assert.AreEqual("47 библиотек", result);
        }

        [Test]
        public void FormFor112()
        {
            const int value = 112;

            string result = value.ToString("библиотека", "библиотеки", "библиотек");

            Assert.AreEqual("112 библиотек", result);
        }
    }
}