using System;
using System.Collections.Generic;
using System.Text;

namespace LearnDataStructure.Recursion
{
    public class Factorial
    {
        public int GetFactorialByN(int n)
        {
            if (n == 0) return 1;
            if (n == 1) return 1;
            return n * GetFactorialByN(n - 1);

        }
    }

  
}
