using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;

namespace Core
{
    /// <summary>
    /// Helper class to allow design-by-contract
    /// </summary>
    public static class Enforce
    {
        /// <summary>
        /// <para>Throws exception if the provided object is null. </para>
        /// <code>Enforce.Argument(() => args);</code> 
        /// </summary>
        /// <typeparam name="TValue">type of the class to check</typeparam>
        /// <param name="argumentReference">The argument reference to check.</param>
        /// <param name="argName">The name of the argument reference to check (used in any exception thrown).</param>
        /// <exception cref="ArgumentNullException">If the class reference is null.</exception>
        [DebuggerStepThrough]
        public static void Argument<TValue>(Func<TValue> argumentReference, string argName) where TValue : class
        {
            if (null == argumentReference())
            {
                throw ArgumentNull(argName);
            }
        }

        /// <summary>
        /// Throws proper exception if the provided string argument is null or empty. 
        /// </summary>
        /// <param name="argName">The name of the argument reference to check (used in any exception thrown).</param>
        /// <param name="argumentReference">The argument reference to check.</param>
        /// <exception cref="ArgumentNullException">If the string argument is null.</exception>
        /// <exception cref="ArgumentException">If the string argument is empty.</exception>
        [DebuggerStepThrough]
        public static void ArgumentNotEmpty(Func<string> argumentReference, string argName)
        {
            Argument(argumentReference, argName); // TODO: This looks kinda odd

            var value = argumentReference();
            if (0 == value.Length)
            {
                // throw new ArgumentException("String can't be empty", "name");
                throw Argument(argName, "String can't be empty");
            }
        }

        [DebuggerStepThrough]
        private static Exception ArgumentNull(string argName)
        {
            var message = string.Format(CultureInfo.InvariantCulture, "Parameter '{0}' can't be null", argName);
            return new ArgumentNullException(argName, message);
        }

        [DebuggerStepThrough]
        private static Exception Argument(string argName, string message)
        {
            return new ArgumentException(message, argName);
        }

        [DebuggerStepThrough]
        public static void ArgumentLessThan<TValue>(TValue lesser, TValue greater, string lesserArgName, string greaterArgName)
            where TValue : IComparable<TValue>
        {
            if (lesser.CompareTo(greater) >= 0)
            {
                var message = string.Format(CultureInfo.InvariantCulture, "Parameter '{0}' must be less than parameter '{1}'", lesserArgName, greaterArgName);
                throw new ArgumentException(message);
            }
        }

        [DebuggerStepThrough]
        public static void ArgumentGreaterThanZero<TValue>(Func<TValue> toVerify, string argumentName)
            where TValue : IComparable<long>
        {
            if (toVerify().CompareTo(0) <= 0)
            {
                var message = string.Format(CultureInfo.InvariantCulture, "Parameter '{0}' must be greater than zero.", argumentName);
                throw new ArgumentException(message, argumentName);
            }
        }

        [DebuggerStepThrough]
        public static void That(bool assertion, string message)
        {
            if (!assertion)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ArgumentNotEmpty(Func<IEnumerable> toVerify, string argumentName)
        {
            var collection = toVerify();

            int count = 0;

            foreach (var item in toVerify())
            {
                count++;
            }

            if (count == 0)
            {
                var message = string.Format(CultureInfo.InvariantCulture, "Collection must have items.");
                throw new ArgumentException(message, argumentName);
            }
        }

        public static void ArgumentNotNull<T>(Func<T> func, string argumentName)
        {
            if (func() == null)
            {
                throw new ArgumentNullException(argumentName, "Parameter '{0}' cannot be null.");
            }
        }
    }
}

