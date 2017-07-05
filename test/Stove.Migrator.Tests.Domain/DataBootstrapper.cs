using Stove.Bootstrapping;
using Stove.Migrator.Tests.Domain.DbContexes;

namespace Stove.Migrator.Tests.Domain
{
    public class DataBootstrapper : StoveBootstrapper
    {
        public override void PreStart()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
            Configuration.TypedConnectionStrings.Add(typeof(SampleDbContext), "Default");
            Configuration.TypedConnectionStrings.Add(typeof(SampleDbContext2), "Default");
        }
    }
}
