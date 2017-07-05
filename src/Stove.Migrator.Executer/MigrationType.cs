namespace Stove.Migrator.Executer
{
    public enum MigrationType
    {
        /// <summary>
        ///     The database up{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        DbUp = 1,

        /// <summary>
        ///     The database context{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        DbContext = 2,

        /// <summary>
        ///     The database context seed{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        DbContextSeed = 3
    }
}
