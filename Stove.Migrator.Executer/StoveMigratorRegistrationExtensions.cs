using System.Reflection;

using Autofac.Extras.IocManager;

using Stove.EntityFramework;
using Stove.Migrator.Versioning;

namespace Stove.Migrator.Executer
{
    public static class StoveMigratorRegistrationExtensions
    {
        public static IIocBuilder UseStoveMigrator(this IIocBuilder builder)
        {
            return builder.RegisterServices(r => r.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly()))
                          .UseStoveEntityFramework()
                          .UseStoveDbContextEfTransactionStrategy()
                          .UseStoveTypedConnectionStringResolver();
        }

        public static IIocBuilder UseStoveDbContextMigrationStrategy(this IIocBuilder builder)
        {
            return builder.RegisterServices(r => { r.Register<IMigrationStrategy, DbContextMigrationStrategy>(); });
        }

        public static IIocBuilder UseStoveDbUpMigrationStrategy(this IIocBuilder builder)
        {
            return builder.RegisterServices(r => { r.Register<IMigrationStrategy, DbUpMigrationStrategy>(); });
        }

        public static IIocBuilder UseStoveDbContextSeedMigrationStrategy(this IIocBuilder builder, StoveVersionInfoConfiguration configuration)
        {
            return builder.RegisterServices(r =>
            {
                r.Register<IVersionInfoConfiguration, StoveVersionInfoConfiguration>(configuration);
                r.Register<IMigrationStrategy, DbContextSeedMigrationStrategy>();
            });
        }

        public static IIocBuilder UseStoveAllMigrationStrategies(this IIocBuilder builder, StoveVersionInfoConfiguration configuration)
        {
            return builder.RegisterServices(r =>
            {
                r.Register<IMigrationStrategy, DbContextMigrationStrategy>();
                r.Register<IMigrationStrategy, DbUpMigrationStrategy>();
                r.Register<IVersionInfoConfiguration, StoveVersionInfoConfiguration>(configuration, Lifetime.Singleton);
                r.Register<IMigrationStrategy, DbContextSeedMigrationStrategy>();
            });
        }
    }
}
