using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DecisionTheory.Core.DesignPatterns;

namespace DecisionTheory.Core.Service.Criterions
{
    /// <summary>
    /// This class represents a criterion factory (singleton) that holds singletons for each used criterion
    /// </summary>
    public class CriterionFactory : AbstractFactory<Criterion>
    {
        private static CriterionFactory factory;

        private CriterionFactory()
            : base()
        {
            initialize();
        }

        /// <summary>
        /// Getter for criterion factory singleton instance  
        /// </summary>
        /// <returns>criterion factory</returns>
        public static CriterionFactory getFactory()
        {
            if (factory == null)
                factory = new CriterionFactory();
            return factory;
        }

        private void initialize()
        {
            getInstance<MinMaxCriterion>();
            getInstance<SavageCriterion>();
            getInstance<GurvitsCriterion>();
            getInstance<BayesCriterion>();
            getInstance<NeymanPearsonCriterion>();
        }
    }
}
