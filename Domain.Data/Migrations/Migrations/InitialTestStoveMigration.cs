using System;

using Stove.Migrator;
using Stove.Migrator.Versioning;

namespace Domain.Data.Migrations.Migrations
{
    [StoveVersionInfo(version:"20170507", author:"Ayberk Cantürk", description:"InitialTestStoveMigration")]
    public class InitialTestStoveMigration : StoveMigration
    {
        public override void Execute()
        {
            Console.WriteLine("test");
        }
    }
}
