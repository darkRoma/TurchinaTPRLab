using DecisionTheory.Core.MVCModel;
using DecisionTheory.Core.Service.Criterions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurchinaTPRLab.Core.Service.Criterions.Randomized_criterions
{
    class RandNeymanPearsonCriterion : Criterion
    {
        private const string TOKEN = "критерий Неймана-Пирсона (ранд. решения)";

        /// <summary>
        /// Constructor that sets default name of the criterion
        /// </summary>
       public RandNeymanPearsonCriterion() : base(TOKEN) { }

       protected override Solution test(Model model)
       {
           double[,] lossArray = model.getLossesArray();
           double[,] convexHull = ConvexHull.JarvisMethod(lossArray);
           int[] indexEquivalent = ConvexHull.IndexEquivalentBetweenHullAndLossArray(convexHull, lossArray);
           int sizeLossArray = lossArray.Length / 2;
           double lossesRate = model.LossestRate;
           int controledStateNumber = model.ControledStateNumber;

           int convexHullSize = convexHull.Length / 2;
           int numberOfMinXPoint = Helper.NumberOfMinXPoint(convexHull);
           double[] result = new double[sizeLossArray];
           int count = convexHullSize - numberOfMinXPoint - 1; // number of points in the southwestern border
           int numberOfResultPoint = numberOfMinXPoint;
           double x = 0;
           double tempX = 0;
           bool isFound = false;

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
                   x = Helper.X(convexHull[numberOfResultPoint, 0], convexHull[numberOfResultPoint + 1, 0], convexHull[numberOfResultPoint, 1], convexHull[numberOfResultPoint + 1, 1], lossesRate, controledStateNumber);
                   result = Helper.CountResult(indexEquivalent, numberOfResultPoint, numberOfResultPoint + 1, x, sizeLossArray);
               }
               else
               {
                  x = Helper.X(convexHull[numberOfResultPoint, 0], convexHull[0, 0], convexHull[numberOfResultPoint, 1], convexHull[0, 1], lossesRate, controledStateNumber);
                   result = Helper.CountResult(indexEquivalent, numberOfResultPoint, 0, x, sizeLossArray);
               }

               return new Solution(result);
           }
           else
           {
               x = Helper.X(convexHull[numberOfResultPoint, 0], convexHull[0, 0], convexHull[numberOfResultPoint, 1], convexHull[0, 1], lossesRate, controledStateNumber);
               result = Helper.CountResult(indexEquivalent, numberOfResultPoint, 0, x, sizeLossArray);

               return new Solution(result);
           }
       }
    }
}
