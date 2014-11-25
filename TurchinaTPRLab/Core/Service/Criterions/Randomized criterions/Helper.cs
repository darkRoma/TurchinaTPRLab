﻿using System;
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
            if (numberOfResultPoint != nextNumberOfResultPoint)
            {
                result[indexEquivalent[nextNumberOfResultPoint]] = 1 - x;
            }

            return result;
        }

        public static int IsHullLine(double[,] hull)
        {
            bool IsDifferentX = true;
            bool IsDifferentY = true;
            bool IsXDifferY = true;
            for (int i = 0; i < hull.Length / 2; i++)
            {
                if (hull[0, 0] == hull[i, 0])
                {
                    IsDifferentX = false;
                }
                else
                {
                    IsDifferentX = true;
                    break;
                }
            }
            for (int i = 0; i < hull.Length / 2; i++)
            {
                if (hull[0, 1] == hull[i, 1])
                {
                    IsDifferentY = false;
                }
                else
                {
                    IsDifferentY = true;
                    break;
                }
            }
            for (int i = 0; i < hull.Length / 2; i++)
            {
                if (hull[i, 0] == hull[i, 1])
                {
                    IsXDifferY = false;
                }
                else
                {
                    IsXDifferY = true;
                    break;
                }
            }
            if (!IsDifferentX)
            {
                return 1;
            }
            if (!IsDifferentY)
            {
                return 2;
            }
            if (!IsXDifferY)
            {
                return 3;
            }
            return 0;
        }

        public static int FindNumberMinX(double[,] hull)
        {
            double minX = hull[0, 0];
            int number = 0;
            for (int i = 1; i < hull.Length / 2; i++)
            {
                if (hull[i, 0] < minX)
                {
                    minX = hull[i, 0];
                    number = i;
                }
            }

            return number;
        }

        public static int FindNumberMinY(double[,] hull)
        {
            double minY = hull[0, 1];
            int number = 0;
            for (int i = 1; i < hull.Length / 2; i++)
            {
                if (hull[i, 1] < minY)
                {
                    minY = hull[i, 1];
                    number = i;
                }
            }

            return number;
        }
    }
}
