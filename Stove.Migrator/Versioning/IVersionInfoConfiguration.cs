namespace Stove.Migrator.Versioning
{
    public interface IVersionInfoConfiguration
    {
        string PersistentStorageDbContextName { get; }

        string Schema { get; }

        string TableName { get; }
    }
}
