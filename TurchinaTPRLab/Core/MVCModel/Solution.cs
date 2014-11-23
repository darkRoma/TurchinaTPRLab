using System;
using System.Collections;
using System.Collections.Generic;

using DecisionTheory.Core.Error;

namespace DecisionTheory.Core.MVCModel
{
    /// <summary>
    /// This class encapsulates a decision-making solution data
    /// </summary>
    public class Solution : IEnumerable<double>
    {
        private ICollection<double> vector;
        private bool[] active;
        private int bestId;
        private double loss;
        private double[] randSolution;

        /// <summary>
        /// Constructor the clones solution vector array and sets it as own field.
        /// <para>Also it sets id of the best solution </para>
        /// </summary>
        /// <param name="vector">solution vector</param>
        /// <param name="bestId">best solution id</param>
        public Solution(double[] vector, int bestId)
        {
            try
            {
                this.vector = (double[]) vector.Clone();
            }
            catch (Exception cause)
            {
                throw new DataException(cause);
            }

            if (bestId < 0 || bestId >= vector.Length)
                throw new DataException();
            this.bestId = bestId;
        }

        /// <summary>
        /// Constructor the clones solution vector and active arrays and sets them as own fields.
        /// <para>Also it sets id of the best solution </para>
        /// </summary>
        /// <param name="vector">solution vector</param>
        /// <param name="active">states of solutions active/inactive</param>
        /// <param name="bestId">best solution id</param>
        public Solution(double[] vector, bool[] active, int bestId)
            : this(vector, bestId)
        {
            try
            {
                this.active = (bool[])active.Clone();
            }
            catch (Exception cause)
            {
                throw new DataException(cause);
            }
        }

        /// <summary>
        /// Constructor the clones solution vector array and sets it as own field.
        /// <para>Also it sets losses for rand solution </para>
        /// </summary>
        /// <param name="vector">solution vector</param>
        /// <param name="bestId">losses</param>
        public Solution(double[] randSolution, double loss)
        {
            try
            {
                this.randSolution = (double[])randSolution.Clone();
            }
            catch (Exception cause)
            {
                throw new DataException(cause);
            }

            this.loss = loss;
        }

        public Solution(double[] randSolution)
        {
            try
            {
                this.randSolution = (double[])randSolution.Clone();
            }
            catch (Exception cause)
            {
                throw new DataException(cause);
            }
        }
        /// <summary>
        /// Getter for best id field
        /// </summary>
        /// <returns>id of the best decision in current solution</returns>
        public int getBestId()
        {
            return bestId;
        }

        public double[] getSolution()
        {
            return randSolution;
        }

        public double getLoss()
        {
            return loss;
        }

        /// <summary>
        /// Getter for solution active state elements by index
        /// </summary>
        /// <returns>the solution state</returns>
        public bool isActive(int index)
        {
            if (active == null)
                return true;

            if (index < 0 || index >= active.Length)
                throw new DataException();
            return active[index];
        }

        /// <summary>
        /// This method has been implemented for IEnumerable interface supporting
        /// </summary>
        /// <returns>enumerator for solution vector</returns>
        public IEnumerator<double> GetEnumerator()
        {
            return (IEnumerator<double>) vector.GetEnumerator();
        }

        /// <summary>
        /// This method has been implemented for IEnumerable interface supporting
        /// </summary>
        /// <returns>enumerator for solution vector</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return vector.GetEnumerator();
        }
    }
}
