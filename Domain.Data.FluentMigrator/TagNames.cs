namespace Domain.Data.FluentMigrator
{
    public static class TagNames
    {
        public static class Environment
        {
            public const string Dev = "Dev";
            public const string Production = "Production";
            public const string Stage = "Stage";
        }

        public static class Country
        {
            public const string Default = "Default";
            public const string Italy = "Italy";
        }

        public static class Database
        {
            public const string OneAdminDatabase = "OneAdminDatabase";
            public const string NewAdminDatabase = "NewAdminDatabase";
            public const string WebAdminDatabase = "WebAdminDatabase";
            public const string TYDatabase = "TYDatabase";
        }
    }
}
