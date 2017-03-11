using System;
using System.Collections.Generic;

using Autofac.Extras.IocManager;

using Stove.Extensions;
using Stove.Migrator;

namespace Domain.Data.Migrator
{
    public class MigrateExecuter : ITransientDependency
    {
        private readonly IEnumerable<IStoveDbMigrator> _stoveDbMigrators;

        public MigrateExecuter(IEnumerable<IStoveDbMigrator> stoveDbMigrators, Log log)
        {
            _stoveDbMigrators = stoveDbMigrators;
            Log = log;
        }

        public Log Log { get; }

        public void Run()
        {
            Log.Write("Database migrations started...");
            Log.Write("--------------------------------------------------------");

            try
            {
                _stoveDbMigrators.ForEach(migrator =>
                {
                    Log.Write($"DbContext: {migrator.CurrentDbContextName} migration started with {migrator.CurrentDbConfigurationName} configuration...");
                    migrator.CreateOrMigrate();
                    Log.Write($"DbContext: {migrator.CurrentDbContextName} migration finished with {migrator.CurrentDbConfigurationName} configuration");
                });
            }
            catch (Exception exception)
            {
                Log.Write("An error occured during migration of host database:");
                Log.Write(exception.ToString());
                Log.Write("Canceled migrations.");
                return;
            }

            Log.Write("--------------------------------------------------------");
            Log.Write("All Database migrations finished...");
        }
    }
}
