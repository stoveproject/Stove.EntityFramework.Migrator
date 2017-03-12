using FluentMigrator;

namespace Domain.Data.FluentMigrator.OADatabase
{
    [KnownMigration(201703121434, "OAT1-0001")]
    public class Mig0002_InsertUserTable : Migration
    {
        public override void Up()
        {
            if (ApplicationContext.ToString().Equals(DatabaseTypes.OADatabase.ToString()))
            {
                Execute.EmbeddedScript("Script0001 - InsertUser_Oguzhan.sql");
            }
        }

        public override void Down()
        {
            if (ApplicationContext.ToString().Equals(DatabaseTypes.OADatabase.ToString()))
            {
                Execute.EmbeddedScript("Script0001 - InsertUser_Oguzhan_Rollback.sql");
            }
        }
    }
}
