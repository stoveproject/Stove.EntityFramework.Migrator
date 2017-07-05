using System;
using System.Reflection;

namespace Stove
{
    public interface IStoveDbMigrator
    {
        /// <summary>
        ///     Gets the name of the current database context.
        /// </summary>
        /// <value>
        ///     The name of the current database context.
        /// </value>
        string CurrentDbContextName { get; }

        /// <summary>
        ///     Gets the name of the current database configuration.
        /// </summary>
        /// <value>
        ///     The name of the current database configuration.
        /// </value>
        string CurrentDbConfigurationName { get; }

        /// <summary>
        ///     Gets the migration assembly.
        /// </summary>
        /// <value>
        ///     The migration assembly.
        /// </value>
        Assembly MigrationAssembly { get; }

        /// <summary>
        ///     Creates the or migrate.
        /// </summary>
        /// <param name="logger">The logger.</param>
        void CreateOrMigrate(Action<string> logger);
    }
}
