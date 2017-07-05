using System;
using System.ComponentModel.DataAnnotations.Schema;

using Stove.Domain.Entities;

namespace Stove.Versioning
{
    [Table("VersionInfo")]
    public class VersionInfo : Entity
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="VersionInfo" /> class.
        /// </summary>
        protected VersionInfo()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="VersionInfo" /> class.
        /// </summary>
        /// <param name="version">The version.</param>
        /// <param name="appliedOn">The applied on.</param>
        /// <param name="description">The description.</param>
        public VersionInfo(string version, DateTime appliedOn, string description) : this()
        {
            Version = version;
            AppliedOn = appliedOn;
            Description = description;
        }

        /// <summary>
        ///     Gets or sets the version.
        /// </summary>
        /// <value>
        ///     The version.
        /// </value>
        public string Version { get; protected set; }

        /// <summary>
        ///     Gets or sets the applied on.
        /// </summary>
        /// <value>
        ///     The applied on.
        /// </value>
        public DateTime AppliedOn { get; protected set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string Description { get; protected set; }
    }
}
