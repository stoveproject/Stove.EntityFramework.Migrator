using Autofac.Extras.IocManager;

namespace Stove.Migrator
{
    public abstract class StoveMigration : ITransientDependency
    {
        public abstract void Execute();
    }
}
