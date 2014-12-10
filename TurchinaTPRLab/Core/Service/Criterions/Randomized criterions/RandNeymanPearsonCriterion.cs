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
        private const string TOKEN = "Критерий Неймана-Пирсона (ранд. решения)";

        /// <summary>
        /// Constructor that sets default name of the criterion
        /// </summary>
       public RandNeymanPearsonCriterion() : base(TOKEN) { }

       protected override Solution test(Model model)
       {
           double[,] lossArray = model.getLossesArray();
           int sizeLossArray = lossArray.Length / 2;
           double lossesRate = model.LossestRate;
           int controledStateNumber = model.ControledStateNumber;
           double[] result = new double[sizeLossArray];
           double x = 0;
           double tempX = 0;
           bool isFound = false;

           double[,] convexHull=ConvexHull.JarvisMethod(lossArray);

           if (DoesExistResult(convexHull, controledStateNumber, lossesRate))
           {
               int[] indexEquivalent = ConvexHull.IndexEquivalentBetweenHullAndLossArray(convexHull, lossArray);
               int isLine = Helper.IsHullLine(convexHull);
              

               int convexHullSize = convexHull.Length / 2;
               int numberOfMinXPoint = Helper.NumberOfMinXPoint(convexHull);
               
               int count = convexHullSize - numberOfMinXPoint - 1; // number of points in the southwestern border
               bool isFirstPointInSolution = (count == 0) ? true : false;
               int numberOfResultPoint = numberOfMinXPoint;


               if (IsAllControledPointsSuits(convexHull, controledStateNumber, lossesRate))
               {
                   int resultPoints = FindMinUncontroledPoints(convexHull, controledStateNumber);


                   result = Helper.CountResult(indexEquivalent, resultPoints, 0, 1, sizeLossArray);
                   return new Solution(result, 0.0);
               }

               if (isLine != 0)
               { 
                   convexHull = UpdateHull(convexHull, controledStateNumber, lossesRate);

                   if (isLine == 1 || isLine == 3)
                   {
                       result = Helper.CountResult(indexEquivalent, Helper.FindNumberMinY(convexHull), 0, 1.0, sizeLossArray);
                       return new Solution(result, 0.0);
                   }
                   else
                   {

                       result = Helper.CountResult(indexEquivalent, Helper.FindNumberMinX(convexHull), 0, 1.0, sizeLossArray);
                       return new Solution(result, 0.0);
                   }
               }

               while (count > 0)
               {
                   if (controledStateNumber == 1)
                   {
                       if (convexHull[numberOfResultPoint + 1, 0] <= lossesRate)
                       {
                           x = Helper.X(convexHull[numberOfResultPoint, 0], convexHull[numberOfResultPoint + 1, 0], convexHull[numberOfResultPoint, 1], convexHull[numberOfResultPoint + 1, 1], lossesRate, controledStateNumber);
                           result = Helper.CountResult(indexEquivalent, numberOfResultPoint, numberOfResultPoint + 1, x, sizeLossArray);
                           isFirstPointInSolution = false;
                       }
                       else
                       {
                           numberOfResultPoint++;
                           isFirstPointInSolution = true;
                       }
                   }
                   if (controledStateNumber == 2)
                   {
                       if (convexHull[numberOfResultPoint + 1, 1] <= lossesRate)
                       {
                           x = Helper.X(convexHull[numberOfResultPoint, 0], convexHull[numberOfResultPoint + 1, 0], convexHull[numberOfResultPoint, 1], convexHull[numberOfResultPoint + 1, 1], lossesRate, controledStateNumber);
                           result = Helper.CountResult(indexEquivalent, numberOfResultPoint, numberOfResultPoint + 1, x, sizeLossArray);
                           isFirstPointInSolution = false;
                       }
                       else
                       {
                           numberOfResultPoint++;
                           isFirstPointInSolution = true;
                       }
                   }

                   count--;
               }


               if (isFirstPointInSolution)
               {
                   x = Helper.X(convexHull[numberOfResultPoint, 0], convexHull[0, 0], convexHull[numberOfResultPoint, 1], convexHull[0, 1], lossesRate, controledStateNumber);
                   result = Helper.CountResult(indexEquivalent, numberOfResultPoint, 0, x, sizeLossArray);
               }

               return new Solution(result, 0.0);
           
           }
           else
           {
               return new Solution(result, 0.0);
           }
       }


       int  FindMinUncontroledPoints(double[,] hull, int numberContrState)
       {
           int  minUncontroledPoints = 0;

           if (numberContrState == 1)
           { 
             for(int i = 1; i< hull.Length/2; i++)
             {
                 if (hull[i, 1] < hull[minUncontroledPoints, 1])
                 {
                     minUncontroledPoints =i;
                 }
                 if (hull[i, 1] == hull[minUncontroledPoints, 1] && hull[i, 0] < hull[minUncontroledPoints, 0])
                 {
                     minUncontroledPoints = i;
                 }
             }
           }

           if (numberContrState == 2)
           {
               for (int i = 1; i < hull.Length / 2; i++)
               {
                   if (hull[i, 0] < hull[minUncontroledPoints, 0])
                   {
                       minUncontroledPoints = i;
                   }
                   if (hull[i, 0] == hull[minUncontroledPoints, 0] && hull[i, 1] < hull[minUncontroledPoints, 1])
                   {
                       minUncontroledPoints = i;
                   }
               }
           }

           return minUncontroledPoints;
       }
       bool IsAllControledPointsSuits(double[,] hull, int numberContrState, double rate)
       {
           bool IsAllControledPointsSuitsResult = false;

           if (numberContrState == 1)
           {
               for (int i = 0; i < hull.Length / 2; i++)
               {
                   if (hull[i, 0] < rate)
                   {
                       IsAllControledPointsSuitsResult = true;
                   }
                   else
                   {
                       IsAllControledPointsSuitsResult = false;
                       break;
                   }
               }
           }

           if (numberContrState == 2)
           {
               for (int i = 0; i < hull.Length / 2; i++)
               {
                   if (hull[i, 1] < rate)
                   {
                       IsAllControledPointsSuitsResult = true;
                   }
                   else
                   {
                       IsAllControledPointsSuitsResult = false;
                       break;
                   }
               }
           }

           return IsAllControledPointsSuitsResult;
       }
       bool DoesExistResult(double[,] hull, int numberContrState, double rate)
       {
           bool doesExistsResult = true;
           if (numberContrState == 1)
           {
               for (int i = 0; i < hull.Length / 2; i++)
               {
                   if (hull[i, 0] <= rate)
                   {
                       doesExistsResult = true;
                       return doesExistsResult;
                   }
                   else
                   {
                       doesExistsResult = false;
                   }
               }
           }

           if (numberContrState == 2)
           {
               for (int i = 0; i < hull.Length / 2; i++)
               {
                   if (hull[i, 1] <= rate)
                   {
                       doesExistsResult = true;
                       return doesExistsResult;
                   }
                   else
                   {
                       doesExistsResult = false;
                   }
               }
           }

           return doesExistsResult;
       }
       double[,] UpdateHull(double[,] hull, int numberContrState, double rate)
       {
           double[,] newHull = hull;
           if (numberContrState == 1)
           {
               for (int i = 0; i < newHull.Length/2; i++)
               {
                   if (newHull[i, 0] > rate)
                   {
                       newHull[i, 0] = rate;
                   }
               }
           }

           if (numberContrState == 2)
           {
               for (int i = 0; i < newHull.Length/2; i++)
               {
                   if (newHull[i, 1] > rate)
                   {
                       newHull[i, 1] = rate;
                   }
               }
           }
           return newHull;
       }
    }
}
