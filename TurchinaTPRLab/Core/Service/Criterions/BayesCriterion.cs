using DecisionTheory.Core.MVCModel;
using System.Linq;
using DecisionTheory.Core.Error;

namespace DecisionTheory.Core.Service.Criterions
{
    /// <summary>
    /// Bayes criterion for decision-making task in complete uncertainty
    /// </summary>
    public class BayesCriterion : Criterion
    {
        private const string TOKEN = "Критерий Байеса";
        //TODO ???

        /// <summary>
        /// Constructor that sets default name of the criterion
        /// </summary>
        public BayesCriterion() : base(TOKEN) { }


        private bool checkProbability()
        {
            if (probability.Any(e => e < 0))
                return false;
            double sum = probability.Sum();
            //TODO;
            return sum == 1;
        }
        /// <summary>
        /// This method must find a solution of a decision-making task
        /// </summary>
        /// <param name="model">data model</param>
        /// <returns>solution of the task</returns>
        protected override Solution test(Model model)
        {
            var rows = model.getDecisionsCount();
            var cols = model.getStatesCount();

            //probability = new double[cols];
            //for(int i=0;i<cols;++i)
            //  probability[i] = 1.0;

            if (!checkProbability())
                throw new SystemException("Propability is not correct");

            var vector = new double[rows];
            int imin = 0;
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                    vector[i] += probability[j] * model.getData(i, j);
                if(vector[imin] > vector[i])
                    imin = i;
            }

            return new Solution(vector, imin);
        }
    }
}
