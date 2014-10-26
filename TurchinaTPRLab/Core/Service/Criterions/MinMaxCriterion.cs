using DecisionTheory.Core.MVCModel;

namespace DecisionTheory.Core.Service.Criterions
{
    /// <summary>
    /// Min-max criterion for decision-making task in complete uncertainty
    /// </summary>
    public class MinMaxCriterion : Criterion
    {
        private const string TOKEN = "минимаксный критерий";
        
        /// <summary>
        /// Constructor that sets default name of the criterion
        /// </summary>
        public MinMaxCriterion() : base(TOKEN) { }

        /// <summary>
        /// This method must find a solution of a decision-making task
        /// </summary>
        /// <param name="model">data model</param>
        /// <returns>solution of the task</returns>
        protected override Solution test(Model model)
        {
            var rows = model.getDecisionsCount();
            var cols = model.getStatesCount();

            var vector = new double[rows];
            int imin = 0;
            for (int i = 0; i < rows; ++i)
            {
                int jmax = 0;
                for (int j = 1; j < cols; ++j)
                    if (model.getData(i, jmax) < model.getData(i, j))
                        jmax = j;
                vector[i] = model.getData(i, jmax);
                if(vector[imin] > vector[i])
                    imin = i;
            }

            return new Solution(vector, imin);
        }
    }
}
