namespace Stove.Migrator.Versioning
{
    public interface IStoveVersionInfoConfiguration
    {
        string Schema { get; set; }

        string Table { get; set; }
    }
}
