using System.Data.Entity;
using System.Data.Entity.Migrations;

using Autofac.Extras.IocManager;

namespace Domain.Data.Framework
{
    public class DbContextMigrationStrategy : IMigrationStrategy
    {
        private readonly IScopeResolver _resolver;

        public DbContextMigrationStrategy(IScopeResolver resolver)
        {
            _resolver = resolver;
        }

        public void Migrate<TDbContext, TConfiguration>(string nameOrConnectionString)
            where TDbContext : DbContext
            where TConfiguration : DbMigrationsConfiguration<TDbContext>, new()
        {
            using (IScopeResolver scope = _resolver.BeginScope())
            {
                var dbContext = scope.Resolve<TDbContext>(new { nameOrConnectionString });
                var dbInitializer = new MigrateDatabaseToLatestVersion<TDbContext, TConfiguration>(true, new TConfiguration());

                dbInitializer.InitializeDatabase(dbContext);
            }
        }
    }
}
