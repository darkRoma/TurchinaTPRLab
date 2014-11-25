using System;
using System.Text;
using DecisionTheory.Core.Error;
using DecisionTheory.Core.Service;


namespace DecisionTheory.Core.MVCModel
{
    /// <summary>
    /// MVC model class
    /// </summary>
    public class Model : ICloneable
    {
        private double[,] data;
        private double lossesRate;
        private int controledStateNumber;
        private double gradientX;
        private double gradientY;
        public int colums;
        private double liambda;

        /// <summary>
        /// Constructor that sets decisions count and states count fields and creating a data matrix
        /// </summary>
        /// <param name="decisionsCount">decisions count</param>
        /// <param name="statesCount">states count</param>
        public Model(int decisionsCount, int statesCount)
        {
            data = new double[decisionsCount, statesCount];
            lossesRate = 0;
            controledStateNumber = 0;
            colums = statesCount;
        }

        public double Liambda
        {
            get { return liambda; }
            set
            {
                if ((value >= 0) || (value <= 1))
                {
                    liambda = value;
                }
                else
                {
                    throw new DataException();
                }                
            }
        }

        public double GradientX
        {
            get { return gradientX; }
            set
            {
                if (value >= 0)
                { gradientX = value; }
                else
                { throw new DataException(); }
            }
        }

        public double GradientY
        {
            get { return gradientY; }
            set
            {
                if (value >= 0)
                { gradientY = value; }
                else
                { throw new DataException(); }
            }
        }

        public double LossestRate
        {
            get { return lossesRate; }

            set
            {
                if (value >= 0)
                { lossesRate = value; }
                else
                {
                    {
                        throw new DataException();
                    }
                }
            }
        }

        public int ControledStateNumber
        {
            get { return controledStateNumber; }

            set
            {
                if (value > 0 && value <=2)
                { controledStateNumber = value; }
                else
                { 
                 throw new DataException() ;
                }
            }
        }
        /// <summary>
        /// This method is getter for data matrix
        /// </summary>
        /// <param name="i">decision index</param>
        /// <param name="j">state index</param>
        /// <returns>data for corresponding indexes of decision and state</returns>
        public double getData(int i, int j)
        {
            try
            {
                return data[i, j];
            }
            catch (Exception cause)
            {
                throw new DataException(cause);
            }
        }

        /// <summary>
        /// This method is setter for data matrix
        /// </summary>
        /// <param name="i">decision index</param>
        /// <param name="j">state index</param>
        /// <param name="value">data value</param>
        public void setData(int i, int j, double value)
        {
            try
            {
                data[i, j] = value;
            }
            catch (Exception cause)
            {
                throw new DataException(cause);
            }
        }

        /// <summary>
        /// Getter for decisions count field
        /// </summary>
        /// <returns>decisions count</returns>
        public int getDecisionsCount()
        {
            return data.GetLength(0);
        }

        /// <summary>
        /// Getter for states count field
        /// </summary>
        /// <returns>states count</returns>
        public int getStatesCount()
        {
            return data.GetLength(1);
        }

        /// <summary>
        /// This method loads data model from file and returns it
        /// </summary>
        /// <param name="fileName">the name of file</param>
        /// <returns>loaded data model</returns>
        public static Model load(string fileName)
        {
            try
            {
                var scanner = new Scanner(fileName);
                int rows = scanner.getNext<int>();
                int cols = scanner.getNext<int>();

                var model = new Model(rows, cols);
                for (int i = 0; i < rows; ++i)
                    for (int j = 0; j < cols; ++j)
                    {
                        var value = scanner.getNext<double>();
                        model.setData(i, j, value);
                    }
                return model;
            }
            catch (Exception cause)
            {
                throw new DataException(cause);
            }
        }

        /// <summary>
        /// This method saves this data model to file
        /// </summary>
        /// <param name="fileName">the name of file</param>
        public void save(string fileName)
        {
            try
            {
                Saver.save(this, fileName);
            }
            catch (Exception cause)
            {
                throw new DataException(cause);
            }
        }

        /// <summary>
        /// This method makes a state description of this instance
        /// </summary>
        /// <returns>string that describes data matrix</returns>
        public override string ToString()
        {
            int rows = getDecisionsCount();
            int cols = getStatesCount();

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} {1}\n", rows, cols);
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    if (data[i, j] != null)
                        sb.AppendFormat("{0:0.0000} ", data[i, j]);
                    else
                        sb.Append("null ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        /// <summary>
        /// This method has been implemented for ICloneable interface supporting
        /// </summary>
        /// <returns>clone of this instance</returns>
        public object Clone()
        {
            var rows = getDecisionsCount();
            var cols = getStatesCount();
            var model = new Model(rows, cols);
            for (int i = 0; i < rows; ++i)
                for (int j = 0; j < cols; ++j)
                    model.setData(i, j, getData(i, j));
            return model;
        }

        /// <summary>
        /// Для Насти
        /// </summary>
        /// <returns>возвращает матрицу потерь из модели.</returns>
        public double[,] getLossesArray()
        {
            var clone = (Model)Clone();
            return clone.data;
        }
    }
}