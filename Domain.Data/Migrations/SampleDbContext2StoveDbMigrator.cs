using System.Collections.Generic;

using Domain.Data.Framework;
using Domain.Data.Migrations.SampleDbContext2;

using Stove.Domain.Uow;

namespace Domain.Data.Migrations
{
    public class SampleDbContext2StoveDbMigrator : StoveDbMigrator<DbContexes.SampleDbContext2, Configuration>
    {
        public SampleDbContext2StoveDbMigrator(
            IConnectionStringResolver connectionStringResolver,
            IUnitOfWorkManager unitOfWorkManager,
            IEnumerable<IMigrationStrategy> migrationStrategies) : base(connectionStringResolver, unitOfWorkManager, migrationStrategies)
        {
        }
    }
}
