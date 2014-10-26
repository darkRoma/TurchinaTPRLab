using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecisionTheory.Core.Error
{
    /// <summary>
    /// This exception can happen while converting process
    /// </summary>
    public class ConvertException : SystemException
    {
        private const string TOKEN = "Ошибка конвертации данных!";

        /// <summary>
        /// Constructor that sets up default message about this exception
        /// </summary>
        public ConvertException()
            : base(TOKEN) { }

        /// <summary>
        /// Constructor that sets up default message about this exception and reason why this happened
        /// </summary>
        /// <param name="cause">the reason of this exception</param>
        public ConvertException(Exception cause)
            : base(TOKEN, cause) { }
    }
}
