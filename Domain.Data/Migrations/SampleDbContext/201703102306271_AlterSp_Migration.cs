using System.Data.Entity.Migrations;

namespace Domain.Data.Migrations.SampleDbContext
{
    public partial class AlterSp_Migration : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO dbo.Product ( Name ) VALUES ( N'Kazak' )");
        }

        public override void Down()
        {
        }
    }
}
