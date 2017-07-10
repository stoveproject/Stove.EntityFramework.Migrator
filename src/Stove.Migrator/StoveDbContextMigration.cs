using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

using Autofac.Extras.IocManager;

using Stove.Timing;
using Stove.Versioning;

namespace Stove
{
    public class StoveDbContextMigration<TDbContext> : ITransientDependency where TDbContext : DbContext
    {
        private readonly IStoveMigrationConfiguration _configuration;
        private readonly IScopeResolver _resolver;
        private readonly IEnumerable<IStoveMigration> _stoveMigrations;

        public StoveDbContextMigration(IScopeResolver resolver,
            IStoveMigrationConfiguration configuration,
            IEnumerable<IStoveMigration> stoveMigrations)
        {
            _resolver = resolver;

            _configuration = configuration;
            _stoveMigrations = stoveMigrations;
        }

        public void Migrate(Action<string> logger = null)
        {
            var dbContext = _resolver.Resolve<TDbContext>();

            CreateVersionInfoTableIfNotExists(dbContext, logger);

            List<VersionInfo> existingVersionInfos = GetVersionInfoTableContent(dbContext, logger);

            foreach (IStoveMigration migration in _stoveMigrations)
            {
                var attributes = Attribute.GetCustomAttributes(migration.GetType(), typeof(StoveVersionInfoAttribute), true) as StoveVersionInfoAttribute[];
                StoveVersionInfoAttribute attribute = attributes?.FirstOrDefault();

                if (attribute != null && existingVersionInfos.All(x => x.Version != attribute.GetVersion()))
                {
                    try
                    {
                        if (!attribute.IsValidEnviroment(_configuration.Enviroment)) return;

                        var versionInfo = new VersionInfo(
                            attribute.GetVersion(), Clock.Now,
                            $"Author: {attribute.GetAuthor()}, Description: {attribute.GetDescription()}"
                        );

                        logger?.Invoke($"Migration is runing with following VersionInfo details: Version: {versionInfo.Version} AppliedOn: {versionInfo.AppliedOn} {versionInfo.Description}");

                        migration.Execute();

                        InsertNewVersionInfoToVersionInfoTable(dbContext, versionInfo, logger);
                    }
                    catch (Exception exception)
                    {
                        logger?.Invoke($"An error occured while migration is runing: {exception}");
                        throw;
                    }
                }
            }
        }

        private void CreateVersionInfoTableIfNotExists(DbContext dbContext, Action<string> logger = null)
        {
            dbContext.Database.ExecuteSqlCommand(TransactionalBehavior.EnsureTransaction,
                $@" IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES
                                             WHERE TABLE_SCHEMA = '{_configuration.Schema}'
                                             AND TABLE_NAME = '{_configuration.Table}'
                                    )
                        )
                        BEGIN
                            CREATE TABLE [{_configuration.Schema}].[{_configuration.Table}] (
                                                                    [Id] [INT] IDENTITY(1,1) PRIMARY KEY,
                                                                    [Version] NVARCHAR(64) NOT NULL,
                                                                    [AppliedOn] [DATETIME] NULL,
                                                                    [Description] NVARCHAR(1024) NULL
                                                                );
                        END;",
                new SqlParameter("@SCHEMA", _configuration.Schema),
                new SqlParameter("@TABLE_NAME", _configuration.Table));
        }

        private List<VersionInfo> GetVersionInfoTableContent(DbContext dbContext, Action<string> logger = null)
        {
            return dbContext.Database.SqlQuery<VersionInfo>($"SELECT [Id], [Version], [AppliedOn], [Description] FROM [{_configuration.Schema}].[{_configuration.Table}]").ToList();
        }

        private void InsertNewVersionInfoToVersionInfoTable(DbContext dbContext, VersionInfo versionInfo, Action<string> logger = null)
        {
            dbContext.Database.ExecuteSqlCommand($@"INSERT INTO [{_configuration.Schema}].[{_configuration.Table}]
                                                               ([Version]
                                                               ,[AppliedOn]
                                                               ,[Description])
                                                                VALUES
                                                               (@VERSION
                                                               ,@APPLIEDON
                                                               ,@DESCRIPTION)",
                new SqlParameter("@VERSION", versionInfo.Version),
                new SqlParameter("@APPLIEDON", versionInfo.AppliedOn),
                new SqlParameter("@DESCRIPTION", versionInfo.Description));
        }
    }
}
