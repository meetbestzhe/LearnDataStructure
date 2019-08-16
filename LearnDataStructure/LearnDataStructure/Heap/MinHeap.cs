using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
namespace LearnDataStructure.Heap
{
    /// <summary>
    /// //https://www.geeksforgeeks.org/min-heap-in-java/
    /// A min Heap is a Complete Binary Tree
    /// The root element will be at Arr[0].For any ith node,i.e,Arr[i];
    /// Arr[(i-1)/2]returns its parent node.
    /// Arr([2*i)+1]returns its left child node
    /// Arr[(2*i)+2]returns its right child node.
    /// In below implementtation,we do indexing from index 1 to simplify the implemnetation
    /// 插入数据时，向上堆化，删除数据时，交换顶元素之后，向下堆化
    /// </summary>
    public class MinHeap
    {
        private int[] heap;
        private int size;
        private int maxsize;
        private const int FRONT = 1;

        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        public int[] Heap
        {
            get { return heap; }
        }
        public MinHeap(int maxsize)
        {
            this.maxsize = maxsize;
            this.size = 0;
            heap = new int[this.maxsize+1];
            //minValue:-2,147,483,648.
            heap[0]=Int32.MinValue;
        }

        //Returns position of parent
        private int Parent(int pos)
        {
            return pos / 2;
        }

        //Below two functions return left and right children.
        private int LeftChild(int pos)
        {
            return 2 * pos ;
        }

        private int rightChild(int pos)
        {
            return (2 * pos) + 1;
        }
        //Returns true of given node is leaf
        private Boolean IsLeaf(int pos)
        {
            //最后一层如果填满个
            if (pos>=(size/2)&& pos<=size)
            {
                return true;
            }
            return false; 
        }

        private void Swap(int fpos, int spos)
        {
            int tmp;
            tmp = heap[fpos];
            heap[fpos] = heap[spos];
            heap[spos] = tmp;
        }


        /// <summary>
        /// 插入值如果小于父亲节点，那就向上堆化
        /// </summary>
        /// <param name="element"></param>
        public void Insert(int element)
        {
            if (size>=maxsize)
            {
                return;
            }
            heap[++size] = element;
            int current = size;
            while (heap[current]<heap[Parent(current)])
            {
                Swap(current,Parent(current));
                current = Parent(current);
            }
        }

        /// <summary>
        /// Function to heapify the node at pos,从pos处向下堆化
        /// </summary>
        /// <param name="pos"></param>
        private void MinHeapify(int pos)
        {
            //If the node is a non-leaf node and greater than any of its child
            //Only in this situation ,we should Heapify
            if (!IsLeaf(pos))
            {
               
                if (heap[pos] > heap[LeftChild(pos)] || heap[pos] > heap[rightChild(pos)])
                {
                    //Swap with the left child and heapify the left child
                    if (heap[LeftChild(pos)] < heap[rightChild(pos)])
                    {
                        Swap(pos, LeftChild(pos));
                        MinHeapify(LeftChild(pos));
                    }
                    //Swap with the right child and heapify the right child
                    else
                    {
                        Swap(pos, rightChild(pos));
                        MinHeapify(rightChild(pos));
                    }
                }
            }

        }

        //Function to build the min heap using the minHeapify,从下到上的堆化
        public void GetMinHeap()
        {
            for (int pos = (size/2); pos >=1; pos--)
            {
                MinHeapify(pos);
            }
        }

        //Function to remove minValue,after remove minValue should take heap[size] to heap[Front] then MinHeapify
        public int Remove()
        {
            if (size==0)
            {
                return -1;
            }

            if (size==1)
            {
                size--;
                return heap[FRONT];
            }
            int popped = heap[FRONT];
            heap[FRONT] = heap[size];
            size--;
            MinHeapify(FRONT);
            return popped;
        }
    }
}
