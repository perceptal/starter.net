using System;
using System.Reflection;
using Xunit.Sdk;

namespace Xunit
{
    /// <summary>
    /// A test command for specifications.
    /// </summary>
    public class SpecificationTestCommand : BeforeAfterCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestCommand"/> class.
        /// </summary>
        /// <param name="innerCommand">The inner command.</param>
        /// <param name="testMethod">The test method.</param>
        public SpecificationTestCommand(ITestCommand innerCommand, MethodInfo testMethod)
            : base(innerCommand, testMethod)
        {
        }

        /// <summary>
        /// Executes the test
        /// </summary>
        /// <param name="testClass">The test instance.</param>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the test instance does not implement the <see cref="ITestBase"/>
        /// interface.
        /// </exception>
        public override MethodResult Execute(object testClass)
        {
            var test = testClass as ISpecification;

            try
            {
                if (test == null)
                    throw new InvalidOperationException("Instance does not implement ISpecification");

                test.EstablishContext();
                test.Act();

                return base.Execute(testClass);
            }
            catch (AssertException)
            {
                throw;
            }
            catch (Exception exception)
            {
                if (exception.InnerException != null)
                {
                    ExceptionUtility.RethrowWithNoStackTraceLoss(exception.InnerException);
                }

                throw;
            }

            return null;
        }
    }
}