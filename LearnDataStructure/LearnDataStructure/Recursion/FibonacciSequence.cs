using System;
using System.Collections.Generic;
using System.Text;

namespace LearnDataStructure.Recursion
{
   public class FibonacciSequence
   {
       private Dictionary<int, int> dictionary;

       public FibonacciSequence()
       {
           dictionary=new Dictionary<int, int>();
       }

        public int GetFibonacciSequenceByN(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (dictionary.ContainsKey(n))
            {
                return dictionary[n];
            }

            int ret = GetFibonacciSequenceByN(n - 1) + GetFibonacciSequenceByN(n - 2);
            dictionary.Add(n,ret);

            return GetFibonacciSequenceByN(n - 1) + GetFibonacciSequenceByN(n - 2);
        }
    }
}
