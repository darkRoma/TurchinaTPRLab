using System;
using System.ComponentModel;
using System.IO;
using DecisionTheory.Core.Error;

namespace DecisionTheory.Core.Service
{
    /// <summary>
    /// This service class can be used to read from file primitives and other data
    /// </summary>
    public class Scanner
    {
        private string[] buffer;
        private int offset;

        /// <summary>
        /// Constructor that creates instance and reads from file text information
        /// </summary>
        /// <param name="fileName"></param>
        public Scanner(string fileName)
        {
            try
            {
                StreamReader sr = new StreamReader(fileName);
                string text = sr.ReadToEnd();
                sr.Close();
                var separators = "\n\r\t ".ToCharArray();
                buffer = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            }
            catch (Exception cause)
            {
                throw new ScannerException(cause);
            }
        }

        /// <summary>
        /// This method is using to get strings from buffer
        /// </summary>
        /// <returns>string data</returns>
        public string getNext()
        {
            if (!hasNext())
                throw new ScannerException();
            return buffer[offset++];
        }

        /// <summary>
        /// This method is using to get primitives and other data from buffer
        /// </summary>
        /// <typeparam name="T">type that must be read from buffer</typeparam>
        /// <returns>data of the corresponding type</returns>
        public T getNext<T>()
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));

            string str = getNext();
            return (T)converter.ConvertFromString(str);
        }

        /// <summary>
        /// Checks if buffer is not empty
        /// </summary>
        /// <returns>true if buffer has some entries</returns>
        public bool hasNext()
        {
            return offset < buffer.Length;
        }
    }
}
