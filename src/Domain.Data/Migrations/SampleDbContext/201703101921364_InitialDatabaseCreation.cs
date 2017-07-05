using System.Data.Entity.Migrations;

namespace Domain.Data.Migrations.SampleDbContext
{
    public partial class InitialDatabaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Users",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(false)
                    })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
