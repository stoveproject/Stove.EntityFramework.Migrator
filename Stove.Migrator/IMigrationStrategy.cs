using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Reflection;

namespace Stove.Migrator
{
    public interface IMigrationStrategy
    {
        void Migrate<TDbContext, TConfiguration>(string nameOrConnectionString, Assembly migrationAssembly)
            where TDbContext : DbContext
            where TConfiguration : DbMigrationsConfiguration<TDbContext>, new();
    }
}
