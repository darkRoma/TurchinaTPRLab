using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DecisionTheory.Core.Service.Criterions;
using DecisionTheory.Core.MVCModel;

namespace TurchinaTPRLab.Core.Service.Criterions.Randomized_criterions
{
    class RandBayesCriterion : Criterion
    {
        private const string TOKEN = "Критерий Байеса (ранд.решения)";

        public RandBayesCriterion() : base(TOKEN) { }

        protected override Solution test(Model model)
        {
            double[,] linearMembrane = model.getLossesArray();
            Point point = new Point(model.GradientX, model.GradientY);
            double[] tempArray = new double[linearMembrane.Length / 2];
            for (int i = 0; i < tempArray.Length; i++)
            {
                tempArray[i] = linearMembrane[i, 0] * point.getX + linearMembrane[i, 1] * point.getY;
            }

            double min = tempArray[0];
            int imin = 0;
            for (int i = 1; i < tempArray.Length; i++)
            {
                if (tempArray[i] <= min)
                {
                    min = tempArray[i];
                    imin = i;
                }
            }
            int countOfMinPoints  = 0;
            for (int i=0; i<tempArray.Length; i++)
            {
                if (min == tempArray[i])
                {
                    countOfMinPoints++;
                }
            }
            if (countOfMinPoints < 2)
            {
                for (int i = 0; i < tempArray.Length; i++)
                {
                    tempArray[i] = 0;
                }
                tempArray[imin] = 1;
                return new Solution(tempArray);
            }
            else
            {
                for (int i = 0; i < tempArray.Length; i++)
                {
                    if (tempArray[i] != min)
                    {
                        tempArray[i] = 0;
                    }
                    else
                    {
                        tempArray[i] = (double) 1 / countOfMinPoints;
                    }
                }
                return new Solution(tempArray);
            }            
        }

    }
}
