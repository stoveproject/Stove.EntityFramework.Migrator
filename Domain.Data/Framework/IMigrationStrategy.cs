using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Domain.Data.Framework
{
    public interface IMigrationStrategy
    {
        void Migrate<TDbContext, TConfiguration>(string nameOrConnectionString)
            where TDbContext : DbContext
            where TConfiguration : DbMigrationsConfiguration<TDbContext>, new();
    }
}
