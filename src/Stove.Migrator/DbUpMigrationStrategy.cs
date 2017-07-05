using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Reflection;

using DbUp;
using DbUp.Engine;

namespace Stove
{
    public class DbUpMigrationStrategy : IMigrationStrategy
    {
        private const string DpUpScriptsFolderName = "Scripts";

        public void Migrate<TDbContext, TConfiguration>(string nameOrConnectionString, Assembly migrationAssembly, Action<string> logger)
            where TDbContext : DbContext
            where TConfiguration : DbMigrationsConfiguration<TDbContext>, new()
        {
            logger($"MigrationStrategy: DbUp starting for {typeof(TDbContext).GetTypeInfo().Name}...");

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

            logger($"MigrationStrategy: DbUp finished succesfully for {typeof(TDbContext).GetTypeInfo().Name}.");
        }
    }
}
