using FluentMigrator;

namespace Domain.Data.FluentMigrator.OneAdminDatabase
{
    [Tags(TagNames.Database.OneAdminDatabase)]
    [Tags(TagNames.Environment.Dev, TagNames.Environment.Stage, TagNames.Environment.Production)]
    [KnownMigration(201703121432, "OAT1-0001")]
    public class Mig0001_CreateUserTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Users")
                  .InSchema("dbo")
                  .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                  .WithColumn("Name").AsString().NotNullable();
        }
    }
}
