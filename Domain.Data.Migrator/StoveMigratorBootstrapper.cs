using Stove.Bootstrapping;

namespace Domain.Data.Migrator
{
    [DependsOn(
        typeof(DataBootstrapper))]
    public class StoveMigratorBootstrapper : StoveBootstrapper
    {
    }
}
