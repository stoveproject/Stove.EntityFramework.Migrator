using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

using Autofac.Extras.IocManager;

using Domain.Data.Entities;

namespace Domain.Data.DbContexes
{
    [DbConfigurationType(typeof(SampleDbContextConfiguration))]
    public class SampleDbContext : DbContext, ITransientDependency
    {
        public SampleDbContext() : base("Default")
        {
        }

        public SampleDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public SampleDbContext(DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection)
        {
        }

        public virtual IDbSet<User> Users { get; set; }
    }

    public class SampleDbContextConfiguration : DbConfiguration
    {
        public SampleDbContextConfiguration()
        {
            SetProviderServices(
                "System.Data.SqlClient",
                SqlProviderServices.Instance
            );
        }
    }
}
