using Autofac.Extras.IocManager;

namespace Stove
{
    public abstract class StoveMigration : IStoveMigration, ITransientDependency
    {
        public abstract void Execute();
    }
}
