using Autofac.Extras.IocManager;

using Domain.Data.Migrations.SampleDbContext2;

using Stove.Domain.Uow;

namespace Domain.Data.Migrations
{
    public class SampleDbContext2StoveDbMigrator : StoveDbMigrator<DbContexes.SampleDbContext2, Configuration>
    {
        public SampleDbContext2StoveDbMigrator(IUnitOfWorkManager unitOfWorkManager, IScopeResolver resolver, IConnectionStringResolver connectionStringResolver)
            : base(unitOfWorkManager, resolver, connectionStringResolver)
        {
        }
    }
}
