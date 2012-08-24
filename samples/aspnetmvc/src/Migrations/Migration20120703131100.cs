namespace MvcSample.Migrations
{
	using FluentMigrator;

	[Migration(20120703131100)]
	public class Migration20120703131100 : AutoReversingMigration
	{
		public override void Up()
		{
			Create.Table("USERS")
				.WithColumn("USER_ID").AsInt32().PrimaryKey().Identity()
				.WithColumn("NAME").AsString(int.MaxValue).NotNullable()
				.WithColumn("LOGIN").AsString(int.MaxValue).NotNullable()
				.WithColumn("EMAIL").AsString(int.MaxValue).NotNullable()
				.WithColumn("PASSWORD").AsString(int.MaxValue).NotNullable();
		}
	}
}