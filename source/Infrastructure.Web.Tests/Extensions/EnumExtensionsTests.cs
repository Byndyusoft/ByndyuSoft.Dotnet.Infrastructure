namespace Infrastructure.Web.Tests.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using ByndyuSoft.Infrastructure.Web.Extensions;
    using NUnit.Framework;

    public class EnumExtensionsTests
    {
        [Test]
        public void CreateSelectListFromEnum()
        {
            SelectList selectedList = EnumExtensions.ToSelectedList<TestEnum>();

            IEnumerable<object> itesm = selectedList.Items.Cast<object>();

            Assert.AreEqual(2, itesm.Count());
        }

        #region Nested type: TestEnum

        private enum TestEnum
        {
            First,
            Second
        }

        #endregion
    }
}