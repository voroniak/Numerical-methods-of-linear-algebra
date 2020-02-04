using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerical_methods_of_linear_algebra
{
    class SpAlgorithm
    {
        public SpAlgorithm(int size)
        {
            Size = size;
            arr = new List<List<double>>();
            for (int i = 0; i < Size; i++)
            {
                arr.Add(new List<double>());
            }
            Console.WriteLine(" input matrix :");
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    arr[i].Add(Double.Parse(Console.ReadLine()));
                }
            }
        }
        public int Size { get; set; }
        private List<List<double>> arr;
        public void Show()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Console.Write(arr[i][j] + "   ");
                }
                Console.WriteLine();
            }
        }
        public void SP()
        {
            List<double> y = new List<double>();
            List<double> yNext = new List<double>();
            for (int i = 0; i < Size; i++)
            {
                y.Add(1);
                yNext.Add(0);
            }

            double Mu1 = 0;
            double Mu2 = 0;
            do
            {
                Mu2 = Mu1;
                y = Norma(y, FindNorma(y));
                yNext = Mul(y);
                Mu1 = FindMu(yNext, y);
                Copy(y, yNext);

            }
            while (CheckRes(Mu1, Mu2));
            Console.WriteLine(Mu1);
            WriteMes("y before normation", yNext);
            WriteMes("y after normation", Norma(yNext, FindNorma(yNext)));

        }
        private double FindNorma(List<double> vect)
        {
            double norma = 0;
            for (int i = 0; i < vect.Count; i++)
            {
                norma += vect[i] * vect[i];
            }
            return Math.Sqrt(norma);
        }
        private double FindNomra(List<double> vect1, List<double> vect2)
        {
            double norma = 0;
            if (vect1.Count == vect2.Count)
            {
                for (int i = 0; i < vect1.Count; i++)
                {
                    norma += vect1[i] * vect2[i];
                }
                return Math.Sqrt(norma);
            }
            else
            {
                throw new Exception("vect1.Count != vect2.Count");
            }

        }
        private List<double> Norma(List<double> vect, double norma)
        {
            List<double> x = new List<double>();
            for (int i = 0; i < Size; i++)
            {
                x.Add(vect[i] / norma);
            }
            return x;
        }
        private List<double> Mul(List<double> vect)
        {
            List<double> res = new List<double>();
            for (int i = 0; i < Size; i++)
            {
                double temp = 0;
                for (int j = 0; j < Size; j++)
                {
                    temp += arr[i][j] * vect[j];
                }
                res.Add(temp);
            }
            return res;
        }
        private bool CheckRes(double num1, double num2)
        {
            return Math.Abs(num1 - num2) > 0.00001;
        }
        private double FindMu(List<double> vect1, List<double> vect2)
        {

            double temp1 = 0;
            double temp2 = 0;
            foreach (var item in vect1)
            {
                temp1 += item * item;
            }
            for (int i = 0; i < Size; i++)
            {
                temp2 += vect1[i] * vect2[i];
            }
            return temp1 / temp2;
        }
        private void WriteMes(string mes, List<double> vect)
        {
            Console.WriteLine(mes);
            foreach (var item in vect)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
        private void Copy(List<double> vect1, List<double> vect2)
        {
            for (int i = 0; i < Size; i++)
            {
                vect1[i] = vect2[i];
            }
        }
    }
}
