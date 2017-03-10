using System;

using Autofac.Extras.IocManager;

using Stove.Log;
using Stove.Timing;

namespace Domain.Data.Migrator
{
    public class Log : ITransientDependency
    {
        public Log()
        {
            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        public void Write(string text)
        {
            Console.WriteLine(Clock.Now.ToString("yyyy-MM-dd HH:mm:ss") + " | " + text);
            Logger.Info(text);
        }
    }
}
