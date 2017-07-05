using System;
using System.Collections.Generic;
using System.Linq;

using Autofac.Extras.IocManager;

using Stove.Extensions;

namespace Stove.Migrator.Executer
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
            Log.Write("Database migrations starting...");
            Log.Write($"Founded DbContext migration count: {_stoveDbMigrators.Count()}");
            Log.Write("-----------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();

            try
            {
                _stoveDbMigrators.ForEach(migrator =>
                {
                    migrator.CreateOrMigrate(Log.Write);

                    Log.Write("-----------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine();
                });
            }
            catch (Exception exception)
            {
                Log.Write("An error occured during migration of host database:");
                Log.Write(exception.ToString());
                Log.Write("Canceled migrations.");
                return;
            }

            Console.WriteLine();
            Log.Write("All Database migrations finished successfully...");
        }
    }
}
