using DecisionTheory.Core.MVCModel;

namespace DecisionTheory.Core.Service.Criterions
{
    /// <summary>
    /// Savage criterion for decision-making task in complete uncertainty
    /// </summary>
    public class SavageCriterion : Criterion
    {
        private const string TOKEN = "критерий Сэвиджа";

        /// <summary>
        /// Constructor that sets default name of the criterion and optimism rate
        /// </summary>
        public SavageCriterion() : base(TOKEN) { }

        /// <summary>
        /// This method must find a solution of a decision-making task
        /// </summary>
        /// <param name="model">data model</param>
        /// <returns>solution of the task</returns>
        protected override Solution test(Model model)
        {
            var regret = ModelConverter.convert(model);
            var factory = CriterionFactory.getFactory();
            var minmax = factory.getInstance<MinMaxCriterion>();
            return minmax.makeDecision(regret);
        }
    }
}
