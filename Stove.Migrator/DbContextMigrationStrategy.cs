using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Reflection;

using Autofac.Extras.IocManager;

namespace Stove.Migrator
{
    public class DbContextMigrationStrategy : IMigrationStrategy
    {
        private readonly IScopeResolver _resolver;

        public DbContextMigrationStrategy(IScopeResolver resolver)
        {
            _resolver = resolver;
        }

        public void Migrate<TDbContext, TConfiguration>(string nameOrConnectionString, Assembly migrationAssembly, Action<string> logger)
            where TDbContext : DbContext
            where TConfiguration : DbMigrationsConfiguration<TDbContext>, new()
        {
            logger($"MigrationStrategy: DbContext starting for {typeof(TDbContext).GetTypeInfo().Name}...");

            using (IScopeResolver scope = _resolver.BeginScope())
            {
                var dbContext = scope.Resolve<TDbContext>(new { nameOrConnectionString });
                var dbInitializer = new MigrateDatabaseToLatestVersion<TDbContext, TConfiguration>(true, new TConfiguration());

                dbInitializer.InitializeDatabase(dbContext);
            }

            logger($"MigrationStrategy: DbContext finished succesfully for {typeof(TDbContext).GetTypeInfo().Name}.");
        }
    }
}
