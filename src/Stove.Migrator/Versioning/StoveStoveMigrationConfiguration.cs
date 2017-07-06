using Autofac.Extras.IocManager;

namespace Stove.Versioning
{
    public class StoveStoveMigrationConfiguration : IStoveMigrationConfiguration, ISingletonDependency
    {
        public string Schema { get; set; }

        public string Table { get; set; }

        public int TransactionTimeout { get; set; }
    }
}
