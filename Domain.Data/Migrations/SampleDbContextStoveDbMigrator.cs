using Autofac.Extras.IocManager;

using Domain.Data.Migrations.SampleDbContext;

using Stove.Domain.Uow;

namespace Domain.Data.Migrations
{
    public class SampleDbContextStoveDbMigrator : StoveDbMigrator<DbContexes.SampleDbContext, Configuration>
    {
        public SampleDbContextStoveDbMigrator(IUnitOfWorkManager unitOfWorkManager, IScopeResolver resolver, IConnectionStringResolver connectionStringResolver)
            : base(unitOfWorkManager, resolver, connectionStringResolver)
        {

        }
    }
}
