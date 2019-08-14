using System;
using System.Collections.Generic;
using System.Text;
using LearnDataStructure.Search;
using LearnDataStructure.Sort;
using Xunit;

namespace UnitTest.DataStructure
{
    public static class SearchTest
    {
        [Fact]
        public static void DoTest()
        {
            //数组不是重复的元素
            int[] a = new int[] {1, 2,3, 5, 6,7,9};
            BinarySearch<int> bubbleSort = new BinarySearch<int>();
            int b = bubbleSort.SearchByDichotomizing(a,a.Length,3);
            int c = 1;
        }
        [Fact]
        public static void DoTest1()
        {
            //数组是可能重复的元素,找到第一个等于
            int[] a = new int[] { 1, 3, 5, 6 };
            BinarySearch<int> bubbleSort = new BinarySearch<int>();
            int b = bubbleSort.SearchFirstEqualByDichotomizing(a, a.Length, 3);
            int c = 1;
        }
        [Fact]
        public static void DoTest2()
        {
            //数组是可能重复的元素,找到最后一个等于
            int[] a = new int[] { 1, 3,3, 5 };
            BinarySearch<int> bubbleSort = new BinarySearch<int>();
            int b = bubbleSort.SearchLastEqualByDichotomizing(a, a.Length, 3);
            int c = 1;
        }
        [Fact]
        public static void DoTest3()
        {
            //数组可能是重复的元素,找到第一个大于等于某个值的位置
            int[] a = new int[] { 3, 3, 5, 6 };
            BinarySearch<int> bubbleSort = new BinarySearch<int>();
            int b = bubbleSort.SearchFirstGreaterAndEqualByDichotomizing(a, a.Length, 3);
            int c = 1;
        }
        [Fact]
        public static void DoTest4()
        {
            //数组可能是重复的元素,找到最后一个小于等于某个值的位置
            int[] a = new int[] { 1, 3, 5, 6 };
            BinarySearch<int> bubbleSort = new BinarySearch<int>();
            int b = bubbleSort.SearchLastLessAndEqualByDichotomizing(a, a.Length, 5);
            int c = 1;
        }
    }
}
