using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Reflection;

using DbUp;
using DbUp.Engine;

using Stove.Log;

namespace Stove.Migrator
{
    public class DbUpMigrationStrategy : IMigrationStrategy
    {
        private const string DpUpScriptsFolderName = "Scripts";

        public DbUpMigrationStrategy()
        {
            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        public void Migrate<TDbContext, TConfiguration>(string nameOrConnectionString, Assembly migrationAssembly)
            where TDbContext : DbContext
            where TConfiguration : DbMigrationsConfiguration<TDbContext>, new()
        {
            Logger.Info($"DbContext migration strategy started for {typeof(TDbContext).GetTypeInfo().Name}...");

            string scriptPrefix = $"{migrationAssembly.GetName().Name}.{DpUpScriptsFolderName}.{typeof(TDbContext).GetTypeInfo().Name}";

            UpgradeEngine upgrader = DeployChanges.To
                                                  .SqlDatabase(nameOrConnectionString)
                                                  .WithScriptsAndCodeEmbeddedInAssembly(migrationAssembly, s => s.EndsWith(".sql") && s.StartsWith(scriptPrefix))
                                                  .LogToConsole()
                                                  .WithTransaction()
                                                  .Build();

            DatabaseUpgradeResult result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                throw new DbUpdateException(result.Error.Message, result.Error);
            }

            Logger.Info($"DbContext migration strategy finished for {typeof(TDbContext).GetTypeInfo().Name}...");
        }
    }
}
