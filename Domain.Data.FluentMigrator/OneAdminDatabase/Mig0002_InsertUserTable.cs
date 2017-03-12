using FluentMigrator;

namespace Domain.Data.FluentMigrator.OneAdminDatabase
{
    [Tags(TagNames.Database.OneAdminDatabase)]
    [Tags(TagNames.Environment.Dev, TagNames.Environment.Stage, TagNames.Environment.Production)]
    [KnownMigration(201703121434, "OAT1-0001")]
    public class Mig0002_InsertUserTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("Mig0002_InsertUserTable.sql");
        }

        public override void Down()
        {
            Execute.EmbeddedScript("Mig0002_InsertUserTable_Rollback.sql");
        }
    }
}
