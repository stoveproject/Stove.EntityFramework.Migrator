using FluentMigrator;

namespace Domain.Data.FluentMigrator.DefaultDb
{
    [KnownMigration(201703121440, "OAT1-0002")]
    public class Mig0003_CreateProductTable : AutoReversingMigration
    {
        public override void Up()
        {
            if (ApplicationContext.ToString().Equals(DbContextTypes.OADatabase.ToString()))
            {
                Create.Table("Products").InSchema("dbo")
                      .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                      .WithColumn("Name").AsString().NotNullable();
            }
        }
    }
}
