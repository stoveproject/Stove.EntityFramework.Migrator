using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Reflection;

using DbUp;
using DbUp.Engine;

using Stove.Log;

namespace Domain.Data.Framework
{
    public class DbUpMigrationStrategy : IMigrationStrategy
    {
        public DbUpMigrationStrategy()
        {
            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        public void Migrate<TDbContext, TConfiguration>(string nameOrConnectionString)
            where TDbContext : DbContext
            where TConfiguration : DbMigrationsConfiguration<TDbContext>, new()
        {
            Logger.Info($"DbContext migration strategy started for {typeof(TDbContext).GetTypeInfo().Name}...");

            string connString = ConnectionStringHelper.GetConnectionString(nameOrConnectionString);

            UpgradeEngine upgrader = DeployChanges.To
                                                  .SqlDatabase(connString)
                                                  .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                                                  .LogToConsole()
                                                  .WithTransaction()
                                                  .Build();

            DatabaseUpgradeResult result = upgrader.PerformUpgrade();

            if (result.Successful)
            {
                Logger.Info($"DbContext migration strategy finished for {typeof(TDbContext).GetTypeInfo().Name}...");
            }
            else
            {
                throw new DbUpdateException(result.Error.Message, result.Error);
            }
        }
    }
}
