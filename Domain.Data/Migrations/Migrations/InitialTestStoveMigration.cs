using System;

using Stove.Migrator;
using Stove.Migrator.Versioning;

namespace Domain.Data.Migrations.Migrations
{
    [StoveVersionInfo(author: "Ayberk CANTÜRK", description: "Initial Test Stove Migration", version: "201705071543")]
    public class InitialTestStoveMigration : StoveMigration
    {
        public override void Execute()
        {
            Console.WriteLine(@"Migration executed!");
        }
    }
}