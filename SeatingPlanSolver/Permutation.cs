using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeatingPlanSolver
{
    public class Permutation
    {
        private int[] perm;
        private int N;
        public static Permutation[] T = new Permutation[1];

        public Permutation(int N)
        {
            this.N = N;
            this.perm = new int[N];
        }

        public Permutation(int[] perm)
        {
            this.N = perm.Length;
            this.perm = perm;
        }

        public static Permutation RandomPermutation(int N)
        {
            Permutation Perm = new Permutation(N);
            Random rand = new Random();

            for (int i = 0; i < N; i++)
                Perm.perm[i] = i + 1;

            for (int i = N - 1; i >= 1; i--)
                _Swap(ref Perm.perm[i], ref Perm.perm[rand.Next(0, i - 1)]);

            return Perm;
        }

        private static void _Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public int this[int i]
        {
            get { return this.perm[i - 1]; }
            set { this.perm[i - 1] = value; }
        }

        public int Length
        {
            get { return this.N; }
        }

        public int[] Perm
        {
            get { return this.perm; }
        }

        public Permutation Clone()
        {
            return new Permutation(this.perm);
        }

        public static Permutation Transposition(int N, int i, int j)
        {
            Permutation P = new Permutation(N);

            for (int n = 1; n <= N; n++)
            {
                if (n == i)
                    P[n] = j;
                else if (n == j)
                    P[n] = i;
                else
                    P[n] = n;
            }

            return P;
        }

        public static double MaximiseUtilityFunction(Permutation initialP, Func<Permutation, double> U, out Permutation optimalP)
        {
            int N = initialP.Length;

            //Step 1: Let P be any permutation
            Permutation P = initialP.Clone();

            //Step 2: Calculate M = U(P)
            double M = U(P);
            //System.Diagnostics.Debug.WriteLine("Initial Utility: {0}", M);

            if (T.Length == 1)
            {
                //Step 3: Generate the set T of Transpositions
                T = new Permutation[(N * (N - 1)) / 2];

                int index = 0;
                for (int i = 1; i <= N - 1; i++)
                    for (int j = i + 1; j <= N; j++)
                    {
                        T[index] = Permutation.Transposition(N, i, j);
                        index++;
                    }
            }

            Permutation S = new Permutation(N);
            while (true)
            {
                //Steps 4 + 5: Calculate L = max{U(T[n]*P):0<=n<=N-2}
                double L = 0;
                for (int n = 0; n < T.Length; n++)
                {
                    double u = U(T[n] * P);
                    if (n == 0)
                    {
                        L = u;
                        S = T[0];
                    }
                    else if (u > L)
                    {
                        L = u;
                        S = T[n];
                    }
                }

                //Step 6: if L > M, put M = L, put P = S*P and loop again. Else, break.
                if (L > M)
                {
                    M = L;
                    P = S * P;
                    //System.Diagnostics.Debug.WriteLine("New Utility: {0}", M);
                    //System.Diagnostics.Debug.WriteLine("New Plan: {0}", P);
                }
                else
                {
                    //System.Diagnostics.Debug.WriteLine("Local Maximum Found: {0}", P);
                    break;
                }
            }

            optimalP = P;

            return M;
        }

        public static Permutation operator*(Permutation P, Permutation Q)
        {
            if (P.Length != Q.Length)
                throw new Exception("Permutation length mismatch");

            Permutation R = new Permutation(P.Length);
            for (int i = 1; i <= R.Length; i++)
                R[i] = P[Q[i]];

            return R;
        }

        private static void _Swap(ref double a, ref double b)
        {
            double temp = a;
            a = b;
            b = temp;
        }

        public override string ToString()
        {
            StringBuilder S = new StringBuilder("(");

            for (int i = 1; i <= this.N; i++)
            {
                S.Append(this[i]);
                if (i != this.N)
                {
                    S.Append(" ");
                }
            }

            S.Append(")");

            return S.ToString();
        }

        public static void Sort(double[] array)
        {
            for(int i = 0; i<array.Length; i++)
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        _Swap(ref array[i], ref array[j]);
                    }
                }
        }

        public Permutation Inverse()
        {
            Permutation inverse = new Permutation(this.N);

            for (int i = 1; i <= inverse.N; i++)
            {
                inverse[this[i]] = i;
            }

            return inverse;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Permutation))
                return false;

            Permutation P = (Permutation)obj;

            if (this.N != P.N)
                return false;

            for (int i = 1; i <= this.N; i++)
                if (this[i] != P[i])
                    return false;

            return true;
        }
    }
}
