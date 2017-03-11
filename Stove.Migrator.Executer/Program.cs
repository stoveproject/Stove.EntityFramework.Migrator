﻿using System;

using Autofac.Extras.IocManager;

using CommandLine;

using Domain.Data;

using HibernatingRhinos.Profiler.Appender.EntityFramework;

using Stove.EntityFramework;
using Stove.NLog;

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
                                            .UseStoveMigrator();

            var options = new MigrationOptions();
            if (Parser.Default.ParseArguments(args, options))
            {
                if (options.Is(MigrationType.DbUp))
                {
                    builder.UseStoveDbUpMigrationStrategy();
                }
                else if (options.Is(MigrationType.DbContext))
                {
                    builder.UseStoveDbContextMigrationStrategy();
                }
                else
                {
                    builder.UseStoveAllMigrationStrategies();
                }
            }

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