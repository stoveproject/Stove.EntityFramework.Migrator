using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Domain.Data.Framework
{
    public class DbUpMigrationStrategy : IMigrationStrategy
    {
        public void Migrate<TDbContext, TConfiguration>(string connectionString)
            where TDbContext : DbContext
            where TConfiguration : DbMigrationsConfiguration<TDbContext>, new()
        {
        }
    }
}
