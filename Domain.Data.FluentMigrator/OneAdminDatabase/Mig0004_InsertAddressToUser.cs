using FluentMigrator;

namespace Domain.Data.FluentMigrator.OneAdminDatabase
{
    [Tags(TagNames.Database.OneAdminDatabase)]
    [Tags(TagNames.Environment.Dev, TagNames.Environment.Stage, TagNames.Environment.Production)]
    [KnownMigration("Oguzhan Soykan", "OAT1-0002", typeof(Mig0004_InsertAddressToUser), 2017, 03, 12, 18, 36)]
    public class Mig0004_InsertAddressToUser : AutoReversingMigration
    {
        public override void Up()
        {
            Insert.IntoTable("Addresses").InSchema("dbo")
                  .Row(new { Text = "Çeliktepe Mahallesi, Gülçin Sk, 13/4, Kağıthane - İstanbul", UserId = 1 });
        }
    }
}
