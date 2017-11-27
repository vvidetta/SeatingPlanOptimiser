using System;
using System.Collections.Generic;
using System.IO;

namespace SeatingPlanSolver
{
    public class SeatingPlanOptimizer
    {
        #region Data members

        private string relationshipPath;
        private string seatingPlanPath;
        private string weightPath;

        private BijectiveMap<int, string> guestList = new BijectiveMap<int, string>();

        private Matrix W;
        private Matrix R;
        private Matrix symR;
        private Matrix symW;
        private Matrix P;
        private Func<Permutation, double> U;
        private Func<Permutation, int> countHappyPeople;
        private double HappinessThreshold = 0.8;

        private Permutation optimalSeatingPlan;

        #endregion

        #region Constructors

        public SeatingPlanOptimizer ()
	   {
           U = (P) =>
           {
               double acc = 0;
               for (int k = 1; k < P.Length; k++)
                   for (int l = k + 1; l <= P.Length; l++)
                   {
                       if (symW[k, l] != 0 && symR[P[k], P[l]] != 0)
                           acc += symW[k, l] * symR[P[k], P[l]];
                   }
               return acc;
           };
           countHappyPeople = (P) =>
           {
               int testNumHappy = 0;
               for (int i = 1; i <= P.Length; i++)
                   if (CalculateIndividualUtility(i, P) / CalculateMaximumUtility(i, P) >= HappinessThreshold)
                       testNumHappy++;

               return testNumHappy;
           };
	   }

        #endregion

        #region Operations


        public double CalculateIndividualUtility(string guestName)
        {
            int i = this.guestList.GetBySecond(guestName);
            return CalculateIndividualUtility(i, optimalSeatingPlan);
        }

        public double CalculateIndividualUtility(int i, Permutation Q)
        {
            Permutation P = Q.Inverse();

            double acc = 0;
            for (int j = 1; j <= P.Length; j++)
            {
                if (i != j)
                {
                    acc += symW[P[i], P[j]] * symR[i, j];
                }
            }

            return acc;
        }

        private double CalculateMaximumUtility(int i, Permutation Q)
        {
            Permutation S = Q.Inverse();
            double[] localSeating = new double[S.Length];
            double[] bestBuddies = new double[S.Length];
            for (int j = 1; j <= S.Length; j++)
            {
                localSeating[j - 1] = symW[S[i], j];
                bestBuddies[j - 1] = symR[i, j];
            }

            Permutation.Sort(localSeating);
            Permutation.Sort(bestBuddies);

            double acc = 0;
            for (int j = 0; j < S.Length; j++)
            {
                acc += localSeating[j] * bestBuddies[j];
            }

            return acc;
        }

        public void LoadAndEvaluatePlan(string filename)
        {
            //load the plan into memory from file
            string[] rowList = File.ReadAllLines(filename);
            Permutation P = new Permutation(1);

            for (int i = 1; i <= rowList.Length; i++)
            {
                string[] row = rowList[i - 1].Split(",".ToCharArray());
                if (row.Length < 2)
                    throw new FormatException();
                if (row[0] != "Seat")
                {
                    if (i == 1)
                        P = new Permutation(rowList.Length);

                    P[Int32.Parse(row[0])] = this.guestList.GetBySecond(row[1]);
                }
                else
                {
                    P = new Permutation(rowList.Length - 1);
                }
            }

            
        }

        public void LoadGuestList(string guestListPath)
        {
            string[] rowList = File.ReadAllLines(guestListPath);
            this.guestList.Clear();
            
            foreach (string rowString in rowList)
            {
                string[] row = rowString.Split(",".ToCharArray());
                if (row.Length != 2)
                {
                    throw new FormatException();
                }

                int guestID = Int32.Parse(row[0]);
                string guestName = row[1];
                this.guestList.Add(guestID, guestName);
            }
        }

        public void LoadRelationshipMatrix(string relationshipPath)
        {
            this.relationshipPath = relationshipPath;
            this.R = Matrix.LoadFromCSV(relationshipPath);
        }

