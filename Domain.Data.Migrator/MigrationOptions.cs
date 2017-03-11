using System;

using CommandLine;

namespace Domain.Data.Migrator
{
    public class MigrationOptions
    {
        [Option('m', "migrationtype", Required = true, HelpText = "Migration type, could be DbUp or DbContext")]
        public string MigrationType { get; set; }

        public bool Is(MigrationType migrationType)
        {
            return string.Equals(MigrationType, migrationType.ToString(), StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
