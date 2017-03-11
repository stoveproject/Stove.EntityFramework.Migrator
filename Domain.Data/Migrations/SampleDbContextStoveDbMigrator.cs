using System.Collections.Generic;
using System.Reflection;

using Domain.Data.Migrations.SampleDbContext;

using Stove.Domain.Uow;
using Stove.Migrator;

namespace Domain.Data.Migrations
{
    public class SampleDbContextStoveDbMigrator : StoveDbMigrator<DbContexes.SampleDbContext, Configuration>
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
