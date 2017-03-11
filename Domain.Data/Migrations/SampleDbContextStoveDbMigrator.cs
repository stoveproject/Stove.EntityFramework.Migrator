using System.Collections.Generic;

using Domain.Data.Framework;
using Domain.Data.Migrations.SampleDbContext;

using Stove.Domain.Uow;

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
    }
}
