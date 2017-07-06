using System.Collections.Generic;
using System.Reflection;

using Stove.Domain.Uow;
using Stove.Versioning;

namespace Stove.Migrator.Tests.Domain.Migrations.SampleDbContext2
{
    public class SampleDbContextStoveDbMigrator : StoveDbMigrator<DbContexes.SampleDbContext, SampleDbContext.Configuration>
    {
        public SampleDbContextStoveDbMigrator(
            IConnectionStringResolver connectionStringResolver,
            IUnitOfWorkManager unitOfWorkManager,
            IEnumerable<IMigrationStrategy> migrationStrategies,
            IStoveMigrationConfiguration stoveMigrationConfiguration) : base(connectionStringResolver, unitOfWorkManager, migrationStrategies, stoveMigrationConfiguration)
        {
        }

        public override Assembly MigrationAssembly { get; } = Assembly.GetExecutingAssembly();
    }
}
