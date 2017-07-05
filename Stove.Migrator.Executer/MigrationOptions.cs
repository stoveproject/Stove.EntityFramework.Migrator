using System;

using CommandLine;

namespace Stove.Migrator.Executer
{
    public class MigrationOptions
    {
        [Option('m', "migrationtype", HelpText = "Migration type, can be DbUp, DbContext or DbContextSeed")]
        public string MigrationType { get; set; }

        [Option('h', "persistantstorage", HelpText = "DbContext to store VersionInfo table")]
        public string MigrationPersistentStorageDbContext { get; set; }

        [Option('s', "schema", HelpText = "VersionInfo (also known as _MigrationHistory) table custom schema", DefaultValue = "dbo", Required = false)]
        public string Schema { get; set; }

        [Option('t', "versioninfotablename", HelpText = "VersionInfo (also known as _MigrationHistory) table custom name", DefaultValue = "VersionInfo", Required = false)]
        public string Table { get; set; }

        public bool Is(MigrationType migrationType)
        {
            return string.Equals(MigrationType, migrationType.ToString(), StringComparison.CurrentCultureIgnoreCase);
        }
    }
}