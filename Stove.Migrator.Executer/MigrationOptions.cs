using System;

using CommandLine;

namespace Stove.Migrator.Executer
{
    public class MigrationOptions
    {
        [Option('m', "migrationtype", HelpText = "Migration type, could be DbUp or DbContext")]
        public string MigrationType { get; set; }

        public bool Is(MigrationType migrationType)
        {
            return string.Equals(MigrationType, migrationType.ToString(), StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
