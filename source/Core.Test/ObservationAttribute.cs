using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;

namespace Xunit
{
    public class ObservationAttribute : FactAttribute
    {
        /// <summary>
        /// Returns the created test.
        /// </summary>
        /// <param name="method">
        /// The marked test method.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{ITestCommand}"/> containing all tests for that method.
        /// </returns>
        protected override IEnumerable<ITestCommand> EnumerateTestCommands(MethodInfo method)
        {
            yield return new SpecificationTestCommand(
                base.EnumerateTestCommands(method).First(), method);
        }
    }
}