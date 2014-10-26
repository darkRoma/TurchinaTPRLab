using System;

namespace DecisionTheory.Core.Error
{
    /// <summary>
    /// This exception is the base for all exceptions, that can happen in this application.
    /// <para>Used for easy handling by ApplicationExceptionHandler</para>
    /// </summary>
    public class SystemException : Exception
    {
        /// <summary>
        /// Constructor that sets up default message about this exception
        /// </summary>
        public SystemException(string message)
            : base(message) { }

        /// <summary>
        /// Constructor that sets up default message about this exception and reason why this happened
        /// </summary>
        /// <param name="cause">the reason of this exception</param>
        public SystemException(string message, Exception cause)
            : base(message, cause) { }
    }
}
