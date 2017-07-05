using Autofac.Extras.IocManager;

namespace Stove.Migrator
{
    public abstract class StoveMigration : IStoveMigration, ITransientDependency
    {
        public abstract void Execute();
    }
}
