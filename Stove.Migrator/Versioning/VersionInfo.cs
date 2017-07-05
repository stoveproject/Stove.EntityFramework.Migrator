using System;

using Stove.Domain.Entities;

namespace Stove.Migrator.Versioning
{
    public class VersionInfo : Entity
    {
        public VersionInfo(string version, DateTime appliedOn, string description)
        {
            Version = version;
            AppliedOn = appliedOn;
            Description = description;
        }

        public string Version { get; protected set; }

        public DateTime AppliedOn { get; protected set; }

        public string Description { get; protected set; }
    }
}