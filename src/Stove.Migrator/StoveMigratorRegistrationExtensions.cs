using System.Reflection;

using Autofac;
using Autofac.Extras.IocManager;

namespace Stove
{
    public static class StoveMigratorRegistrationExtensions
    {
        /// <summary>
        ///     Uses the stove migrator defaults.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IIocBuilder UseStoveMigratorDefaults(this IIocBuilder builder)
        {
            return builder
                .RegisterServices(r => r.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly()))
                .RegisterServices(r =>
                {
                    r.UseBuilder(cb =>
                    {
                        cb.RegisterGeneric(typeof(StoveDbContextMigration<>))
                          .InstancePerDependency()
                          .AsSelf();
                    });
                });
        }
    }
}
