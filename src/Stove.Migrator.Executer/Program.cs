using System;

using Autofac.Extras.IocManager;

using CommandLine;

using HibernatingRhinos.Profiler.Appender.EntityFramework;

using Stove.Migrator.Tests.Domain;

namespace Stove.Migrator.Executer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EntityFrameworkProfiler.Initialize();

            IIocBuilder builder = IocBuilder.New
                                            .UseAutofacContainerBuilder()
                                            .UseStoveWithNullables(typeof(StoveMigratorBootstrapper))
                                            .UseStoveNLog()
                                            .UseStoveEntityFramework()
                                            .UseStoveMigrationParticipant()
                                            .UseStoveMigrator()
                                            .UseStoveMigratorDefaults();

            var options = new MigrationOptions();
            if (Parser.Default.ParseArguments(args, options))
            {
                if (options.Is(MigrationType.DbUp))
                {
                    Console.WriteLine("Selected Migration is only DbUp...");

                    builder.UseStoveDbUpMigrationStrategy();
                }
                else if (options.Is(MigrationType.DbContext))
                {
                    Console.WriteLine("Selected Migration is only DbContext...");

                    builder.UseStoveDbContextMigrationStrategy();
                }
                else if (options.Is(MigrationType.DbContextSeed))
                {
                    Console.WriteLine("Selected Migration is only DbContextSeed...");

                    builder.UseStoveDbContextSeedMigrationStrategy(configuration =>
                    {
                        configuration.Schema = options.Schema;
                        configuration.Table = options.Table;
                        configuration.TransactionTimeout = options.TransactionTimeout;
                        configuration.Enviroment = options.Enviroment;
                        return configuration;
                    });
                }
                else
                {
                    Console.WriteLine("Selected Migration is DbContext, DbUp and DbContextSeed...");

                    builder.UseStoveAllMigrationStrategies(configuration =>
                    {
                        configuration.Schema = options.Schema;
                        configuration.Table = options.Table;
                        configuration.TransactionTimeout = options.TransactionTimeout;
                        configuration.Enviroment = options.Enviroment;
                        return configuration;
                    });
                }
            }

            builder.RegisterServices(r => r.OnDisposing += (sender, eventArgs) => { Console.WriteLine("Stove.Migrator.Executer successfully executed and disposed."); });

            IRootResolver rootResolver = builder.CreateResolver();

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
