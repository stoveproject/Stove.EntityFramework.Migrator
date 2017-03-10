using Autofac.Extras.IocManager;

namespace Domain.Data.Migrator
{
    public class MigrateExecuter : ITransientDependency
    {
        private readonly IStoveDbMigrator _stoveDbMigrator;

        public MigrateExecuter(IStoveDbMigrator stoveDbMigrator)
        {
            _stoveDbMigrator = stoveDbMigrator;
        }

        public void Run()
        {
            _stoveDbMigrator.CreateOrMigrate();
        }
    }
}
