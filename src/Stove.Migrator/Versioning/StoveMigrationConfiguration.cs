using Autofac.Extras.IocManager;

namespace Stove.Versioning
{
    public class StoveMigrationConfiguration : IStoveMigrationConfiguration, ISingletonDependency
    {
        public string Schema { get; set; }

        public string Table { get; set; }

        public int TransactionTimeout { get; set; }

        public string[] Enviroment { get; set; }
    }
}