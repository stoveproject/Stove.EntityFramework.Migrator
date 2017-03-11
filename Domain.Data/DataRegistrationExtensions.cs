using System.Reflection;

using Autofac.Extras.IocManager;

namespace Domain.Data
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
