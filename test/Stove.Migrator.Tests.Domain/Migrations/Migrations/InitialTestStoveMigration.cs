using System;

using Stove.Versioning;

namespace Stove.Migrator.Tests.Domain.Migrations.Migrations
{
    [StoveVersionInfo("Ayberk CANTÜRK", "Initial Test Stove Migration", "201705071543")]
    [Enviroment(ExecuteOn.All, Enviroments.Dev)]
    public class InitialTestStoveMigration : StoveMigration
    {
        public override void Execute()
        {
            Console.WriteLine(@"Migration executed!");
        }
    }
}