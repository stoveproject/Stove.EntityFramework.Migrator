using System;
using System.Linq;

namespace Stove.Versioning
{
    [AttributeUsage(AttributeTargets.Class)]
    public class StoveVersionInfoAttribute : Attribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="StoveVersionInfoAttribute" /> class.
        /// </summary>
        /// <param name="author">The author.</param>
        /// <param name="description">The description.</param>
        /// <param name="version">The version.</param>
        /// <param name="enviroments">Valid enviroments for the migration.</param>
        public StoveVersionInfoAttribute(string author, string description, string version, params string[] enviroments)
        {
            Version = version;
            Author = author;
            Description = description;
            Enviroments = enviroments;
        }

        /// <summary>
        ///     Gets the version.
        /// </summary>
        /// <value>
        ///     The version.
        /// </value>
        private string Version { get; }

        /// <summary>
        ///     Gets the author.
        /// </summary>
        /// <value>
        ///     The author.
        /// </value>
        private string Author { get; }

        /// <summary>
        ///     Gets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        private string Description { get; }

        /// <summary>
        ///     Gets the enviroment.
        /// </summary>
        /// <value>
        ///     The enviroment.
        /// </value>
        private string[] Enviroments { get; }

        /// <summary>
        ///     Gets the version.
        /// </summary>
        /// <returns></returns>
        public string GetVersion()
        {
            return Version;
        }

        /// <summary>
        ///     Gets the author.
        /// </summary>
        /// <returns></returns>
        public string GetAuthor()
        {
            return Author;
        }

        /// <summary>
        ///     Gets the description.
        /// </summary>
        /// <returns></returns>
        public string GetDescription()
        {
            return Description;
        }

        /// <summary>
        ///     Gets the enviroments
        /// </summary>
        /// <returns></returns>
        public string[] GetEnviroments()
        {
            return Enviroments;
        }

        /// <summary>
        ///     Gets the enviroment.
        /// </summary>
        /// <returns></returns>
        public bool IsValidEnviroment(string enviroment)
        {
            return ((Enviroments == null || !Enviroments.Any()) && string.IsNullOrEmpty(enviroment)) ||  (Enviroments != null && Enviroments.Contains(enviroment));
        }
    }
}
