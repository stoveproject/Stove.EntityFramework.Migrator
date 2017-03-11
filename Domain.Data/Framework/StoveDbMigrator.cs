using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;

using Autofac.Extras.IocManager;

using Stove.Domain.Uow;
using Stove.Extensions;

namespace Domain.Data.Framework
{
    public abstract class StoveDbMigrator<TDbContext, TConfiguration> : IStoveDbMigrator, ITransientDependency
        where TDbContext : DbContext
        where TConfiguration : DbMigrationsConfiguration<TDbContext>, new()
    {
        private readonly IConnectionStringResolver _connectionStringResolver;
        private readonly IEnumerable<IMigrationStrategy> _migrationStrategies;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        protected StoveDbMigrator(
            IConnectionStringResolver connectionStringResolver,
            IUnitOfWorkManager unitOfWorkManager,
            IEnumerable<IMigrationStrategy> migrationStrategies)
        {
            _connectionStringResolver = connectionStringResolver;

            _unitOfWorkManager = unitOfWorkManager;
            _migrationStrategies = migrationStrategies;
            CurrentDbContextName = typeof(TDbContext).FullName;
            CurrentDbConfigurationName = typeof(TConfiguration).FullName;
        }

        public virtual void CreateOrMigrate()
        {
            var args = new ConnectionStringResolveArgs();
            args["DbContextType"] = typeof(TDbContext);
            args["DbContextConcreteType"] = typeof(TDbContext);

            string nameOrConnectionString = _connectionStringResolver.GetNameOrConnectionString(args);

            using (IUnitOfWorkCompleteHandle uow = _unitOfWorkManager.Begin())
            {
                _migrationStrategies.ForEach(strategy => strategy.Migrate<TDbContext, TConfiguration>(nameOrConnectionString));

                _unitOfWorkManager.Current.SaveChanges();
                uow.Complete();
            }
        }

        public string CurrentDbContextName { get; }

        public string CurrentDbConfigurationName { get; }
    }
}
