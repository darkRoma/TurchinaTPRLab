using System;
using DecisionTheory.Core.Error;
using DecisionTheory.Core.MVCModel;

namespace DecisionTheory.Core.Service.Criterions
{
    /// <summary>
    /// Base interface for each concrete criterion that are using for decision-making task in complete uncertainty
    /// </summary>
    public abstract class Criterion
    {
        private string name;

        /// <summary>
        /// Constructor that sets name field
        /// </summary>
        /// <param name="name">name of the criterion</param>
        public Criterion(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Getter for name field
        /// </summary>
        /// <returns>the name of criterion</returns>
        public string getName()
        {
            return name;
        }

        /// <summary>
        /// This method test data model and makes decision
        /// </summary>
        /// <param name="model">data models</param>
        /// <returns>solution data</returns>
        public Solution makeDecision(Model model)
        {
            if (model == null)
                return null;
            try
            {
                return test(model);
            }
            catch (Exception cause)
            {
                throw new CriterionException(cause);
            }
        }

        /// <summary>
        /// This method must find a solution of a decision-making task
        /// </summary>
        /// <param name="model">data model</param>
        /// <returns>solution of the task</returns>
        protected abstract Solution test(Model model);
    }
}
