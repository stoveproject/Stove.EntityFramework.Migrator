using System;

using Stove.Versioning;

namespace Stove.Migrator.Tests.Domain.Migrations.Migrations
{
    [StoveVersionInfo("Ayberk CANTÜRK", "Initial Test Stove Migration", "201705071543")]
    [Enviroment(ExecuteOn.Any, Enviroments.Dev, Enviroments.Stage, Enviroments.Production)]
    public class InitialTestStoveMigration : StoveMigration
    {
        public override void Execute()
        {
            Console.WriteLine(@"Migration executed!");
        }
    }
}