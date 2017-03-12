using FluentMigrator;

namespace Domain.Data.FluentMigrator.OADatabase
{
    [KnownMigration(201703121510,"OAT1-0002")]
    public class Mig0004_InsertProductTable : Migration
    {
        public override void Up()
        {
            if (ApplicationContext.ToString().Equals(DatabaseTypes.OADatabase.ToString()))
            {
                Execute.EmbeddedScript("Script0001 - InserProduct_Jean.sql");
            }
        }

        public override void Down()
        {
            if (ApplicationContext.ToString().Equals(DatabaseTypes.OADatabase.ToString()))
            {
                Execute.EmbeddedScript("Script0001 - InserProduct_Jean_Rollback.sql");
            }
        }
    }
}
