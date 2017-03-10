using System;
using System.Data.Entity;

using Autofac.Extras.IocManager;

using Domain.Data.DbContexes;

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

            Database.SetInitializer<SampleDbContext>(null);
            Database.SetInitializer<SampleDbContext2>(null);

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
