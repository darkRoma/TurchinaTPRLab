using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DecisionTheory.Core.Service
{
    /// <summary>
    /// This service can be used to save objects' states to file
    /// </summary>
    public class Saver
    {
        private Saver() {}

        /// <summary>
        /// The method that organize saving target object to file
        /// </summary>
        /// <param name="target">object that must be saved</param>
        /// <param name="fileName">the name of file</param>
        public static void save(object target, string fileName)
        {
            string information = target.ToString();
            StreamWriter sw = new StreamWriter(fileName);
            sw.Write(information);
            sw.Close();
        }
    }
}
