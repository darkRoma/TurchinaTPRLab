using DecisionTheory.Core.MVCModel;

namespace DecisionTheory.Core.Service.Criterions
{
    /// <summary>
    /// Gurvits criterion for decision-making task in complete uncertainty
    /// </summary>
    public class GurvitsCriterion : Criterion
    {
        private const string TOKEN = "критерий Гурвица";

        //TODO ???
        private double rate = 0.75;

        /// <summary>
        /// Constructor that sets default name of the criterion and optimism rate
        /// </summary>
        public GurvitsCriterion() : base(TOKEN) { }

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
                int jmin = 0;
                for (int j = 1; j < cols; ++j)
                    if (model.getData(i, jmax) < model.getData(i, j))
                        jmax = j;
                    else
                        if (model.getData(i, jmin) > model.getData(i, j))
                            jmin = j;

                double min = model.getData(i, jmin);
                double max = model.getData(i, jmax);
                vector[i] = rate * min + (1 - rate) * max;

                if(vector[imin] > vector[i])
                    imin = i;
            }

            return new Solution(vector, imin);
        }
    }
}
