using DecisionTheory.Core.MVCModel;
using DecisionTheory.Core.Service.Criterions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurchinaTPRLab.Core.Service.Criterions.Randomized_criterions
{
    class RandMinMaxCriterion : Criterion
    {
        private const string TOKEN = "минимаксный критерий (ранд. решения)";

        /// <summary>
        /// Constructor that sets default name of the criterion
        /// </summary>
        public RandMinMaxCriterion() : base(TOKEN) { }

        /// <summary>
        /// This method must find a solution of a decision-making task
        /// </summary>
        /// <param name="model">data model</param>
        /// <returns>solution of the task</returns>
        protected override Solution test(Model model)
        {
            double[,] lossArray = model.getLossesArray();
            double[,] convexHull = ConvexHull.JarvisMethod(lossArray);
            int[] indexEquivalent = ConvexHull.IndexEquivalentBetweenHullAndLossArray(convexHull, lossArray);
            int sizeLossArray = lossArray.Length / 2;
            double loss = 0;

            int convexHullSize = convexHull.Length / 2;
            int numberOfMinXPoint = Helper.NumberOfMinXPoint(convexHull);
            double[] result = new double[sizeLossArray];
            int count = convexHullSize - numberOfMinXPoint - 1;
            int numberOfResultPoint = numberOfMinXPoint;
            double x = 0;
            double tempX = 0;
            bool isFound = false;
            int IsLine = Helper.IsHullLine(convexHull);

            if (IsLine != 0)
            {
                if (IsLine == 1 || IsLine == 3)
                {
                    result = Helper.CountResult(indexEquivalent, numberOfMinXPoint, 0, 1.0, sizeLossArray);
                    return new Solution(result, 0.0);
                }
                if(IsLine == 2)
                {

                    result = Helper.CountResult(indexEquivalent, numberOfMinXPoint, 0, 1.0, sizeLossArray);
                    return new Solution(result, 0.0);
                }

            }

            if (count != 0)
            {
                for (int i = 1; i <= count; i++)
                {
                    tempX = Helper.PointOfIntersection(convexHull[numberOfResultPoint, 0], convexHull[numberOfResultPoint + 1, 0], convexHull[numberOfResultPoint, 1], convexHull[numberOfResultPoint + 1, 1]);

                    if (tempX > convexHull[numberOfResultPoint, 0] && tempX < convexHull[numberOfResultPoint + 1, 0])
                    {
                        isFound = true;
                        break;
                    }
                    else
                    {
                        numberOfResultPoint++;
                    }
                }

                if (isFound)
                {
                    x = Helper.X(convexHull[numberOfResultPoint, 0], convexHull[numberOfResultPoint + 1, 0], convexHull[numberOfResultPoint, 1], convexHull[numberOfResultPoint + 1, 1]);
                    result = Helper.CountResult(indexEquivalent, numberOfResultPoint, numberOfResultPoint + 1, x, sizeLossArray);
                    loss = CountLoss(x, convexHull[numberOfResultPoint, 0], convexHull[numberOfResultPoint + 1, 0]);
                }
                else
                {
                    x = Helper.X(convexHull[numberOfResultPoint, 0], convexHull[0, 0], convexHull[numberOfResultPoint, 1], convexHull[0, 1]);
                    result = Helper.CountResult(indexEquivalent, numberOfResultPoint, 0, x, sizeLossArray);
                    loss = CountLoss(x, convexHull[numberOfResultPoint, 0], convexHull[0, 0]);
                }

                return new Solution(result, loss);
            }
            else
            {
                x = Helper.X(convexHull[numberOfResultPoint, 0], convexHull[0, 0], convexHull[numberOfResultPoint, 1], convexHull[0, 1]);
                result = Helper.CountResult(indexEquivalent, numberOfResultPoint, 0, x, sizeLossArray);
                loss = CountLoss(x, convexHull[numberOfResultPoint, 0], convexHull[0, 0]);

                return new Solution(result, loss);
            }
        }

        static double CountLoss(double x, double a, double b)
        {
            if (x == 0)
            { return 0; }
            else
            { return Math.Round(a * x + (1 - x) * b, 2); }
        }

    }
}
