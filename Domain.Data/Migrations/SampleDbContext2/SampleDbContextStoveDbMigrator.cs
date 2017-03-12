using System.Collections.Generic;
using System.Reflection;

using Stove.Domain.Uow;
using Stove.Migrator;

namespace Domain.Data.Migrations.SampleDbContext2
{
    public class SampleDbContextStoveDbMigrator : StoveDbMigrator<DbContexes.SampleDbContext, SampleDbContext.Configuration>
    {
        public SampleDbContextStoveDbMigrator(
            IConnectionStringResolver connectionStringResolver,
            IUnitOfWorkManager unitOfWorkManager,
            IEnumerable<IMigrationStrategy> migrationStrategies) : base(connectionStringResolver, unitOfWorkManager, migrationStrategies)
        {
        }

        public override Assembly MigrationAssembly { get; } = Assembly.GetExecutingAssembly();
    }
}
