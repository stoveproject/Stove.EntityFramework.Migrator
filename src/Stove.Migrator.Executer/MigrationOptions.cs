using System;

using CommandLine;

namespace Stove.Migrator.Executer
{
    public class MigrationOptions
    {
        /// <summary>
        ///     Gets or sets the type of the migration.
        /// </summary>
        /// <value>
        ///     The type of the migration.
        /// </value>
        [Option('m', "migrationtype", HelpText = "Migration type, can be DbUp, DbContext or DbContextSeed")]
        public string MigrationType { get; set; }

        /// <summary>
        ///     Gets or sets the migration persistent storage database context.
        /// </summary>
        /// <value>
        ///     The migration persistent storage database context.
        /// </value>
        [Option('h', "persistentstorage", HelpText = "DbContext to store VersionInfo table")]
        public string MigrationPersistentStorageDbContext { get; set; }

        /// <summary>
        ///     Gets or sets the schema.
        /// </summary>
        /// <value>
        ///     The schema.
        /// </value>
        [Option('s', "schema", HelpText = "VersionInfo (also known as _MigrationHistory) table custom schema", DefaultValue = "dbo", Required = false)]
        public string Schema { get; set; }

        /// <summary>
        ///     Gets or sets the table.
        /// </summary>
        /// <value>
        ///     The table.
        /// </value>
        [Option('t', "versioninfotablename", HelpText = "VersionInfo (also known as _MigrationHistory) table custom name", DefaultValue = "StoveVersionInfo", Required = false)]
        public string Table { get; set; }

        /// <summary>
        ///     Determines whether [is] [the specified migration type].
        /// </summary>
        /// <param name="migrationType">Type of the migration.</param>
        /// <returns>
        ///     <c>true</c> if [is] [the specified migration type]; otherwise, <c>false</c>.
        /// </returns>
        public bool Is(MigrationType migrationType)
        {
            return string.Equals(MigrationType, migrationType.ToString(), StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
