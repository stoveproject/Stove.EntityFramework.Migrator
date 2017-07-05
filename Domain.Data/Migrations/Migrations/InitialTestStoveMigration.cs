using System;

using Stove.Migrator;
using Stove.Migrator.Versioning;

namespace Domain.Data.Migrations.Migrations
{
    [StoveVersionInfo(version:"201705071543", author:"Ayberk CANTÜRK", description:"Initial Test Stove Migration")]
    public class InitialTestStoveMigration : StoveMigration
    {
        public override void Execute()
        {
            Console.WriteLine(@"Migration executed!");
        }
    }
}