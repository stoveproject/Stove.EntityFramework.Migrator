using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

using Autofac.Extras.IocManager;

using Stove.Migrator.Tests.Domain.Entities;

namespace Stove.Migrator.Tests.Domain.DbContexes
{
    [DbConfigurationType(typeof(SampleDbContext2Configuration))]
    public class SampleDbContext2 : DbContext, ITransientDependency
    {
        public SampleDbContext2() : base("Default")
        {
        }

        public SampleDbContext2(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public SampleDbContext2(DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection)
        {
        }

        public virtual IDbSet<Product> Products { get; set; }
    }

    public class SampleDbContext2Configuration : DbConfiguration
    {
        public SampleDbContext2Configuration()
        {
            SetProviderServices(
                "System.Data.SqlClient",
                SqlProviderServices.Instance
            );
        }
    }
}
