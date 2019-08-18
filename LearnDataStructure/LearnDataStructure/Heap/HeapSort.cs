using System;
using System.Collections.Generic;
using System.Text;

namespace LearnDataStructure.Heap
{
    /// <summary>
    /// 理解：因为是给数组排序，数组都是写好的了，这里从数组后面往前走，堆化，从上往下.
    /// 因为叶子节点往下堆化，只能自己跟自己比较，所以我们直接从第一个非叶子节点开始，依次堆化就行了
    /// 插入算法时，数组从前面往后面，堆化从下往上走
    /// 第一步，是将其最大堆化
    /// </summary>
    public class HeapSort
    {
        public void sort(int[] arr)
        {
            int n = arr.Length;
            //Build heap(rearrange array)，不需要考虑叶子节点，从后往前走
            for (int i =n/2-1; i >=0; i--)
            {
                heapify(arr, n, i);
            }

            //One by one extract an element from heap
            for (int i = n-1; i >=0; i--)
            {
                //Move current root to end
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                //call max heapify on the reduced heap
                heapify(arr, i, 0);
            }

            //To heapify a subtree rooted with node i which
            //is an index in arr[].n is size of heap
           
        }
        void heapify(int[] arr, int n, int i)
        {
            int largest = i; //Initialize largest as root
            int l = 2 * i + 1; //left=2*i+1;
            int r = 2 * i + 2;//right =2*i+2;
            //if left child is larger than root
            if (l<n&&arr[l]>arr[largest])
            {
                largest = l;
            }
            //if right child is larger than largest so far
            if (r < n && arr[r] > arr[largest])
            {
                largest = r;

            }
            //if largest is not root
            if (largest!=i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;
                //交换以后，可能会引起不平衡性
                //Recursivel heapify the affect sub-tree
                heapify(arr, n, largest);
            }
        }
    }
}
