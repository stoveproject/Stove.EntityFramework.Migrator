using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Reflection;

using Autofac.Extras.IocManager;

namespace Stove.Migrator
{
    public class DbContextSeedMigrationStrategy : IMigrationStrategy
    {
        private readonly IScopeResolver _resolver;

        public DbContextSeedMigrationStrategy(IScopeResolver resolver)
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
                var dbInitializer = scope.Resolve<StoveDbContextMigration<TDbContext>>();
                dbInitializer.InitializeDatabase(logger);
            }

            logger($"MigrationStrategy: DbContext finished succesfully for {typeof(TDbContext).GetTypeInfo().Name}.");
        }
    }
}
