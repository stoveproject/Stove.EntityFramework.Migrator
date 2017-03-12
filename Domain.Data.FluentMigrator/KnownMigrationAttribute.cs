using FluentMigrator;

namespace Domain.Data.FluentMigrator
{
    public class KnownMigrationAttribute : MigrationAttribute
    {
        public KnownMigrationAttribute(long version)
            : base(version)
        {
        }

        public KnownMigrationAttribute(long version, string jiraIssueName)
            : base(version, jiraIssueName)
        {
        }

        public KnownMigrationAttribute(long version, TransactionBehavior transactionBehavior)
            : base(version, transactionBehavior)
        {
        }

        public KnownMigrationAttribute(long version, TransactionBehavior transactionBehavior, string jiraIssueName)
            : base(version, transactionBehavior, jiraIssueName)
        {
        }
    }
}
