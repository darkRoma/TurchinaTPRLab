using DecisionTheory.Core.MVCModel;
using DecisionTheory.Core.Service;
using DecisionTheory.Core.Service.Criterions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurchinaTPRLab.Core.Service.Criterions.Randomized_criterions
{
    class RandSavageCriterion:Criterion
    {  
        private const string TOKEN = "Критерий Сэвиджа (ранд. решения)";

        /// <summary>
        /// Constructor that sets default name of the criterion and optimism rate
        /// </summary>
        public RandSavageCriterion() : base(TOKEN) { }

        /// <summary>
        /// This method must find a solution of a decision-making task
        /// </summary>
        /// <param name="model">data model</param>
        /// <returns>solution of the task</returns>
        protected override Solution test(Model model)
        {
            var regret = ModelConverter.convert(model);
            var factory = CriterionFactory.getFactory();
            var minmax = factory.getInstance<RandMinMaxCriterion>();
            return minmax.makeDecision(regret);
        }
    }
}
