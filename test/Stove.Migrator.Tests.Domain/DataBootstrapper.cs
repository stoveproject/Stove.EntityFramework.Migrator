using Stove.Bootstrapping;
using Stove.Migrator.Tests.Domain.DbContexes;

namespace Stove.Migrator.Tests.Domain
{
    public class DataBootstrapper : StoveBootstrapper
    {
        public override void PreStart()
        {
            StoveConfiguration.DefaultNameOrConnectionString = "Default";
            StoveConfiguration.TypedConnectionStrings.Add(typeof(SampleDbContext), "Default");
            StoveConfiguration.TypedConnectionStrings.Add(typeof(SampleDbContext2), "Default");
        }
    }
}