        public void LoadSeatingPlan(string seatingPlanPath)
        {
            this.seatingPlanPath = seatingPlanPath;
            this.P = Matrix.LoadFromCSV(this.seatingPlanPath);
        }

        public void LoadWeightMatrix(string weightPath)
        {
            this.weightPath = weightPath;
            this.W = Matrix.LoadFromCSV(weightPath);
        }

        public void Optimize(int numTrials)
        {
            System.Diagnostics.Stopwatch AStopwatch = new System.Diagnostics.Stopwatch();
            AStopwatch.Start();
            double utility = 0;
            symR = Matrix.SymmetricPart(R);
            symW = Matrix.SymmetricPart(W);

            int numHappy = 0;
            List<Permutation> TestedPerms = new List<Permutation>(numTrials);

            for (int n = 1; n <= numTrials; n++)
            {
                Permutation testSeatingPlan;
                Permutation initialP;

                do
                {
                    initialP = Permutation.RandomPermutation(W.Columns);
                }
                while (TestedPerms.ContainsElement(initialP));

                double testUtility = Permutation.MaximiseUtilityFunction(initialP, U, out testSeatingPlan);
                int testNumHappy = countHappyPeople(testSeatingPlan);

                if (testNumHappy > numHappy || n == 1)
                {
                    utility = testUtility;
                    this.optimalSeatingPlan = testSeatingPlan;
                    numHappy = testNumHappy;
                    System.Diagnostics.Debug.WriteLine("*** Trial #{0} ***", n);
                    System.Diagnostics.Debug.WriteLine(string.Format("New max: {0} Num Happy: {1}", utility, numHappy));
                }
                else if (testNumHappy == numHappy)
                {
                    if (testUtility > utility)
                    {
                        utility = testUtility;
                        this.optimalSeatingPlan = testSeatingPlan;
                        numHappy = testNumHappy;
                        System.Diagnostics.Debug.WriteLine("*** Trial #{0} ***", n);
                        System.Diagnostics.Debug.WriteLine(string.Format("New max: {0} Num Happy: {1}", utility, numHappy));
                    }
                }
                //bw.ReportProgress((int)((double)n / (double)numTrials * 100.0));
            }
            AStopwatch.Stop();
            System.Diagnostics.Debug.WriteLine("Max Utility: {0}", utility);
            System.Diagnostics.Debug.WriteLine("Num Happy: {0}", numHappy);
            System.Diagnostics.Debug.WriteLine("Time to test: {0}", AStopwatch.ElapsedMilliseconds);
        }

        public void SaveSeatingPlan(string filename, bool exportIndividualUtilities)
        {
            int[] Permutation = this.optimalSeatingPlan.Perm;

            // seat i person j
            using (FileStream fs = File.Create(filename))
            {
                StreamWriter sw = new StreamWriter(fs);

                if (!exportIndividualUtilities)
                {
                    sw.WriteLine("Seat,Person");
                    for (int n = 0; n < Permutation.Length; n++)
                    {
                        sw.WriteLine("{0},{1}", n + 1, this.guestList.GetByFirst(Permutation[n]));
                    }
                }
                else
                {
                    sw.WriteLine("Seat,Person,Utility,Max Utility");
                    for (int n = 0; n < Permutation.Length; n++)
                    {
                        sw.WriteLine("{0},{1},{2},{3}", n + 1, this.guestList.GetByFirst(Permutation[n]), CalculateIndividualUtility(Permutation[n], optimalSeatingPlan), CalculateMaximumUtility(Permutation[n], optimalSeatingPlan));
                    }
                }
                sw.Flush();
            }
        }

        #endregion

        #region Fields

        public IDictionary<int, string> GuestList
        {
            get { return this.guestList.FirstToSecondMap; }
        }

        public Permutation OptimalSeatingPlan
        {
            get { return this.optimalSeatingPlan; }
        }

        public double OptimalUtility
        {
            get { return U(this.optimalSeatingPlan); }
        }

        public Func<Permutation, double> Utility
        {
            get { return U; }
        }

        public Func<Permutation, int> CountHappyPeople
        {
            get { return this.countHappyPeople; }
        }

        #endregion
    }
}
