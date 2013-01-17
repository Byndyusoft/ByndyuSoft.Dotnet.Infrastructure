namespace Infrastructure.NHibernate.Tests.Conventions
{
    using ByndyuSoft.Infrastructure.NHibernate.Conventions;
    using Xunit;

    public class NameConventionsTests
	{
		[Fact]
		public void TableNameTest()
		{
			string tableName = NameConventions.GetTableName(typeof (ChainSelection));

			Assert.Equal("CHAIN_SELECTION", tableName);
		}

		public class ChainSelection
		{
		}

		[Fact]
		public void SequenceNameTest()
		{
			string sequenceName = NameConventions.GetSequenceName(typeof (ChainSelection));

			Assert.Equal("CHAIN_SELECTION_SEQ", sequenceName);
		}

		[Fact]
		public void PrimaryKeyColumnNameTest()
		{
			string primaryKeyColumnName = NameConventions.GetPrimaryKeyColumnName(typeof (ChainSelection));

			Assert.Equal("CHAIN_SELECTION_ID", primaryKeyColumnName);
		}
	}
}