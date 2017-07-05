using System.Reflection;

using Autofac.Extras.IocManager;

namespace Stove.Migrator.Tests.Domain
{
    public static class DataRegistrationExtensions
    {
        public static IIocBuilder UseStoveMigrationParticipant(this IIocBuilder builder)
        {
            return builder
                .RegisterServices(r => r.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly()));
        }
    }
}
