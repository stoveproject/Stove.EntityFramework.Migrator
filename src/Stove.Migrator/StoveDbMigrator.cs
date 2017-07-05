using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Reflection;

using Autofac.Extras.IocManager;

using Stove.Domain.Uow;
using Stove.Extensions;

namespace Stove
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
            CurrentDbContextName = typeof(TDbContext).GetTypeInfo().Name;
            CurrentDbConfigurationName = typeof(TConfiguration).GetTypeInfo().Name;
        }

        public virtual void CreateOrMigrate(Action<string> logger)
        {
            var args = new ConnectionStringResolveArgs();
            args["DbContextType"] = typeof(TDbContext);
            args["DbContextConcreteType"] = typeof(TDbContext);

            string nameOrConnectionString = ConnectionStringHelper.GetConnectionString(
                _connectionStringResolver.GetNameOrConnectionString(args)
            );

            logger($"Name or ConnectionString: {nameOrConnectionString}\nCurrent DbContext: {typeof(TDbContext).GetTypeInfo().Name}");

            using (IUnitOfWorkCompleteHandle uow = _unitOfWorkManager.Begin())
            {
                _migrationStrategies.ForEach(strategy =>
                {
                    logger("--------------------------------------------------------");

                    strategy.Migrate<TDbContext, TConfiguration>(nameOrConnectionString, MigrationAssembly, logger);

                });

                _unitOfWorkManager.Current.SaveChanges();
                uow.Complete();
            }
        }

        public string CurrentDbContextName { get; }

        public string CurrentDbConfigurationName { get; }

        public abstract Assembly MigrationAssembly { get; }
    }
}
