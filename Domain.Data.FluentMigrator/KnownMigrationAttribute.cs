using System;

using FluentMigrator;

namespace Domain.Data.FluentMigrator
{
    public class KnownMigrationAttribute : MigrationAttribute
    {
        public KnownMigrationAttribute(string author, string jiraIssueOrBranchName, Type migrationType, int year, int month, int day, int hour, int minute)
            : base(CalculateValue(jiraIssueOrBranchName.GetHashCode(), year, month, day, hour, minute), GenerateDescription(author, migrationType))
        {
            Author = author;
        }

        public string Author { get; private set; }

        private static string GenerateDescription(string author, Type migrationType)
        {
            return $"Author:{author}, Migration:{migrationType.Name}";
        }

        private static long CalculateValue(int jiraIssueOrBranchNameHash, int year, int month, int day, int hour, int minute)
        {
            return jiraIssueOrBranchNameHash * 1000000000000L + year * 100000000L + month * 1000000L + day * 10000L + hour * 100L + minute;
        }
    }
}
