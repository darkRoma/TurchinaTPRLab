using System.Threading;
using System.Windows.Forms;
using DecisionTheory.Core.Error;

namespace DecisionTheory.Project
{
    /// <summary>
    /// This class is the exception handler for this application
    /// </summary>
    public sealed class ApplicationExceptionHandler
    {
        private ApplicationExceptionHandler() { }

        /// <summary>
        /// This delegate handles application exceptions
        /// </summary>
        public static ThreadExceptionEventHandler Handler = delegate(object sender, ThreadExceptionEventArgs args)
        {
            var cause = args.Exception;
            if (!(cause is SystemException))
                MessageBox.Show("Произошла ошибка!");
            else
            {
                string report = cause.Message;
                if (cause.InnerException != null)
                    report += "\nReason: " + cause.InnerException.Message;
                MessageBox.Show(report);

            }
        };
    }
}
