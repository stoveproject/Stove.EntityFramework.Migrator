namespace Domain.Data
{
    public interface IStoveDbMigrator
    {
        string CurrentDbContextName { get; }
        string CurrentDbConfigurationName { get; }

        void CreateOrMigrate();
    }
}
