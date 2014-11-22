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
              private const string TOKEN = "критерий Гурвица (ранд. решения)";

        /// <summary>
        /// Constructor that sets default name of the criterion and optimism rate
        /// </summary>
        public RandGurvitsCriterion() : base(TOKEN) { }

        protected override Solution test(Model model)
        {
            RandMinMaxCriterion minMax = new RandMinMaxCriterion();

            return minMax.makeDecision(model);
        }
    }
}
