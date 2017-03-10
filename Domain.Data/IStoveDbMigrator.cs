namespace Domain.Data
{
    public interface IStoveDbMigrator
    {
        void CreateOrMigrate();
    }
}