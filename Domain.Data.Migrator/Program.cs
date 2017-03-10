using Autofac.Extras.IocManager;

using Stove;

namespace Domain.Data.Migrator
{
    public class Program
    {
        public static void Main()
        {
            IRootResolver roorResolver = IocBuilder.New
                                                   .UseAutofacContainerBuilder()
                                                   .UseStoveWithNullables(typeof(DataMigratorBootstrapper))
                                                   .UseData()
                                                   .UseDataMigrator()
                                                   .CreateResolver();

            var migrator = roorResolver.Resolve<MigrateExecuter>();
            migrator.Run();
        }
    }
}
