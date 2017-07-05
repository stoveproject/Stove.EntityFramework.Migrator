using Autofac.Extras.IocManager;

using Stove.Migrator.Versioning;

namespace Stove.Migrator
{
    public class StoveVersionInfoConfiguration : IVersionInfoConfiguration, ISingletonDependency
    {
        public StoveVersionInfoConfiguration(string persistantStorageDbContextName, string schema, string tableName)
        {
            PersistentStorageDbContextName = persistantStorageDbContextName;
            Schema = schema;
            TableName = tableName;
        }

        public string PersistentStorageDbContextName { get; protected set; }

        public string Schema { get; protected set; }

        public string TableName { get; protected set; }
    }
}
