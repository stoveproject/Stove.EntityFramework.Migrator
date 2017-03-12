using FluentMigrator;

namespace Domain.Data.FluentMigrator.NewAdminDatabase
{
    [Tags(TagNames.Database.NewAdminDatabase)]
    [Tags(TagNames.Environment.Production)]
    [Tags(TagNames.Country.Italy)]
    [KnownMigration(201703121440, "NEWADM-0002")]
    public class Mig0001_CreateProductTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Products").InSchema("dbo")
                  .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                  .WithColumn("Name").AsString().NotNullable();
        }
    }
}
