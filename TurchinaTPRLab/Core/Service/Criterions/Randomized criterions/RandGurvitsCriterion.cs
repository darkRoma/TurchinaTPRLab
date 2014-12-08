using DecisionTheory.Core.MVCModel;
using DecisionTheory.Core.Service.Criterions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurchinaTPRLab.Core.Service.Criterions.Randomized_criterions
{
    class RandGurvitsCriterion : Criterion
    {
              private const string TOKEN = "Критерий Гурвица (ранд. решения)";

        /// <summary>
        /// Constructor that sets default name of the criterion and optimism rate
        /// </summary>
        public RandGurvitsCriterion() : base(TOKEN) { }

        protected override Solution test(Model model)
        {
            /*if (model.Liambda == 0)
            {
                var factory = CriterionFactory.getFactory();
                var minmax = factory.getInstance<RandMinMaxCriterion>();
                return minmax.makeDecision(model);
            }
            else if (model.Liambda > 0 || model.Liambda < 0.5)
            {
 
            }
            else if (model.Liambda == 0.5)
            {
 
            }
            else if (model.Liambda > 0.5 || model.Liambda < 1)
            {

            }
            else
            {
                
            }*/
            var factory = CriterionFactory.getFactory();
            var minmax = factory.getInstance<RandMinMaxCriterion>();
            return minmax.makeDecision(model);
        }
    }
}
