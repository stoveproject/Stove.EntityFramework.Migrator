using Domain.Data.Framework;
using Domain.Data.Migrations.SampleDbContext2;

using Stove.Domain.Uow;

namespace Domain.Data.Migrations
{
    public class SampleDbContext2StoveDbMigrator : StoveDbMigrator<DbContexes.SampleDbContext2, Configuration>
    {
        public SampleDbContext2StoveDbMigrator(IConnectionStringResolver connectionStringResolver, IMigrationStrategy migrationStrategy)
            : base(connectionStringResolver)
        {
        }
    }
}
