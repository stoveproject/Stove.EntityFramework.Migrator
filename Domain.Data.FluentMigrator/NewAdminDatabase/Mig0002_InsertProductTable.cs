using FluentMigrator;

namespace Domain.Data.FluentMigrator.NewAdminDatabase
{
    [Tags(TagNames.Database.NewAdminDatabase)]
    [Tags(TagNames.Environment.Production)]
    [Tags(TagNames.Country.Italy)]
    [KnownMigration(201703121510, "NEWADM-0002")]
    public class Mig0002_InsertProductTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("Mig0002_InserProductTable.sql");
        }

        public override void Down()
        {
            Execute.EmbeddedScript("Mig0002_InserProductTable_Rollback.sql");
        }
    }
}
