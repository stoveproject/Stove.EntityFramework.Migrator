using System;

using FluentMigrator;

namespace Stove.Migrator.Tests.Domain.FluentMigrator
{
    public class KnownMigrationAttribute : MigrationAttribute
    {
        public KnownMigrationAttribute(string author, string issueName, Type migrationType, int year, int month, int day, int hour, int minute)
            : base(CalculateValue(issueName.GetHashCode(), year, month, day, hour, minute), GenerateDescription(author, issueName, migrationType))
        {
            Author = author;
        }

        public string Author { get; }

        private static string GenerateDescription(string author, string issueName, Type migrationType)
        {
            return $"Author:{author}, Issue:{issueName}, Migration:{migrationType.Name}";
        }

        private static long CalculateValue(int issueName, int year, int month, int day, int hour, int minute)
        {
            return issueName * 1000000000000L + year * 100000000L + month * 1000000L + day * 10000L + hour * 100L + minute;
        }
    }
}
