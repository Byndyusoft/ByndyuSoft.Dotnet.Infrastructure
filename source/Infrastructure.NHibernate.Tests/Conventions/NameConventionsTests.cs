namespace Infrastructure.NHibernate.Tests.Conventions
{
    using ByndyuSoft.Infrastructure.NHibernate.Conventions;
    using NUnit.Framework;

    public class NameConventionsTests
    {
        [Test]
        public void TableNameTest()
        {
            string tableName = NameConventions.GetTableName(typeof (ChainSelection));

            Assert.AreEqual("CHAIN_SELECTION", tableName);
        }

        [Test]
        public void SequenceNameTest()
        {
            string sequenceName = NameConventions.GetSequenceName(typeof (ChainSelection));

            Assert.AreEqual("CHAIN_SELECTION_SEQ", sequenceName);
        }

        [Test]
        public void PrimaryKeyColumnNameTest()
        {
            string primaryKeyColumnName = NameConventions.GetPrimaryKeyColumnName(typeof (ChainSelection));

            Assert.AreEqual("CHAIN_SELECTION_ID", primaryKeyColumnName);
        }

        #region Nested type: ChainSelection

        public class ChainSelection
        {
        }

        #endregion
    }
}