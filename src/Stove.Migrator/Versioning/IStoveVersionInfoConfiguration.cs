namespace Stove.Versioning
{
    public interface IStoveVersionInfoConfiguration
    {
        /// <summary>
        ///     Gets or sets the schema.
        /// </summary>
        /// <value>
        ///     The schema.
        /// </value>
        string Schema { get; set; }

        /// <summary>
        ///     Gets or sets the table.
        /// </summary>
        /// <value>
        ///     The table.
        /// </value>
        string Table { get; set; }
    }
}
