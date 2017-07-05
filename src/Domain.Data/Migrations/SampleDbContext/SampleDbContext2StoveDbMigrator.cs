using System.Collections.Generic;
using System.Reflection;

using Stove.Domain.Uow;
using Stove.Migrator;

namespace Domain.Data.Migrations.SampleDbContext
{
    public class SampleDbContext2StoveDbMigrator : StoveDbMigrator<DbContexes.SampleDbContext2, SampleDbContext2.Configuration>
    {
        public SampleDbContext2StoveDbMigrator(
            IConnectionStringResolver connectionStringResolver,
            IUnitOfWorkManager unitOfWorkManager,
            IEnumerable<IMigrationStrategy> migrationStrategies) : base(connectionStringResolver, unitOfWorkManager, migrationStrategies)
        {
        }

        public override Assembly MigrationAssembly { get; } = Assembly.GetExecutingAssembly();
    }
}
