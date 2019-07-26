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
   public static class StackTest
    {
        /// <summary>
        /// 数组组成的栈测试
        /// </summary>
        [Fact]
        public static void DoTest()
        {
            StackUsingArray<int> array =new StackUsingArray<int>(5);
            array.Push(1);
            array.Push(2);
            array.Push(3);
            array.Push(4);
            array.Push(5);
            array.Pop();
            int a = array.Peek();
        }

        /// <summary>
        /// 链表组成的栈测试
        /// </summary>
        [Fact]
        public static void DoTest2()
        {
            StackUsingLink<int> array = new StackUsingLink<int>();
            array.Push(1);
            array.Push(2);
            array.Push(3);
            array.Push(4);
            array.Push(5);
            array.Pop();
            int a = array.Peek();
        }

        /// <summary>
        /// 数组组成的队列测试
        /// </summary>
        [Fact]
        public static void DoTest3()
        {
            QueueUsingArray<int> array = new QueueUsingArray<int>(5);
            array.Push(1);
            array.Push(2);
            array.Push(3);
            array.Push(4);
            array.Push(5);
            array.Pop();
            int a = array.Peek();
        }

        /// <summary>
        /// 链表组成的队列测试
        /// </summary>
        [Fact]
        public static void DoTest4()
        {
            QueueUsingLink<int> array = new QueueUsingLink<int>();
            array.Push(1);
            array.Push(2);
            array.Push(3);
            array.Push(4);
            array.Push(5);
            array.Pop();
            int a = array.Peek();
        }


    }
}
