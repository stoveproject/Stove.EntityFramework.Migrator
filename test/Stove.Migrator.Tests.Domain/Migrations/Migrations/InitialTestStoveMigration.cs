using System;

using Stove.Versioning;

namespace Stove.Migrator.Tests.Domain.Migrations.Migrations
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