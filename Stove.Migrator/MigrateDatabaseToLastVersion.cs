using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;

using Autofac.Extras.IocManager;

using Stove.Domain.Uow;
using Stove.Migrator.Versioning;

namespace Stove.Migrator
{
    public class MigrateDatabaseToLastVersion<TDbContext> : ITransientDependency where TDbContext : DbContext
    {
        private readonly StoveVersionInfoConfiguration _configuration;
        private readonly IScopeResolver _resolver;
        private readonly IEnumerable<StoveMigration> _stoveMigrations;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public MigrateDatabaseToLastVersion(IScopeResolver resolver,
            IUnitOfWorkManager unitOfWorkManager,
            StoveVersionInfoConfiguration configuration,
            IEnumerable<StoveMigration> stoveMigrations)
        {
            _resolver = resolver;
            _unitOfWorkManager = unitOfWorkManager;
            _configuration = configuration;
            _stoveMigrations = stoveMigrations;
        }

        public void InitializeDatabase(Action<string> logger = null)
        {
            //Type type = _resolver.GetRegisteredServices().First(x => x.Name == _configuration.PersistentStorageDbContextName);
            //var dbContextHasVersionInfo = (TDbContext)_resolver.Resolve(type);
            var dbContextHasVersionInfo = _resolver.Resolve<TDbContext>(new { PersistantStorageDbContextName = _configuration.PersistentStorageDbContextName });

            string initialSqlCmd = $"IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = '@SCHEMA' AND  TABLE_NAME = '@TABLE_NAME')) BEGIN CREATE TABLE [@SCHEMA].[@TABLE_NAME]([Id] [INT] PRIMARY_KEY), [Version] [BIGINT] NOT NULL, [AppliedOn] [DATETIME] NULL, [Description] [NVHARCHAR](1024) NULL END";
            dbContextHasVersionInfo.Database.ExecuteSqlCommand(TransactionalBehavior.EnsureTransaction,
                initialSqlCmd,
                new SqlParameter("@SCHEMA", _configuration.Schema),
                new SqlParameter("@TABLE_NAME", _configuration.TableName));

            List<VersionInfo> existingVersionInfos =  dbContextHasVersionInfo.Set<VersionInfo>().SqlQuery($"SELECT [Id], [Version], [AppliedOn], [Description] FROM {_configuration.TableName}").ToList();

            foreach (StoveMigration migration in _stoveMigrations)
            {
                var attributes = Attribute.GetCustomAttributes(migration.GetType(), typeof(StoveVersionInfoAttribute), true) as StoveVersionInfoAttribute[];
                StoveVersionInfoAttribute attribute = attributes?.FirstOrDefault();

                if (attribute != null && existingVersionInfos.All(x => x.Version != attribute.GetVersion()))
                {
                    using (IUnitOfWorkCompleteHandle uow = _unitOfWorkManager.Begin())
                    {
                        try
                        {
                            var versionInfo = new VersionInfo(
                                attribute.GetVersion(), DateTime.UtcNow,
                                $"Author: {attribute.GetAuthor()} Description: {attribute.GetDescription()}"
                            );

                            logger?.Invoke($"Migration runing with following VersionInfo details: Version: {versionInfo.Version} AppliedOn: {versionInfo.AppliedOn} Author: {versionInfo.Description}");
                            migration.Execute();

                            dbContextHasVersionInfo.Set<VersionInfo>().Add(versionInfo);
                            dbContextHasVersionInfo.SaveChanges();
                        }
                        catch (Exception exception)
                        {
                            logger?.Invoke($"An error occured while migration runing: {exception.ToString()}");
                            throw;
                        }

                        _unitOfWorkManager.Current.SaveChanges();
                        uow.Complete();
                    }
                }
            }
        }
    }
}
