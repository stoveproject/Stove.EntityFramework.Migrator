using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stove.Migrator.Migrations
{
    public class StoveTestMigration : StoveMigration
    {
        public StoveTestMigration()
        {
            
        }

        public override void Execute()
        {
            Console.WriteLine("test");
        }
    }
}
