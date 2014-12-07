using System;

namespace GurwitsRandomCriterion
{
    /// <summary>
    /// Класс, содержащий информацию о рандомизированном решении по Гурвицу
    /// x*Alpha(i) + (1-x)*Alpha(j)
    /// </summary>
    public class GurwitsSolution
    {
        public double x = double.NaN;
        /// <summary>
        /// Индексы двух составляющих решения. Если решение - точка платежного множества,
        /// тогда одно из значений отрицательно
        /// </summary>
        public int i = -1, j = -1;
        /// <summary>
        /// Матрица потерь, чтобы понимать, для каких данных делали решение
        /// </summary>
        public double[,] data;

        public double lm;

        public override string ToString()
        {
            var str = string.Format("x={0:0.000}", x);
            if (i >= 0) str += ", i=" + i;
            if (j >= 0) str += ", j=" + j;
            return str;
        }

        public double[] getLosses()
        {
            if (i < 0)
                if (j < 0) // нет решений
                    return null;
                else //одно решение => j
                    return new double[] { data[j, 0], data[j, 1] };
            if (j < 0)//одно решение => i
                return new double[] { data[i, 0], data[i, 1] };
            //смешенное решение
            return new double[] { x * data[i, 0] + (1 - x) * data[j, 0], 
                x * data[i, 1] + (1 - x) * data[j, 1] };
        }
    }

    public static class Gurwits
    {
        /// <summary>
        /// Метод принимает матрицу потерь и лямбду и возвращает экземпляр класса
        /// <para>рандом. решение по Гурвицу</para>
        /// <para>WARNING: [говнокод]</para>
        /// </summary>
        /// <param name="data">матрица потерь</param>
        /// <param name="lm">лямбда</param>
        public static GurwitsSolution getResult(double[,] data, double lm)
        {
            if (lm < 0 || lm >1)
                return null;
            //WARNING я не проверяю: data==null, data.rows>0, data.cols==2

            var solve = new GurwitsSolution();
            solve.data = data;
            solve.lm = lm;

            var rows = data.GetLength(0);

            const double EPS = 1e-6;
            //Можно просто перебрать все вершины... все равно программа работает для N < 10^6, иначе это было бы критично.
            //Правильный, но сложный и никому не нужный вариант:
            //пришлось бы искать пересечение двух прямых с юго-западной частью платежного множества,
            //причем при разных лямбда - разные прямые

            if (lm < 0.5) 
            {
                for (int i = 0; i < rows;++i)
                    for (int j = i + 1; j < rows; ++j)
                    {
                        double di = data[i, 0] - data[i, 1];
                        double dj = data[j, 0] - data[j, 1];
                        if (Math.Abs(di - dj) < EPS)
                        {
                            //di == dj
                            if (Math.Abs(di) < EPS)
                                continue;
                        }
                        else
                        {
                            //di != dj
                            double x = dj / (dj - di);
                            if (x < 0 || x > 1) continue;

                            var cur_losses = data[i, 0] * x + (1 - x) * data[j, 0];
                            if (double.IsNaN(solve.x) || (solve.getLosses()[0] > cur_losses))
                            {
                                solve.x = x; solve.i = i; solve.j = j;
                            }
                        }
                    }

                var br = brute(data, lm);
                var br_losses = br.getLosses(); 
                var br_max = Math.Max(br_losses[0], br_losses[1]);

                if (double.IsNaN(solve.x))
                    return br;

                var losses = solve.getLosses(); 
                var max = Math.Max(losses[0], losses[1]);
                if (br_max < max)
                    return br;
                return solve;
            }

            if (lm < 1) return brute(data, lm);

            solve.i = 0; solve.x = 1;
            var dmin = Math.Min(data[0, 0], data[0, 1]);
            for (int i = 0; i < rows; ++i)
            {
                var di = Math.Min(data[i, 0], data[i, 1]);
                if (di < dmin)
                {
                    dmin = di; solve.i = i;
                }
            }
            return solve;
        }

        /// <summary>
        /// Перебор по вершинам
        /// </summary>
        /// <param name="data">матрица потерь</param>
        /// <param name="lm">лямбда</param>
        /// <returns></returns>
        public static GurwitsSolution brute(double[,] data, double lm)
        {
            var solve = new GurwitsSolution();
            solve.data = data; solve.lm = lm;
            solve.i = 0; solve.x = 1;
            var rows = data.GetLength(0);
            var dmin = Math.Max(data[0, 0], data[0, 1]);
            for (int i = 0; i < rows; ++i)
            {
                var di = Math.Max(data[i, 0], data[i, 1]);
                if (di < dmin)
                {
                    dmin = di; solve.i = i;
                }
            }
            return solve;
        }
    }

    
    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        var data = new double[4, 2] //матрица потерь
    //        { { 0, 4 }, { 5, 1 }, { 6, 3 }, { 3, 2 } };
    //        var lambda = 0.25; //коэффициент позитива
    //        var solve = Gurwits.getResult(data, lambda);

    //        var color = Console.ForegroundColor;
    //        if (solve != null)
    //        {
    //            Console.ForegroundColor = ConsoleColor.Green;
    //            Console.WriteLine("solution\n" + solve);
    //        }

    //        else
    //        {
    //            Console.ForegroundColor = ConsoleColor.Red;
    //            Console.WriteLine("no solution" );
    //        }

    //        Console.ForegroundColor = color;
    //        Console.WriteLine("press enter to exit...");
    //        Console.ReadLine();
    //    }
    //}
}
