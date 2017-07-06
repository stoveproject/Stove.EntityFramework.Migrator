using System;

using Stove.Bootstrapping;
using Stove.Migrator.Tests.Domain;
using Stove.Versioning;

namespace Stove.Migrator.Executer
{
    [DependsOn(
        typeof(DataBootstrapper))]
    public class StoveMigratorBootstrapper : StoveBootstrapper
    {
        public override void PreStart()
        {
            Configuration.GetConfigurerIfExists<IStoveMigrationConfiguration>()(Resolver.Resolve<IStoveMigrationConfiguration>());
        }

        public override void Shutdown()
        {
            Console.WriteLine("Stove.Migrator.Executer shutting down...");
        }
    }
}
