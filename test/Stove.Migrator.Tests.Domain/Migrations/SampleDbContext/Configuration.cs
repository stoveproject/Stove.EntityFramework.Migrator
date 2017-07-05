using System.Data.Entity.Migrations;

namespace Stove.Migrator.Tests.Domain.Migrations.SampleDbContext
{
    public sealed class Configuration : DbMigrationsConfiguration<DbContexes.SampleDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\SampleDbContext";
        }

        protected override void Seed(DbContexes.SampleDbContext context)
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
