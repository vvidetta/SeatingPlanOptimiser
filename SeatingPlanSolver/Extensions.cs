using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeatingPlanSolver
{
    public static class Extensions
    {
        public static bool ContainsElement(this List<Permutation> permCollection, Permutation perm)
        {
            int N = permCollection.Count;
            bool flag = false;
            for (int i = 0; i < N; i++)
                flag = flag || (perm.Equals(permCollection[i]));

            return flag;           
        }
    }
}
