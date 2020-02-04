using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerical_methods_of_linear_algebra
{
    class IterativeMethod
    {
        private List<List<double>> A;
        private List<double> b;
        private List<double> x;
        public int Size { get; set; }
        public decimal EPS { get; set; }
        public IterativeMethod(int size)
        {
            A = new List<List<double>>();
            b = new List<double>();
            x = new List<double>();
            Size = size;
            for (var i = 0; i < size; i++)
            {
                A.Add(new List<double>());
            }
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    A[i].Add(0);
                }
            }
            for (int i = 0; i < size; i++)
            {
                b.Add(0);
            }
            for (int i = 0; i < size; i++)
            {
                x.Add(0);
            }
        }

        public void GetMatrix()
        {
            foreach (var colunm in A)
            {
                foreach (var elem in colunm)
                {
                    Console.Write(elem + "  ");
                }
                Console.WriteLine();
            }
        }
        public void SetMaxrix()
        {
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    Console.Write("input A[" + i + "] [" + j + "]=  ");
                    A[i][j] = Double.Parse(Console.ReadLine());
                }
            }
            for (int i = 0; i < Size; i++)
            {
                Console.Write("input b[" + i + "]=  ");
                b[i] = Double.Parse(Console.ReadLine());
            }
        }
        protected void DiagonalAdvantage()
        {
            List<double> ElemSum = new List<double>();
            for (int i = 0; i < Size; i++)
            {
                double temp = 0;
                for (int j = 0; j < Size; j++)
                {
                    if (i != j)
                    {

                        temp += Math.Abs(A[i][j]);
                    }
                }
                ElemSum.Add(temp);
            }
            for (int k = 0; k < Size; k++)
            {
                if (ElemSum[k] >= A[k][k])
                {
                    List<List<double>> D = new List<List<double>>();
                    for (int i = 0; i < Size; i++)
                    {
                        D.Add(new List<double>());
                    }
                    for (int i = 0; i < Size; i++)
                    {
                        for (int j = 0; j < Size; j++)
                        {
                            if (i != j)
                            {
                                D[i].Add(0);
                            }
                            else
                            {
                                D[i].Add(Size);
                            }
                        }
                    }

                }
            }

        }
        public void JacobisMethod()
        {


            List<double> Xnext = new List<double>();
            List<List<double>> C = new List<List<double>>();
            List<double> d = new List<double>();
            for (int i = 0; i < Size; i++)
            {
                C.Add(new List<double>());
            }
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    C[i].Add(0);
                }
            }
            for (int i = 0; i < Size; i++)
            {
                Xnext.Add(0);
            }

            for (int i = 0; i < Size; i++)
            {

                for (int j = 0; j < Size; j++)
                {
                    if (i != j)
                    {
                        C[i][j] -= A[i][j] / A[i][i];

                    }
                }
                d.Add(b[i] / A[i][i]);
            }
            List<double> Csum = new List<double>();
            for (int i = 0; i < Size; i++)
            {
                double temp = 0;
                for (int j = 0; j < Size; j++)
                {
                    temp += Math.Abs(C[i][j]);
                }

                if (temp < 1)
                {
                    Csum.Add(temp);
                    Console.WriteLine(temp);
                }
                else
                {
                    Console.WriteLine("C sum > 1");
                }
            }
            foreach (var colunm in C)
            {
                foreach (var elem in colunm)
                {
                    Console.Write(elem + "  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            // x = d;
            for (int i = 0; i < Size; i++)
            {
                x[i] = d[i];
            }
            foreach (var elem in d)
            {
                Console.Write(elem + "  ");
            }
            Console.WriteLine();
            int k = 0;
            while (true)
            {


                for (int i = 0; i < Size; i++)
                {
                    double temp = 0;
                    for (int j = 0; j < Size; j++)
                    {

                        if (i != j)
                        {
                            temp += C[i][j] * x[j];

                        }

                    }
                    temp += d[i];
                    Xnext[i] = (temp);
                }
                Console.Write("x^" + k + " ={");

                foreach (var elem in Xnext)
                {
                    Console.Write(elem + ", ");
                }
                Console.Write(" }");
                List<double> differens = new List<double>();

                for (int i = 0; i < Size; i++)
                {
                    differens.Add(Math.Abs(x[i] - Xnext[i]));
                }
                Console.WriteLine();
                Console.Write("differens = {");
                for (int i = 0; i < Size; i++)
                {
                    Console.Write(differens[i] + ",   ");
                }
                Console.Write(" }");
                double a = differens.Max();
                Console.WriteLine($" Max differens = {a} ");
                Console.WriteLine();
                if (a < 0.000001)
                {
                    Console.WriteLine("STOP");
                    break;
                }
                k++;
                for (int i = 0; i < Size; i++)
                {
                    x[i] = Xnext[i];
                }


            }
            for (int i = 0; i < Size; i++)

            {
                double temp = 0;
                for (int j = 0; j < Size; j++)
                {
                    temp += A[i][j] * x[j];
                }
                temp -= b[i];
                Console.WriteLine("   " + temp + "   ");
            }
            Console.WriteLine();
        }
    }
}
