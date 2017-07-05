using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Reflection;

namespace Stove
{
    public interface IMigrationStrategy
    {
        /// <summary>
        ///     Migrates the specified name or connection string.
        /// </summary>
        /// <typeparam name="TDbContext">The type of the database context.</typeparam>
        /// <typeparam name="TConfiguration">The type of the configuration.</typeparam>
        /// <param name="nameOrConnectionString">The name or connection string.</param>
        /// <param name="migrationAssembly">The migration assembly.</param>
        /// <param name="logger">The logger.</param>
        void Migrate<TDbContext, TConfiguration>(string nameOrConnectionString, Assembly migrationAssembly, Action<string> logger)
            where TDbContext : DbContext
            where TConfiguration : DbMigrationsConfiguration<TDbContext>, new();
    }
}
