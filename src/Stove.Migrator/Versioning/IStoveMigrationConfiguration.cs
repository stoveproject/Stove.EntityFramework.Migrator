namespace Stove.Versioning
{
    public interface IStoveMigrationConfiguration
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

        /// <summary>
        /// Gets or sets the transaction timeout
        /// </summary>
        /// <value>
        /// The transaction timeout value in seconds
        /// </value>
        int TransactionTimeout { get; set; }
    }
}
