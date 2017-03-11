using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Reflection;

using Autofac.Extras.IocManager;

using Stove.Log;

namespace Stove.Migrator
{
    public class DbContextMigrationStrategy : IMigrationStrategy
    {
        private readonly IScopeResolver _resolver;

        public DbContextMigrationStrategy(IScopeResolver resolver)
        {
            _resolver = resolver;
            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        public void Migrate<TDbContext, TConfiguration>(string nameOrConnectionString, Assembly migrationAssembly = null)
            where TDbContext : DbContext
            where TConfiguration : DbMigrationsConfiguration<TDbContext>, new()
        {
            Logger.Info($"DbContext migration strategy started for {typeof(TDbContext).GetTypeInfo().Name}...");

            using (IScopeResolver scope = _resolver.BeginScope())
            {
                var dbContext = scope.Resolve<TDbContext>(new { nameOrConnectionString });
                var dbInitializer = new MigrateDatabaseToLatestVersion<TDbContext, TConfiguration>(true, new TConfiguration());

                dbInitializer.InitializeDatabase(dbContext);
            }

            Logger.Info($"DbContext migration strategy finished for {typeof(TDbContext).GetTypeInfo().Name}...");
        }
    }
}
