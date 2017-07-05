using System;
using System.Reflection;

namespace Stove
{
    public interface IStoveDbMigrator
    {
        string CurrentDbContextName { get; }

        string CurrentDbConfigurationName { get; }

        Assembly MigrationAssembly { get; }

        void CreateOrMigrate(Action<string> logger);
    }
}
