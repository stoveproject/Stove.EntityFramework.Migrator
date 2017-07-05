using Autofac.Extras.IocManager;

namespace Stove.Versioning
{
    public class StoveStoveVersionInfoConfiguration : IStoveVersionInfoConfiguration, ISingletonDependency
    {
        public string Schema { get; set; }

        public string Table { get; set; }
    }
}
