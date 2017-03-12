using System;

using Domain.Data;

using Stove.Bootstrapping;

namespace Stove.Migrator.Executer
{
    [DependsOn(
        typeof(DataBootstrapper))]
    public class StoveMigratorBootstrapper : StoveBootstrapper
    {
        public override void Shutdown()
        {
            Console.WriteLine("Stove.Migrator.Executer shutting down...");
        }
    }
}
