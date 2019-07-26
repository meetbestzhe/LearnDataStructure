using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using LearnDataStructure.Sort;
namespace UnitTest.DataStructure
{
    public static class SortTest
    {
        [Fact]
        public static void DoTest()
        {
           int[] a=new int[]{4,3,5,6};
           BubbleSort<int> bubbleSort = new BubbleSort<int>();
           int[] b = bubbleSort.SortByBubbule(a);
           int c = 1;
        }

        [Fact]
        public static void DoTest2()
        {
            int[] a = new int[] { 4, 3,2 };
            InsertSort<int> bubbleSort = new InsertSort<int>();
            int[] b = bubbleSort.SortByInsert(a);

            int c = 1;
        }

        [Fact]
        public static void DoTest3()
        {
            int[] a = new int[] { 4, 3, 2,3 };
            ChooseSort<int> bubbleSort = new ChooseSort<int>();
            int[] b = bubbleSort.SortByChoose(a);

            int c = 1;
        }

        [Fact]
        public static void DoTest4()
        {
            int[] a = new int[] { 4, 3, 5,2 };
            MergeSort<int> bubbleSort = new MergeSort<int>();
            bubbleSort.MergeBySort(a,4);
 
            int c = 1;
        }

        [Fact]
        public static void DoTest5()
        {
            int[] a = new int[] { 1, 7, 2, 8,4 };
            QuickSort<int> bubbleSort = new QuickSort<int>();
            bubbleSort.SortByQuick(a, 5);
            int c = 1;
        }

        [Fact]
        public static void DoTest6()
        {
            int[] a = new int[] { 9, 4, 8,7,6,5,4,3,2,1};
            KbyQuickSort<int> bubbleSort = new KbyQuickSort<int>();
            int b= bubbleSort.SortByQuickTwo(a, a.Length, 4);
            int c = 0;
        }
    }
}

