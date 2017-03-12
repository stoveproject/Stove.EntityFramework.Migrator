using FluentMigrator;

namespace Domain.Data.FluentMigrator.OneAdminDatabase
{
    [Tags(TagNames.Database.OneAdminDatabase)]
    [Tags(TagNames.Environment.Dev, TagNames.Environment.Stage, TagNames.Environment.Production)]
    [KnownMigration(201703121745, "OAT1-0003")]
    public class Mig0003_CreateAddressTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Addresses").InSchema("dbo")
                  .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                  .WithColumn("Text").AsString(256)
                  .WithColumn("UserId").AsInt32();

            Create.ForeignKey("FK_Addresses_Users_Id").FromTable("Addresses").ForeignColumn("UserId").ToTable("Users").PrimaryColumn("Id");
        }
    }
}
