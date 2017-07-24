using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

using Autofac.Extras.IocManager;

using Stove.Collections.Extensions;
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
                StoveVersionInfoAttribute[] stoveVersionInfoAttributes = migration.GetType().GetCustomAttributes<StoveVersionInfoAttribute>().ToArray();
                if (!stoveVersionInfoAttributes.Any())
                {
                    logger?.Invoke($"No version attribute found in migration file.");
                    continue;
                }

                StoveVersionInfoAttribute stoveVersionInfoAttribute = stoveVersionInfoAttributes.First();

                var enviromentAttribute = migration.GetType().GetCustomAttribute<EnviromentAttribute>();
                if (stoveVersionInfoAttribute != null && existingVersionInfos.All(x => x.Version != stoveVersionInfoAttribute.GetVersion()))
                {
                    try
                    {
                        if (_configuration.Enviroment != null)
                        {
                            if (enviromentAttribute != null && !enviromentAttribute.IsValidEnviroment(_configuration.Enviroment))
                            {
                                logger?.Invoke($"Enviroment is not valid for this migration.");
                                continue;
                            }
                        }

                        bool workWithoutEnvironment = enviromentAttribute == null && _configuration.Enviroment == null;
                        bool workWithEnvironment = enviromentAttribute != null && !_configuration.Enviroment.IsNullOrEmpty() && enviromentAttribute.IsValidEnviroment(_configuration.Enviroment);

                        if (workWithoutEnvironment || workWithEnvironment)
                        {
                            var versionInfo = new VersionInfo(stoveVersionInfoAttribute.GetVersion(), Clock.Now,
                                $"Author: {stoveVersionInfoAttribute.GetAuthor()}, Description: {stoveVersionInfoAttribute.GetDescription()}"
                            );

                            logger?.Invoke($"Migration is runing with following VersionInfo details: Version: {versionInfo.Version} AppliedOn: {versionInfo.AppliedOn} {versionInfo.Description}");

                            migration.Execute();

                            InsertNewVersionInfoToVersionInfoTable(dbContext, versionInfo, logger);
                        }
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
