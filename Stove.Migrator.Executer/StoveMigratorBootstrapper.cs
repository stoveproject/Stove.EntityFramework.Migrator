using Domain.Data;

using Stove.Bootstrapping;

namespace Stove.Migrator.Executer
{
    [DependsOn(
        typeof(DataBootstrapper))]
    public class StoveMigratorBootstrapper : StoveBootstrapper
    {
    }
}
