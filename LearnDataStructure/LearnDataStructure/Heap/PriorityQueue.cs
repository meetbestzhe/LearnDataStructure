using System;
using System.Collections.Generic;
using System.Text;
//https://www.sanfoundry.com/java-program-priority-queue/
namespace LearnDataStructure.Heap
{

   public class Task
    {
        public string job { get; set; }
        public int priority { get; set; }
        

        public Task(string job, int priority)
        {
            this.job = job;
            this.priority = priority;
        }
        //tostring
        public override string ToString()
        {
            return $"Job Name: {job} ,Priority:{priority}";
        }
    }
        

    public class PriorityQueue
    {
        private Task[] heap;
        private int size;
        private int maxsize;
        private const int FRONT = 1;
        //constructor
        public PriorityQueue(int maxsize)
        {
            this.maxsize = maxsize;
            heap= new Task[this.maxsize+1];
            heap[0]=new Task("",Int32.MaxValue);
            size = 0;
        }

        //Returns position of parent
        private int Parent(int pos)
        {
            return pos / 2;
        }
        //Below two functions return left and right children.
        private int LeftChild(int pos)
        {
            return 2 * pos;
        }
        private int rightChild(int pos)
        {
            return (2 * pos) + 1;
        }

        //Returns true of given node is leaf
        private Boolean IsLeaf(int pos)
        {
            //最后一层如果填满个
            if (pos >= (size / 2) && pos <= size)
            {
                return true;
            }
            return false;
        }


        private void Swap(int fpos, int spos)
        {
            Task tmp;
            tmp = heap[fpos];
            heap[fpos] = heap[spos];
            heap[spos] = tmp;
        }
        /// <summary>
        /// 插入值如果大于父亲节点，那就向上堆化
        /// </summary>
        /// <param name="element"></param>
        public void Insert(Task element)
        {
            if (size >= maxsize)
            {
                return;
            }
            heap[++size] = element;
            int current = size;
            while (heap[current].priority > heap[Parent(current)].priority)
            {
                Swap(current, Parent(current));
                current = Parent(current);
            }
        }


        /// <summary>
        /// Function to heapify the node at pos,从pos处向下堆化
        /// </summary>
        /// <param name="pos"></param>
        private void MaxHeapify(int pos)
        {
            //If the node is a non-leaf node and less than any of its child
            //Only in this situation ,we should Heapify
            if (!IsLeaf(pos))
            {

                if (heap[pos].priority < heap[LeftChild(pos)].priority || heap[pos].priority < heap[rightChild(pos)].priority)
                {
                    //Swap with the left child and heapify the left child
                    if (heap[LeftChild(pos)].priority > heap[rightChild(pos)].priority)
                    {
                        Swap(pos, LeftChild(pos));
                        MaxHeapify(LeftChild(pos));
                    }
                    //Swap with the right child and heapify the right child
                    else
                    {
                        Swap(pos, rightChild(pos));
                        MaxHeapify(rightChild(pos));
                    }
                }
            }

        }

        //Function to remove minValue,after remove minValue should take heap[size] to heap[Front] then MinHeapify
        public Task Remove()
        {
            if (size == 0)
            {
                return null;
            }

            if (size == 1)
            {
                size--;
                return heap[FRONT];
            }
            Task popped = heap[FRONT];
            heap[FRONT] = heap[size];
            size--;
            MaxHeapify(FRONT);
            return popped;
        }

        ////function to clear
        //public void Clear()
        //{
        //    heap=new Task[maxsize];
        //    size = 0;
        //}

        ////function to check if empty
        //public Boolean IsEmpty()
        //{
        //    return size == 0;
        //}

        ////function to check is full
        //public Boolean IsFull()
        //{
        //    //no value in heap[0]
        //    return size == maxsize-1;
        //}

        ////function to get size
        //public int Size()
        //{
        //    return size;
        //}

        ////Function to insert
        //public void Insert(string job, int priority)
        //{
        //    Task newJob=new Task(job,priority);
        //    int pos = size;
        //    heap[++size] = newJob ;

        //    //如果新工作的优先级大于他爹的,那么就找到该工作合适的pos位置,向上找
        //    while (pos != 1 && newJob.priority > heap[pos / 2].priority)
        //    {
        //        heap[pos] = heap[pos / 2];
        //        pos /= 2;
        //    }
        //    //最后将pos的位置等于新工作
        //    heap[pos] = newJob;
        //}


        ////Function to remove task
        //public Task Remove()
        //{
        //    int parent=1;
        //    int child=2;
        //    Task item;
        //    Task temp;
        //    if (IsEmpty())
        //    {
        //        return null;
        //    }

        //    item = heap[1];
        //    temp = heap[size--];

        //    //调整heap
        //    while (child<=size)
        //    {
        //        if (child<size&&heap[child].priority<heap[child+1].priority)
        //        {
        //            child++;
        //        }

        //        if (temp.priority>=heap[child].priority)
        //        {
        //            break;
        //        }

        //        heap[parent] = heap[child];
        //        parent = child;
        //        child *= 2;
        //    }


        //    heap[parent] = temp;
        //    return item;
        //}



    }



}
