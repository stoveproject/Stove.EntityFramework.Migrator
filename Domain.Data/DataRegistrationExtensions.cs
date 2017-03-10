using System.Reflection;

using Autofac.Extras.IocManager;

using Stove.EntityFramework;

namespace Domain.Data
{
    public static class DataRegistrationExtensions
    {
        public static IIocBuilder UseData(this IIocBuilder builder)
        {
            return builder
                .RegisterServices(r => r.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly()));
        }
    }
}
