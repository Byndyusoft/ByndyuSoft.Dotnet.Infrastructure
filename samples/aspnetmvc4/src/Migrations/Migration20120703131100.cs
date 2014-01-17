namespace Mvc4Sample.Migrations
{
    using FluentMigrator;

    [Migration(20120703131100)]
    public class Migration20130117101300 : ForwardOnlyMigration
    {
        public override void Up()
        {
            Create.Table("USERS")
                  .WithColumn("USER_ID").AsInt32().PrimaryKey().Identity()
                  .WithColumn("NAME").AsString(int.MaxValue).NotNullable()
                  .WithColumn("LOGIN").AsString(int.MaxValue).NotNullable()
                  .WithColumn("EMAIL").AsString(int.MaxValue).NotNullable()
                  .WithColumn("PASSWORD_HASH").AsString(int.MaxValue).NotNullable()
                  .WithColumn("PASSWORD_SALT").AsString(int.MaxValue).NotNullable();

            Create.Table("STAFF")
                  .WithColumn("STAFF_ID").AsInt32().PrimaryKey().Identity()
                  .WithColumn("NAME").AsString(int.MaxValue).NotNullable()
                  .WithColumn("QUANTITY").AsInt32().NotNullable()
                  .WithColumn("CREATED_AT").AsDateTime().NotNullable();
        }
    }
}