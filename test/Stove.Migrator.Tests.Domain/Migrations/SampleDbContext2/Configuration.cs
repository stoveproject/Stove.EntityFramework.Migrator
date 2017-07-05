using System.Data.Entity.Migrations;

namespace Stove.Migrator.Tests.Domain.Migrations.SampleDbContext2
{
    public sealed class Configuration : DbMigrationsConfiguration<DbContexes.SampleDbContext2>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\SampleDbContext2";
        }

        protected override void Seed(DbContexes.SampleDbContext2 context)
        {
            // context.DisableAllFilters();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
