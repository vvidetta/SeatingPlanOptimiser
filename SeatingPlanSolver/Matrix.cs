using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SeatingPlanSolver
{
    public class Matrix
    {
        private double[,] matrix;
        private int rows;
        private int cols;

        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            this.matrix = new double[rows, cols];
        }

        public Matrix(int rows, int cols, double[,] matrix) : this(rows, cols)
        {
            for (int i = 0; i < this.rows; i++)
                for (int j = 0; j < this.cols; j++)
                    this.matrix[i, j] = matrix[i, j];
        }

        public double this[int i, int j]
        {
            get { return matrix[i - 1, j - 1]; }
            set { matrix[i - 1, j - 1] = value; }
        }

        public int Rows
        {
            get { return rows; }
        }

        public int Columns
        {
            get { return cols; }
        }

        public static Matrix operator*(Matrix A, Matrix B)
        {
            if (A.Columns != B.Rows)
                throw new Exception("Matrix dimension mismatch");

            Matrix C = new Matrix(A.Rows, B.Columns);

            for (int i = 1; i <= C.Rows; i++)
                for (int j = 1; j <= C.Columns; j++)
                {
                    C[i, j] = 0;
                    for (int k = 1; k <= A.Columns; k++)
                        C[i, j] += A[i, k] * B[k, j];
                }

            return C;
        }

        public static Matrix operator+(Matrix A, Matrix B)
        {
            if (A.Rows != B.Rows || A.Columns != B.Columns)
                throw new Exception("Matrix dimension mismatch (addition)");

            Matrix C = new Matrix(A.Rows, A.Columns);

            for (int i = 1; i <= C.Rows; i++)
                for (int j = 1; j <= C.Columns; j++)
                    C[i, j] = A[i, j] + B[i, j];

            return C;
        }

        public static Matrix operator /(Matrix A, double x)
        {
            Matrix C = A.Clone();

            for (int i = 1; i <= C.Rows; i++)
                for (int j = 1; j <= C.Columns; j++)
                    C[i, j] /= x;

            return C;
        }

        public int[] ToPermutation()
        {
            int[] Permutation = new int[this.rows];

            this.ForEach((i, j) =>
            {
                if (this[i, j] == 1)
                {
                    Permutation[i - 1] = j;
                }
            });

            return Permutation;
        }

        public static double Trace(Matrix M)
        {
            double acc = 0;

            for (int i = 1; i <= M.Rows; i++)
                acc += M[i, i];

            return acc;
        }

        public static Matrix Transpose(Matrix M)
        {
            Matrix A = new Matrix(M.Columns, M.Rows);

            for (int i = 1; i <= A.Rows; i++)
                for (int j = 1; j <= A.Columns; j++)
                    A[i, j] = M[j, i];

            return A;
        }

        public static Matrix LoadFromCSV(string filename)
        {
            string[] rowList = File.ReadAllLines(filename);
            Matrix Result = new Matrix(rowList.Length, rowList[0].Split(",".ToCharArray()).Length);

            for (int i = 1; i <= Result.Rows; i++)
            {
                string[] entries = rowList[i - 1].Split(",".ToCharArray());
                for (int j = 1; j <= Result.Columns; j++)
                {
                    if (entries[j - 1] == String.Empty)
                        Result[i, j] = 0;
                    else
                        Result[i, j] = Double.Parse(entries[j - 1]);
                }
            }

            return Result;
        }

        public Matrix Clone() {
            return new Matrix(this.rows, this.cols, this.matrix);
        }

        public Matrix Column(int j)
        {
            if (j < 1 || j > this.Columns)
                throw new IndexOutOfRangeException();

            Matrix v = new Matrix(this.Rows, 1);

            v.ForEachRow((i) => { v[i, 1] = this[i, j]; });

            return v;
        }

        public Matrix Row(int i)
        {
            if (i < 1 || i > this.Rows)
                throw new IndexOutOfRangeException();

            Matrix v = new Matrix(1, this.Columns);

            v.ForEachColumn((j) => { v[1, j] = this[i, j]; });

            return v;
        }

        public void ForEachRow(Action<int> code)
        {
            for (int i = 1; i <= this.rows; i++)
                code(i);
        }

        public void ForEachColumn(Action<int> code)
        {
            for (int j = 1; j <= this.Columns; j++)
                code(j);
        }

        public void ForEach(Action<int, int> code)
        {
            this.ForEachRow((i) => {
                this.ForEachColumn((j) =>
                {
                    code(i, j);
                });
            });
        }

        public static double MaximiseUtilityFunction(Matrix initialP, Func<Matrix, double> U, out Matrix optimalP)
        {
            int N = initialP.Rows;
            
            //Step 1: Let P be any permutation matrix
            Matrix P = initialP.Clone();

            //Step 2: Calculate M = U(P)
            double M = U(P);
            //System.Diagnostics.Debug.WriteLine("Initial Utility: {0}", M);

            //Step 3: Generate the set T of permutation matrices.
            Matrix[] T = new Matrix[(N * (N - 1)) / 2];

            int index = 0;
            for(int i = 1; i <= N - 1; i++)
                for (int j = i + 1; j <= N; j++)
                {
                    T[index] = Matrix.TranspositionMatrix(N, i, j);
                    index++;
                }

            Matrix S = new Matrix(N, N);
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
                else {
                    //System.Diagnostics.Debug.WriteLine("Local Maximum Found: {0}", P);
                    break;
                }
            }

            optimalP = P;

            return M;
        }

        public static Matrix RandomPermutationMatrix(int N)
        {
            ////Step 1: generate a random vector with distinct integer entries
            //Random rand = new Random();
            //Matrix v = new Matrix(1, N);
            //while (true)
            //{
            //    for (int j = 1; j <= N; j++)
            //    {
            //        v[1, j] = rand.Next();
            //    }

            //    bool matches = false;

            //    for (int i = 1; i <= N - 1; i++)
            //        for (int j = i + 1; j <= N; j++)
            //        {
            //            if (v[1, i] == v[1, j])
            //            {
            //                matches = true;
            //                j = N + 1;
            //                i = N;
            //            }
            //        }
                        

            //    if (!matches)
            //        break;
            //}

            ////Step 2: Calculate the order of the random numbers
            //Matrix order = new Matrix(1, N);
            //for (int n = 1; n <= N; n++)
            //{
            //    order[1, n] = N;
            //    var x = v[1, n];
            //    for (int m = 1; m <= N; m++)
            //    {
            //        if (x > v[1, m])
            //            order[1, n]--;
            //    }
            //}

            Permutation Perm = Permutation.RandomPermutation(N);

            //Step 3: Generate a permutation matrix from the order
            Matrix P = new Matrix(N, N);
            for (int i = 1; i<= N; i++)
                for (int j = 1; j <= N; j++)
                {
                    if (Perm[i] == j)
                        P[i, j] = 1;
                    else
                        P[i, j] = 0;
                }

            return P;
        }

        public static Matrix TranspositionMatrix(int N, int a, int b)
        {
            if (a == b)
                throw new Exception("Can't swap equal indices");

            if (a > N || a < 1 || b > N || b < 1)
                throw new Exception("Index out of range");

            Matrix M = new Matrix(N, N);

            for (int i = 1; i <= N; i++)
            {
                int col = i;
                if (i == a)
                    col = b;
                else if (i == b)
                    col = a;

                for (int j = 1; j <= N; j++)
                {
                    if (j == col)
                        M[i, j] = 1;
                    else
                        M[i, j] = 0;
                }
            }

            return M;
        }

        public static Matrix Parse(string s)
        {
            string rowList = s.Substring(1, s.Length - 2);
            string[] rows = rowList.Split(",".ToCharArray());
            Matrix Result = new Matrix(rows.Length, Matrix.ParseRow(rows[1]).Columns);
            for (int i = 1; i <= Result.Rows; i++)
            {
                Matrix CurrentRow = Matrix.ParseRow(rows[i]);
                for (int j = 1; j <= Result.Columns; j++)
                    Result[i, j] = CurrentRow[1, j];
            }

            return Result;
        }

        private static Matrix ParseRow(string s)
        {
            //format: "[a,b,c,d,...,z]"
            string numList = s.Substring(1, s.Length - 2);
            string[] nums = s.Split(",".ToCharArray());
            Matrix RowVector = new Matrix(1, nums.Length);

            for (int j = 1; j <= RowVector.Columns; j++)
                RowVector[1, j] = Double.Parse(nums[j - 1]);

            return RowVector;
        }

        public override string ToString()
        {
            StringBuilder S = new StringBuilder("[");

            for (int i = 1; i<=this.Rows; i++)
            {
                Matrix Row = new Matrix(1, this.Columns);
                for (int j = 1; j<= this.Columns; j++)
                    Row[1, j] = this[i, j];

                S.Append(Matrix.RowToString(Row));
            }

            S.Append("]");

            return S.ToString();
        }

        private static string RowToString(Matrix RowVector)
        {
            StringBuilder S = new StringBuilder("[");

            for (int j = 1; j <= RowVector.Columns; j++)
            {
                S.Append(RowVector[1, j].ToString());
                if (j != RowVector.Columns)
                    S.Append(",");
            }

            S.Append("]");

            return S.ToString();
        }
    }
}