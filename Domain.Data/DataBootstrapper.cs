using Domain.Data.DbContexes;

using Stove.Bootstrapping;

namespace Domain.Data
{
    public class DataBootstrapper : StoveBootstrapper
    {
        public override void Start()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
            Configuration.TypedConnectionStrings.Add(typeof(SampleDbContext), "Default");
            Configuration.TypedConnectionStrings.Add(typeof(SampleDbContext2), "Default");
        }
    }
}
