using System;

namespace Stove.Migrator.Versioning
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class StoveVersionInfoAttribute : Attribute
    {
        public StoveVersionInfoAttribute(string author, string description, string version)
        {
            Version = version;
            Author = author;
            Description = description;
        }

        private string Version { get; }

        private string Author { get; }

        private string Description { get; }

        public string GetVersion()
        {
            return Version;
        }

        public string GetAuthor()
        {
            return Author;
        }

        public string GetDescription()
        {
            return Description;
        }
    }
}
