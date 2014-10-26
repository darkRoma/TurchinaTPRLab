using DecisionTheory.Core.MVCModel;
using DecisionTheory.Core.Error;

namespace DecisionTheory.Core.Service.Criterions
{
    /// <summary>
    /// Neyman-Pearson criterion for decision-making task in complete uncertainty
    /// </summary>
    public class NeymanPearsonCriterion : Criterion
    {
        private const string TOKEN = "критерий Неймана-Пирсона";
        //TODO ???
        private double limit = 3;
        private int index = 1;

        /// <summary>
        /// Constructor that sets default name of the criterion
        /// </summary>
        public NeymanPearsonCriterion() : base(TOKEN) { }

        /// <summary>
        /// This method must find a solution of a decision-making task
        /// </summary>
        /// <param name="model">data model</param>
        /// <returns>solution of the task</returns>a
        protected override Solution test(Model model)
        {
            var rows = model.getDecisionsCount();
            var cols = model.getStatesCount();

            if (cols != 2)
            {
                throw new SystemException("States count must best equals 2");
                return null;
            }
            var j = index;

            var active = new bool[rows];
            var vector = new double[rows];
            int imin = -1;

            for (int i = 0; i < rows; ++i)
            {
                var value = model.getData(i, j);
                vector[i] = model.getData(i, 1 - j);
                if (value <= limit)
                {
                    if (imin < 0 || model.getData(imin, 1 - j) > model.getData(i, 1 - j))
                        imin = i;
                    active[i] = true;
                }
            }
            if (imin < 0)
                return null;
            return new Solution(vector, active, imin);
        }
    }
}
