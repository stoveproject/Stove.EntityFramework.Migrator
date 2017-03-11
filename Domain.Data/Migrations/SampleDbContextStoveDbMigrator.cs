using Domain.Data.Framework;
using Domain.Data.Migrations.SampleDbContext;

using Stove.Domain.Uow;

namespace Domain.Data.Migrations
{
    public class SampleDbContextStoveDbMigrator : StoveDbMigrator<DbContexes.SampleDbContext, Configuration>
    {
        public SampleDbContextStoveDbMigrator(IConnectionStringResolver connectionStringResolver, IMigrationStrategy migrationStrategy)
            : base(connectionStringResolver)
        {
        }
    }
}
