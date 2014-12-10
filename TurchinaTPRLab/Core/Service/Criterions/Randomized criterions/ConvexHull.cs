using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurchinaTPRLab.Core.Service.Criterions.Randomized_criterions
{
    class ConvexHull
    {
        public static double[,] JarvisMethod(double[,] lossArray)
        {
            int numbrFirstElem = 0;
            int lossArraySize = lossArray.Length / 2;
            double[,] result;
            double[,] resultTemp = new double[lossArray.Length, 2];
            int pointCount = 0;
            bool isDifferent = true;
            bool isAllElemsEquals = false;

            for (int i = 1; i < lossArraySize; i++)
            {
                if (lossArray[i, 0] == lossArray[i - 1, 0] && lossArray[i, 0] == lossArray[i - 1, 1] && lossArray[i, 0] == lossArray[i, 1])
                {
                    isAllElemsEquals = true;
                }
                else
                {
                    isAllElemsEquals = false;
                    break;
                }
            
            }

            if (isAllElemsEquals)
            {
                resultTemp[0, 0] = lossArray[0, 0];
                resultTemp[0, 1] = lossArray[0, 0];
                pointCount = 1;
            }
            else
            {
                for (int i = 1; i < lossArraySize; i++)
                {
                    if (lossArray[i, 1] < lossArray[numbrFirstElem, 1])
                    {
                        numbrFirstElem = i;

                    }
                    else
                        if (lossArray[i, 1] == lossArray[numbrFirstElem, 1] &&
                          lossArray[i, 0] < lossArray[numbrFirstElem, 0])
                        {

                            numbrFirstElem = i;
                        }
                }

                resultTemp[0, 0] = lossArray[numbrFirstElem, 0];
                resultTemp[0, 1] = lossArray[numbrFirstElem, 1];
                pointCount = 1;

                int first = numbrFirstElem;
                int cur = numbrFirstElem;

                do
                {
                    int next = (cur + 1) % (lossArraySize);
                    for (int i = 0; i < lossArraySize; i++)
                    {
                        double sign = OrientTriangl(cur, next, i, lossArray);
                        if (sign < 0)
                        {
                            next = i;
                        }
                        else if (sign == 0.0)
                        {
                            if (isInside(cur, next, i, lossArray))
                            {
                                next = i;
                            }
                        }
                    }
                    cur = next;
                    for (int i = 0; i < lossArraySize; i++)
                    {
                        if (resultTemp[i, 0] == lossArray[next, 0] && resultTemp[i, 1] == lossArray[next, 1])
                        {
                            isDifferent = false;
                        }

                    }
                    if (isDifferent)
                    {
                        resultTemp[pointCount, 0] = lossArray[next, 0];
                        resultTemp[pointCount, 1] = lossArray[next, 1];
                        pointCount++;
                    }
                }
                while (cur != first);
            }

            result = new double[pointCount, 2];

            for (int i = 0; i < pointCount; i++)
            {
                result[i, 0] = resultTemp[i, 0];
                result[i, 1] = resultTemp[i, 1];
            }
            return result;
        }


       public static int[] IndexEquivalentBetweenHullAndLossArray(double[,] hull, double[,] lossArray)
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

        static double OrientTriangl(int cur, int next, int i, double[,] lossArray)
        {
            return lossArray[cur, 0] * (lossArray[next, 1] - lossArray[i, 1]) + lossArray[next, 0] * (lossArray[i, 1] - lossArray[cur, 1]) +                          lossArray[i, 0] * (lossArray[cur, 1] - lossArray[next, 1]);
        }

        static bool isInside(int cur, int next, int i, double[,] lossArray)
        {
            return (lossArray[cur, 0] <= lossArray[next, 0] && lossArray[next, 0] <= lossArray[i, 0] &&
                      lossArray[cur, 1] <= lossArray[next, 1] && lossArray[next, 1] <= lossArray[i, 1]);
        }
    }
}
