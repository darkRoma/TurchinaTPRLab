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
            int[] indexEquivalent = IndexEquivalentBetweenHullAndLossArray(convexHull, lossArray);
            int sizeLossArray = lossArray.Length/2;
            double loss = 0;

            int convexHullSize = convexHull.Length / 2;
            int numberOfMinXPoint = NumberOfMinXPoint(convexHull);
            double[] result = new double[sizeLossArray];
            int count = convexHullSize - numberOfMinXPoint - 1;
            int numberOfResultPoint = numberOfMinXPoint;
            double x = 0;
            double tempX = 0;
            bool isFound = false;

            if (count != 0)
            {
                for (int i = 1; i <= count; i++)
                {
                    tempX = PointOfIntersection(convexHull[numberOfResultPoint, 0], convexHull[numberOfResultPoint + 1, 0], convexHull                                 [numberOfResultPoint, 1], convexHull[numberOfResultPoint + 1, 1]);
                   
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
                    x = X(convexHull[numberOfResultPoint, 0], convexHull[numberOfResultPoint + 1, 0], convexHull[numberOfResultPoint, 1],                              convexHull[numberOfResultPoint + 1, 1]);
                    result = CountResult(indexEquivalent, numberOfResultPoint, numberOfResultPoint + 1, x, sizeLossArray);
                    loss = CountLoss(x, convexHull[numberOfResultPoint, 0], convexHull[numberOfResultPoint + 1, 0]);
                }
                else
                {
                    x = X(convexHull[numberOfResultPoint, 0], convexHull[0, 0], convexHull[numberOfResultPoint, 1], convexHull[0, 1]);
                    result = CountResult(indexEquivalent, numberOfResultPoint, 0, x, sizeLossArray);
                    loss = CountLoss(x, convexHull[numberOfResultPoint, 0], convexHull[0, 0]);
                }

                return new Solution(result, loss);
            }
            else
            {
                x = X(convexHull[numberOfResultPoint, 0], convexHull[0, 0], convexHull[numberOfResultPoint, 1], convexHull[0, 1]);
                result = CountResult(indexEquivalent, numberOfResultPoint, 0, x, sizeLossArray);
                loss = CountLoss(x, convexHull[numberOfResultPoint, 0], convexHull[0, 0]);
               
                return new Solution(result, loss);
            }

            
        }

        static int[] IndexEquivalentBetweenHullAndLossArray(double[,] hull, double[,] lossArray)
        {
            int sizeHull = hull.Length / 2;
            int sizeLossArray = lossArray.Length / 2;
            int[] result = new int[sizeHull];
            for (int i = 0; i < sizeHull; i++)
            {
                for (int j = 0; j < sizeLossArray; j++)
                {
                    if (hull[i, 0] == lossArray[j, 0] && hull[i, 1] == lossArray[j, 1])
                    {
                        result[i] = j;
                    }
                }
            }
            return result;
        }

        static double CountLoss(double x, double a, double b)
        {
            return a * x + (1 - x) * b;
        }

        static int NumberOfMinXPoint(double[,] convexHull)
        {
            int result = 0;
            double tempX = convexHull[0, 0];
            double tempY = convexHull[0, 1];
            int convexHullSize = convexHull.Length / 2;
            for (int i = 1; i < convexHullSize; i++)
            {
                if (tempX > convexHull[i, 0])
                {
                    tempX = convexHull[i, 0];
                    tempY = convexHull[i, 1];
                    result = i;
                }
                else
                {
                    if (tempX == convexHull[i, 0])
                    {
                        if (tempY < convexHull[i, 1])
                        {
                            tempX = convexHull[i, 0];
                            tempY = convexHull[i, 1];
                            result = i;
                        }
                    }
                }
            }

            return result;
        }
        static double PointOfIntersection(double x1, double x2, double y1, double y2)
        {
            return (-x1 * y2 + y1 * x2) / (x2 - x1 - y2 + y1);
        }

        static double X(double x1, double x2, double y1, double y2)
        {
            return (y2 - x2) / (x1 - x2 - y1 + y2);
        }

        static double[] CountResult(int[] indexEquivalent, int numberOfResultPoint, int nextNumberOfResultPoint, double x, int size)
        {
            double[] result = new double[size];
            result[indexEquivalent[numberOfResultPoint]] = x;
            result[indexEquivalent[nextNumberOfResultPoint]] = 1 - x;

            return result;
        }
    }
}
