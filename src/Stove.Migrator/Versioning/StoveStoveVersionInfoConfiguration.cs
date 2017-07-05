using Autofac.Extras.IocManager;

using Stove.Migrator.Versioning;

namespace Stove.Migrator
{
    public class StoveStoveVersionInfoConfiguration : IStoveVersionInfoConfiguration, ISingletonDependency
    {
        public string Schema { get; set; }

        public string Table { get; set; }
    }
}
