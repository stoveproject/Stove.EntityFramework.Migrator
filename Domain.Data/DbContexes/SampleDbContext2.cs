using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

using Domain.Data.Entities;

using Stove.EntityFramework.EntityFramework;

namespace Domain.Data.DbContexes
{
    [DbConfigurationType(typeof(SampleDbContext2Configuration))]
    public class SampleDbContext2 : StoveDbContext
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
