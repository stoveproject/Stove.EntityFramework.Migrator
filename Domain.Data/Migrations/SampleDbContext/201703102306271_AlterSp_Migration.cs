namespace Domain.Data.Migrations.SampleDbContext
{
    using System;
    using System.Data.Entity.Migrations;

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
