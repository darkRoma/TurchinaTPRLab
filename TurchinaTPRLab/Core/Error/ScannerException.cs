using System;

namespace DecisionTheory.Core.Error
{
    /// <summary>
    /// This exception can happen while Scanner instance working
    /// </summary>
    public class ScannerException : SystemException
    {
        private const string TOKEN = "Неудачная работа сканера. Возможные причины: пустой буфер/ошибка конвертации данных!";

        /// <summary>
        /// Constructor that sets up default message about this exception
        /// </summary>
        public ScannerException()
            : base(TOKEN) { }

        /// <summary>
        /// Constructor that sets up default message about this exception and reason why this happened
        /// </summary>
        /// <param name="cause">the reason of this exception</param>
        public ScannerException(Exception cause)
            : base(TOKEN, cause) { }
    }
}
