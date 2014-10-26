using System;

namespace DecisionTheory.Core.Error
{
    /// <summary>
    /// This exception can happen when there is an error during data displaying
    /// </summary>
    public class ViewException : SystemException
    {
        private const string TOKEN = "Произошла ошибка при отображении данных!";

        /// <summary>
        /// Constructor that sets up default message about this exception
        /// </summary>
        public ViewException()
            : base(TOKEN) { }

        /// <summary>
        /// Constructor that sets up default message about this exception and reason why this happened
        /// </summary>
        /// <param name="cause">the reason of this exception</param>
        public ViewException(Exception cause)
            : base(TOKEN, cause) { }
    }
}
