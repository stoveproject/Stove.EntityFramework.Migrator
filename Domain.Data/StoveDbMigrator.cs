using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Transactions;

using Autofac.Extras.IocManager;

using Stove.Domain.Uow;

namespace Domain.Data
{
    public abstract class StoveDbMigrator<TDbContext, TConfiguration> : IStoveDbMigrator, ITransientDependency
        where TDbContext : DbContext
        where TConfiguration : DbMigrationsConfiguration<TDbContext>, new()
    {
        private readonly IConnectionStringResolver _connectionStringResolver;
        private readonly IScopeResolver _resolver;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        protected StoveDbMigrator(IUnitOfWorkManager unitOfWorkManager, IScopeResolver resolver, IConnectionStringResolver connectionStringResolver)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _resolver = resolver;
            _connectionStringResolver = connectionStringResolver;
        }

        public virtual void CreateOrMigrate()
        {
            var args = new ConnectionStringResolveArgs();

            args["DbContextType"] = typeof(TDbContext);
            args["DbContextConcreteType"] = typeof(TDbContext);

            string nameOrConnectionString = ConnectionStringHelper.GetConnectionString(
                _connectionStringResolver.GetNameOrConnectionString(args)
            );

            using (IUnitOfWorkCompleteHandle uow = _unitOfWorkManager.Begin(TransactionScopeOption.Suppress))
            {
                using (IScopeResolver scope = _resolver.BeginScope())
                {
                    var dbContext = scope.Resolve<TDbContext>(new { nameOrConnectionString });
                    var dbInitializer = new MigrateDatabaseToLatestVersion<TDbContext, TConfiguration>(
                        true,
                        new TConfiguration());

                    dbInitializer.InitializeDatabase(dbContext);

                    _unitOfWorkManager.Current.SaveChanges();
                    uow.Complete();
                }
            }
        }
    }
}
