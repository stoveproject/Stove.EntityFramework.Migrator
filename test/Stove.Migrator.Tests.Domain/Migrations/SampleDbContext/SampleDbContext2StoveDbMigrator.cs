using System.Collections.Generic;
using System.Reflection;

using Stove.Domain.Uow;
using Stove.Versioning;

namespace Stove.Migrator.Tests.Domain.Migrations.SampleDbContext
{
    public class SampleDbContext2StoveDbMigrator : StoveDbMigrator<DbContexes.SampleDbContext2, SampleDbContext2.Configuration>
    {
        public SampleDbContext2StoveDbMigrator(
            IConnectionStringResolver connectionStringResolver,
            IUnitOfWorkManager unitOfWorkManager,
            IEnumerable<IMigrationStrategy> migrationStrategies,
            IStoveMigrationConfiguration stoveMigrationConfiguration) : base(connectionStringResolver, unitOfWorkManager, migrationStrategies, stoveMigrationConfiguration) 
        {
        }

        public override Assembly MigrationAssembly { get; } = Assembly.GetExecutingAssembly();
    }
}
