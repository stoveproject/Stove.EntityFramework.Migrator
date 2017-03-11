using System;

using Autofac.Extras.IocManager;

using CommandLine;

using HibernatingRhinos.Profiler.Appender.EntityFramework;

using Stove;
using Stove.NLog;

namespace Domain.Data.Migrator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EntityFrameworkProfiler.Initialize();

            var options = new MigrationOptions();
            if (Parser.Default.ParseArguments(args, options))
            {
                if (options.Is(MigrationType.DbUp))
                {
                }
            }

            IRootResolver rootResolver = IocBuilder.New
                                                   .UseAutofacContainerBuilder()
                                                   .UseStoveWithNullables(typeof(DataMigratorBootstrapper))
                                                   .UseStoveNLog()
                                                   .UseData()
                                                   .UseDataMigrator()
                                                   .CreateResolver();

            using (rootResolver)
            {
                var migrator = rootResolver.Resolve<MigrateExecuter>();
                migrator.Run();
            }

            Console.WriteLine("Press ENTER to exit...");
            Console.ReadLine();
        }
    }
}
