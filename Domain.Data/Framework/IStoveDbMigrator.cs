namespace Domain.Data.Framework
{
    public interface IStoveDbMigrator
    {
        string CurrentDbContextName { get; }

        string CurrentDbConfigurationName { get; }

        void CreateOrMigrate();
    }
}
