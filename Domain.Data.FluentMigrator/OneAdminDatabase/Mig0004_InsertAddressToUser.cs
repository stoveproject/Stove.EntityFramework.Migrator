using FluentMigrator;

namespace Domain.Data.FluentMigrator.OneAdminDatabase
{
    [Tags(TagNames.Database.OneAdminDatabase)]
    [Tags(TagNames.Environment.Dev, TagNames.Environment.Stage, TagNames.Environment.Production)]
    [KnownMigration(201703121802, "OAT1-0003")]
    public class Mig0004_InsertAddressToUser : AutoReversingMigration
    {
        public override void Up()
        {
            Insert.IntoTable("Addresses").InSchema("dbo")
                  .Row(new { Text = "Çeliktepe Mahallesi, Gülçin Sk, 13/4, Kağıthane - İstanbul", UserId = 1 });
        }
    }
}
