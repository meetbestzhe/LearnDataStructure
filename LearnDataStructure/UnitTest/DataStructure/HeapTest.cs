using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using LearnDataStructure.Heap;
using LearnDataStructure.Lists;
using Xunit;
using Xunit.Abstractions;
using LearnDataStructure.Trees;
using Xunit.Sdk;

namespace UnitTest.DataStructure
{
   public class HeapTest
    {
        //这就是单例模式啊，兄弟
        private readonly ITestOutputHelper output;

        public HeapTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        /// <summary>
        /// 最小堆测试
        /// </summary>
        [Fact]
        public  void DoTest1()
        {
            MinHeap minHeap = new MinHeap(15);
            minHeap.Insert(5);
            minHeap.Insert(3);
            minHeap.Insert(17);
            minHeap.Insert(10);
            minHeap.Insert(84);
            minHeap.Insert(19);
            minHeap.Insert(6);
            minHeap.Insert(22);
            minHeap.Insert(9);

            for (int i = 1; i <= minHeap.Size / 2; i++)
            {
                output.WriteLine($"Parent:{minHeap.Heap[i]} Left Child:{minHeap.Heap[2*i]} Right Child:{minHeap.Heap[2*i+1]}");
                output.WriteLine(" ");
            }
            output.WriteLine("-------------------------------");
            minHeap.GetMinHeap();

            minHeap.Remove();
            for (int i = 1; i <= minHeap.Size / 2; i++)
            {
                output.WriteLine($"Parent:{minHeap.Heap[i]} Left Child:{minHeap.Heap[2 * i]} Right Child:{minHeap.Heap[2 * i + 1]}");
                output.WriteLine(" ");
            }
        }


        /// <summary>
        /// 最大堆测试
        /// </summary>
        [Fact]
        public void DoTest2()
        {
            MaxHeap maxHeap = new MaxHeap(15);
            maxHeap.Insert(5);
            maxHeap.Insert(3);
            maxHeap.Insert(17);
            maxHeap.Insert(10);
            maxHeap.Insert(84);
            maxHeap.Insert(19);
            maxHeap.Insert(6);
            maxHeap.Insert(22);
            maxHeap.Insert(9);


            for (int i = 1; i <= maxHeap.Size / 2; i++)
            {
                output.WriteLine($"Parent:{maxHeap.Heap[i]} Left Child:{maxHeap.Heap[2 * i]} Right Child:{maxHeap.Heap[2 * i + 1]}");
                output.WriteLine(" ");
            }
            output.WriteLine("-------------------------------");
        
            maxHeap.Remove();
            for (int i = 1; i <= maxHeap.Size / 2; i++)
            {
                output.WriteLine($"Parent:{maxHeap.Heap[i]} Left Child:{maxHeap.Heap[2 * i]} Right Child:{maxHeap.Heap[2 * i + 1]}");
                output.WriteLine(" ");
            }
        }


    }
}
