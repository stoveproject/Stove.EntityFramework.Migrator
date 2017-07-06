using System;
using System.Reflection;

using Autofac.Extras.IocManager;

using Stove.Versioning;

namespace Stove.Migrator.Executer
{
    public static class StoveMigratorRegistrationExtensions
    {
        /// <summary>
        ///     Uses the stove migrator.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IIocBuilder UseStoveMigrator(this IIocBuilder builder)
        {
            return builder.RegisterServices(r => r.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly()))
                          .UseStoveEntityFramework()
                          .UseStoveDbContextEfTransactionStrategy()
                          .UseStoveTypedConnectionStringResolver();
        }

        /// <summary>
        ///     Uses the stove database context migration strategy.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IIocBuilder UseStoveDbContextMigrationStrategy(this IIocBuilder builder)
        {
            return builder.RegisterServices(r => { r.Register<IMigrationStrategy, DbContextMigrationStrategy>(); });
        }

        /// <summary>
        ///     Uses the stove database up migration strategy.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IIocBuilder UseStoveDbUpMigrationStrategy(this IIocBuilder builder)
        {
            return builder.RegisterServices(r => { r.Register<IMigrationStrategy, DbUpMigrationStrategy>(); });
        }

        /// <summary>
        ///     Uses the stove database context seed migration strategy.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="configurationAction">The configuration action.</param>
        /// <returns></returns>
        public static IIocBuilder UseStoveDbContextSeedMigrationStrategy(this IIocBuilder builder, Func<IStoveMigrationConfiguration, IStoveMigrationConfiguration> configurationAction)
        {
            return builder.RegisterServices(r =>
            {
                r.Register(ctx => configurationAction);
                r.Register<IMigrationStrategy, DbContextSeedMigrationStrategy>();
            });
        }

        /// <summary>
        ///     Uses the stove all migration strategies.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="configurationAction">The configuration action.</param>
        /// <returns></returns>
        public static IIocBuilder UseStoveAllMigrationStrategies(this IIocBuilder builder, Func<IStoveMigrationConfiguration, IStoveMigrationConfiguration> configurationAction)
        {
            return builder.RegisterServices(r =>
            {
                r.Register(ctx => configurationAction);
                r.Register<IMigrationStrategy, DbContextMigrationStrategy>();
                r.Register<IMigrationStrategy, DbUpMigrationStrategy>();
                r.Register<IMigrationStrategy, DbContextSeedMigrationStrategy>();
            });
        }
    }
}
