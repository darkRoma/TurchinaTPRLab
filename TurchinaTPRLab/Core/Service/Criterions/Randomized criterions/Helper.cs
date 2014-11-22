using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurchinaTPRLab.Core.Service.Criterions.Randomized_criterions
{
    class Helper
    {
        public static int NumberOfMinXPoint(double[,] convexHull)
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

        public static double PointOfIntersection(double x1, double x2, double y1, double y2)
        {
            return (-x1 * y2 + y1 * x2) / (x2 - x1 - y2 + y1);
        }

        public static double X(double x1, double x2, double y1, double y2)
        {
            return (y2 - x2) / (x1 - x2 - y1 + y2);
        }

        public static double X(double x1, double x2, double y1, double y2, double Rate, double controledStateNumber)
        {
            if (controledStateNumber == 1)
            { return (Rate - x2) / (x1 - x2); }

            if (controledStateNumber == 2)
            { return (Rate - y2) / (y1 - y2); }

            return 0;
        }

        public static double[] CountResult(int[] indexEquivalent, int numberOfResultPoint, int nextNumberOfResultPoint, double x, int size)
        {
            double[] result = new double[size];
            result[indexEquivalent[numberOfResultPoint]] = x;
            result[indexEquivalent[nextNumberOfResultPoint]] = 1 - x;

            return result;
        }
    }
}
