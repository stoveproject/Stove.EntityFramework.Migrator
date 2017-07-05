using System;

using Autofac.Extras.IocManager;

using Stove.Log;
using Stove.Timing;

namespace Stove.Migrator.Executer
{
    public class Log : ITransientDependency
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Log" /> class.
        /// </summary>
        public Log()
        {
            Logger = NullLogger.Instance;
        }

        /// <summary>
        ///     Gets or sets the logger.
        /// </summary>
        /// <value>
        ///     The logger.
        /// </value>
        public ILogger Logger { get; set; }

        /// <summary>
        ///     Writes the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        public void Write(string text)
        {
            Console.WriteLine(Clock.Now.ToString("yyyy-MM-dd HH:mm:ss") + " | " + text);
            Logger.Info(text);
        }
    }
}
