namespace Infrastructure.Common.Tests.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ByndyuSoft.Infrastructure.Common.Extensions;
    using NUnit.Framework;

    public class EnumExtensionsTests
    {
        #region TestEnum enum

        public enum TestEnum
        {
            [System.ComponentModel.Description("Desc1")] First = 1,
            [System.ComponentModel.Description("Desc2")] Second = 2,
            [System.ComponentModel.Description("Desc3")] Third = 3
        }

        #endregion

        [Test]
        public void GetDescriptionMustReturnTextOfDescription()
        {
            string description = TestEnum.First.GetDescription();

            Assert.AreEqual("Desc1", description);
        }

        [Test]
        public void GetDescriptionMustReturnNullIfItDoesNotExist()
        {
            object o = (TestEnum) 0;
            string description = ((Enum) o).GetDescription();

            Assert.Null(description);
        }

        [Test]
        public void CreateListFromEnum()
        {
            IEnumerable<KeyValuePair<int, string>> result = EnumExtensions.ToKeyValuePairs<TestEnum>();

            Assert.AreEqual(3, result.Count());
            Assert.AreEqual(1, result.ElementAt(0).Key);
            Assert.AreEqual("Desc1", result.ElementAt(0).Value);
            Assert.AreEqual(2, result.ElementAt(1).Key);
            Assert.AreEqual("Desc2", result.ElementAt(1).Value);
            Assert.AreEqual(3, result.ElementAt(2).Key);
            Assert.AreEqual("Desc3", result.ElementAt(2).Value);
        }
    }
}