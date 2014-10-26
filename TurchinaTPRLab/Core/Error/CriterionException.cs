using System;

namespace DecisionTheory.Core.Error
{
    /// <summary>
    /// This exception can happen while a criterion tests data model
    /// </summary>
    public class CriterionException : SystemException
    {
        private const string TOKEN = "Произошла ошибка при работе критерия с данными!";

        /// <summary>
        /// Constructor that sets up default message about this exception
        /// </summary>
        public CriterionException()
            : base(TOKEN) { }

        /// <summary>
        /// Constructor that sets up default message about this exception and reason why this happened
        /// </summary>
        /// <param name="cause">the reason of this exception</param>
        public CriterionException(Exception cause)
            : base(TOKEN, cause) { }
    }
}
