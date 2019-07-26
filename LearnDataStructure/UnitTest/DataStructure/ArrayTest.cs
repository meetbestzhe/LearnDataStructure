using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using LearnDataStructure.Lists;
using Xunit;
using Xunit.Abstractions;
using Array = LearnDataStructure.Lists.Array;


namespace UnitTest.DataStructure
{
   public static class ArrayTest
    {
        [Fact]
        public static void DoTest()
        {
            Array array=new Array(5);
            array.PrintAll();
            array.Insert(0, 3);
            array.Insert(0, 4);
            array.Insert(1, 5);
            array.Insert(3, 9);
            array.Insert(3, 10);
            array.PrintAll();
        }

        [Fact]
        public static void DoTest2()
        {
            ArrayResize<int> array = new ArrayResize<int>(5);
          
            array.Insert(0, 3);
            array.Insert(0, 4);
            array.Insert(1, 5);
            array.Insert(3, 9);
            array.Insert(3, 10);
            array.Insert(3, 10);
            array.Insert(3, 10);
            //for (int i = 0; i < array.Count(); i++)
            //{
               
            //    Console.WriteLine(array.get(i));
            //}
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }

        [Fact]
        public static void DoTest3()
        {
            ArrayCombine<int> array1 = new ArrayCombine<int>(5);
            array1.Insert(0, 3);
            array1.Insert(0, 4);
            array1.Insert(1, 5);
            ArrayCombine<int> array2 = new ArrayCombine<int>(5);
            array1.Insert(0, 3);
            array1.Insert(0, 4);
            array1.Insert(1, 5);

            array1.Combine(array2);

            //for (int i = 0; i < array.Count(); i++)
            //{

            //    Console.WriteLine(array.get(i));
            //}
            foreach (var item in array1)
            {
                Console.WriteLine(item);
            }
        }
       
        ///单链表能否正常工作测试
        [Fact]
        public static void DoTest4()
        {

            SingleList<int> link = new SingleList<int>();
            int[] data = { 1, 1,2, 5, 3, 1 };
            for (int i = 0; i < data.Length; i++)
            {
                //link.insertToHead(data[i]);
                link.InsertTail(data[i]);
            }

            SingleList<int>.Node<int> InsertNode = link.FindByValue(5);

            link.InsertBefore(InsertNode,15);
            link.DeleteAllByValue(1);
            link.ReverseListByTwoNode();
            int a = 1;
            Console.WriteLine(link.FindByIndex(0).getData());  
        }

        [Fact]
        public static void DoTest5()
        {
            DoubleList<int> link = new DoubleList<int>();
            int[] data = { 1, 2, 3,4, 5, 6 };
            for (int i = 0; i < data.Length; i++)
            {
                //link.insertToHead(data[i]);
                link.AddLast(data[i]);
            }
            link.AddBefore(1,15);
            int a = 0;
            Console.WriteLine(link[1]);
        }

        [Fact]
        public static void DoTest6()
        {
            DoubleCircleList<int> link = new DoubleCircleList<int>();
            int[] data = { 1, 2, 3, 4, 5, 6 };
            for (int i = 0; i < data.Length; i++)
            {
                //link.insertToHead(data[i]);
                link.AddLast(data[i]);
            }
            link.AddBefore(1, 15);
            int a = 0;
            Console.WriteLine(link[1]);
        }



        ///单链表能否合并成一个排序列表
        [Fact]
        public static void DoTest7()
        {

            SingleList<int> linkFirst = new SingleList<int>();
            SingleList<int> linkSecond = new SingleList<int>();
            SingleList<int> resultList = new SingleList<int>();
            int[] dataFirst = { 1, 3, 5, 7, 9};
            int[] dataSecond = { 2, 4,4, 8, 10 };
            for (int i = 0; i < dataFirst.Length; i++)
            {
                //link.insertToHead(data[i]);
                linkFirst.InsertTail(dataFirst[i]);
            }
            for (int i = 0; i < dataSecond.Length; i++)
            {
                //link.insertToHead(data[i]);
                linkSecond.InsertTail(dataSecond[i]);
            }

            resultList = SingleList<int>.MergeWithOutRecur(linkFirst,linkSecond);


          
        }

        ///单链表取中间值测试
        [Fact]
        public static void DoTest8()
        {

            SingleList<int> linkFirst = new SingleList<int>();
         
            int[] dataFirst = { 1, 3, 5, 7, 9 };
          
            for (int i = 0; i < dataFirst.Length; i++)
            {
                //link.insertToHead(data[i]);
                linkFirst.InsertTail(dataFirst[i]);
            }

            SingleList<int>.Node<int> a = linkFirst.getMiddleNode();
            Assert.Equal(5, a.getData());
            int b = a.getData();


        }
    }
}
