using FluentMigrator;

namespace Domain.Data.FluentMigrator.OneAdminDatabase
{
    [Tags(TagNames.Database.OneAdminDatabase)]
    [Tags(TagNames.Environment.Dev, TagNames.Environment.Stage, TagNames.Environment.Production)]
    [KnownMigration("Oguzhan Soykan", "OAT1-0001", typeof(Mig0001_CreateUserTable), 2017, 03, 12, 18, 30)]
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
