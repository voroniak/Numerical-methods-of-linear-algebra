using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerical_methods_of_linear_algebra
{
    class TridiagonalMatrixAlgorithm
    {
        public TridiagonalMatrixAlgorithm(int size)
        {
            Size = size;
        }
        public TridiagonalMatrixAlgorithm(int size, double a, double b)
        {
            Size = size;
            this.a = a;
            this.b = b;
        }
        public int Size { get; set; }
        private List<double> C;
        private List<double> A;
        private List<double> B;
        private List<double> H;
        private List<double> Alpha;
        private List<double> Beta;
        private List<double> F;
        private List<double> Mu;
        private List<double> Y;
        public double a { get; set; }
        public double b { get; set; }
        public void SetC()
        {
            C = new List<double>(Size);
            for (int i = 0; i < Size; i++)
            {
                Console.WriteLine("input C[" + i + "] = ");
                C.Add(-Double.Parse(Console.ReadLine()));
            }
        }
        public void GetC()
        {
            Console.Write("C= {");
            foreach (var item in C)
            {
                Console.Write(item + "  ");
            }
            Console.Write("}");
        }
        public void SetA()
        {
            A = new List<double>(Size - 2);
            for (int i = 0; i < Size - 2; i++)
            {
                Console.WriteLine("input A[" + i + "] = ");
                A.Add(Double.Parse(Console.ReadLine()));
            }
        }
        public void GetA()
        {
            Console.Write("A= {");
            foreach (var item in A)
            {
                Console.Write(item + "  ");
            }
            Console.Write("}");
        }
        public void SetB()
        {
            B = new List<double>(Size - 2);
            for (int i = 0; i < Size - 2; i++)
            {
                Console.WriteLine("input B[" + i + "] = ");
                B.Add(Double.Parse(Console.ReadLine()));
            }
        }
        public void GetB()
        {
            Console.Write("B= {");
            foreach (var item in B)
            {
                Console.Write(item + "  ");
            }
            Console.Write("}");
        }
        public void SetH()
        {
            H = new List<double>(2);
            Console.WriteLine("input H[0] = ");
            H.Add(-Double.Parse(Console.ReadLine()));
            Console.WriteLine("input H[2] = ");
            H.Add(-Double.Parse(Console.ReadLine()));
        }
        public void GetH()
        {
            Console.Write("H= {");
            foreach (var item in H)
            {
                Console.Write(item + "  ");
            }
            Console.Write("}");
        }
        public void SetF()
        {
            F = new List<double>(Size - 2);
            for (int i = 0; i < Size - 2; i++)
            {
                Console.WriteLine("input F[" + i + "] = ");
                F.Add(-Double.Parse(Console.ReadLine()));
            }
        }
        public void GetF()
        {
            Console.Write("F= {");
            foreach (var item in F)
            {
                Console.Write(item + "  ");
            }
            Console.Write("}");
        }
        public void SetMu()
        {
            Mu = new List<double>(2);
            Console.WriteLine("input Mu[0] = ");
            Mu.Add(Double.Parse(Console.ReadLine()));
            Console.WriteLine("input Mu[1] = ");
            Mu.Add(Double.Parse(Console.ReadLine()));
        }
        public void GetMu()
        {
            Console.Write("Mu= {");
            foreach (var item in Mu)
            {
                Console.Write(item + "  ");
            }
            Console.Write("}");
        }
        public void ChangeCoef()
        {
            if (C[0] != 1)
            {
                H[0] = H[0] / (-C[0]);
                Mu[0] = Mu[0] / (-C[0]);
            }
            C.Remove(C[0]);
            if (C[C.Count - 1] != 1)
            {
                H[1] = H[1] / (-C[C.Count - 1]);
                Mu[1] = Mu[1] / (-C[C.Count - 1]);
            }
            C.Remove(C[C.Count - 1]);
        }
        public void FindAlphaAndBeta()
        {

            Alpha = new List<double>();
            Beta = new List<double>();
            Alpha.Add(H[0]);
            Beta.Add(Mu[0]);
            for (int i = 0; i < A.Count; i++)
            {
                Alpha.Add(B[i] / (C[i] - A[i] * Alpha[i]));
                Beta.Add((F[i] + A[i] * Beta[i]) / (C[i] - A[i] * Alpha[i]));
            }
            Console.WriteLine();
            foreach (var item in Alpha)
            {
                Console.Write(item + "  ");
            }
            Console.WriteLine();
            foreach (var item in Beta)
            {
                Console.Write(item + "  ");
            }
            Y = new List<double>(Size);
            for (int i = 0; i < Size + 1; ++i)
            {
                Y.Add(0);
            }
            Y[Size] = (Mu[1] + H[1] * Beta[Beta.Count - 1]) / (1 - H[1] * Alpha[Alpha.Count - 1]);
            for (int i = Size - 1; i >= 0; i--)
            {
                Y[i] = Alpha[i] * Y[i + 1] + Beta[i];
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < Size + 1; i++)
            {
                Console.WriteLine(" y[" + i + "]=    " + Y[i] + "       y[" + i + "] =    " + 1 / (1 + i * ((b - a) / Size)));
                Console.WriteLine(Y[i] - (1 / (1 + i * ((b - a) / Size))));
            }
        }
        public void Def_thihg()
        {
            A = new List<double>();
            B = new List<double>();
            C = new List<double>();
            H = new List<double>();
            Mu = new List<double>();
            F = new List<double>();
            double h = (b - a) / Size;
            H.Add(0);
            H.Add(0);

            for (int i = 1; i < Size; i++)
            {
                double fi = -2 / (((1 + i * h) * (1 + i * h) * (1 + i * h)));
                F.Add(fi);

                double ai = 1 / (h * h) + (1 + i * h) / (2 * h);
                A.Add(ai);

                double bi = 1 / (h * h) - (1 + i * h) / (2 * h);
                B.Add(bi);

                double ci = (1 + 2 / (h * h));
                C.Add(ci);

            }
            double f0 = 1;
            Mu.Add(f0);
            double fn = 0.5;
            Mu.Add(fn);


        }
    }
}
