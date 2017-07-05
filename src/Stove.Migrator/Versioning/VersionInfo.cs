using System;
using System.ComponentModel.DataAnnotations.Schema;

using Stove.Domain.Entities;

namespace Stove.Versioning
{
    [Table("VersionInfo")]
    public class VersionInfo : Entity
    {
        protected VersionInfo()
        {
        }

        public VersionInfo(string version, DateTime appliedOn, string description) : this()
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
