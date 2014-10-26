using System;

namespace DecisionTheory.Core.Error
{
    /// <summary>
    /// This exception can happen when there is an error during data processing
    /// </summary>
    public class DataException : SystemException
    {
        private const string TOKEN = "Произошла ошибка при загрузке/обработке данных!";

        /// <summary>
        /// Constructor that sets up default message about this exception
        /// </summary>
        public DataException()
            : base(TOKEN) { }

        /// <summary>
        /// Constructor that sets up default message about this exception and reason why this happened
        /// </summary>
        /// <param name="cause">the reason of this exception</param>
        public DataException(Exception cause)
            : base(TOKEN, cause) { }
    }
}
