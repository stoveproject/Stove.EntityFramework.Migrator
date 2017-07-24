using System;
using System.Collections.Generic;
using System.Linq;

namespace Stove.Versioning
{
    [AttributeUsage(AttributeTargets.Class)]
    public class EnviromentAttribute : Attribute
    {
        public EnviromentAttribute(ExecuteOn executionType = ExecuteOn.Any, params string[] enviroments)
        {
            ExecutionType = executionType;
            Enviroments = enviroments;
        }

        private string[] Enviroments { get; }

        private ExecuteOn ExecutionType { get; }

        public bool IsValidEnviroment(params string[] enviroments)
        {
            Check.NotNull(enviroments, nameof(enviroments));

            return ExecutionType == ExecuteOn.Any && Enviroments.Any(row => Enviroments.Contains(row)) || ExecutionType == ExecuteOn.All && ContainsAll(enviroments, Enviroments);

            bool ContainsAll<T>(IEnumerable<T> source, IEnumerable<T> values)
            {
                return values.All(source.Contains);
            }
        }
    }
}
