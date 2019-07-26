using System;
using System.Collections.Generic;
using System.Text;
using LearnDataStructure.Recursion;
using Xunit;
using Xunit.Abstractions;
namespace UnitTest.DataStructure
{
  
    public static class RecursionTest
    {
        [Fact]
        public static void DoTest()
        {
            FibonacciSequence fibonacci=new FibonacciSequence();

            int a = fibonacci.GetFibonacciSequenceByN(1000);


        }
        [Fact]
        public static void DoTest2()
        {
            Factorial fibonacci = new Factorial();

            int a = fibonacci.GetFactorialByN(5);

        }

        [Fact]
        public static void DoTest3()
        {
            List<int> test=new List<int>{1,2,3};
            PermutationsOfList<int> fibonacci = new PermutationsOfList<int>();

            IEnumerable<List<int>> a = fibonacci.Permutate<int>(test);

        }
     


    }


}
