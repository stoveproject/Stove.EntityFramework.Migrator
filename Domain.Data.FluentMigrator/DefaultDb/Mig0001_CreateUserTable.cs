using FluentMigrator;

namespace Domain.Data.FluentMigrator.DefaultDb
{
    [KnownMigration(201703121432, "OAT1-0001")]
    public class Mig0001_CreateUserTable : AutoReversingMigration
    {
        public override void Up()
        {
            if (ApplicationContext.ToString().Equals(DbContextTypes.OADatabase.ToString()))
            {
                Create.Table("Users")
                      .InSchema("dbo")
                      .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                      .WithColumn("Name").AsString().NotNullable();
            }
        }
    }
}
