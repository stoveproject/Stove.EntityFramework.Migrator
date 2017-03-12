using FluentMigrator;

namespace Domain.Data.FluentMigrator.NewAdminDatabase
{
    [Tags(TagNames.Database.NewAdminDatabase)]
    [Tags(TagNames.Environment.Production)]
    [Tags(TagNames.Country.Italy)]
    [KnownMigration("Oguzhan Soykan", "NEWADM-0001", typeof(Mig0001_CreateProductTable), 2017, 03, 12, 18, 30)]
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
