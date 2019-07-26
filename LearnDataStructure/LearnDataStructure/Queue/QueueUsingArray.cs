using System;
using System.Collections.Generic;
using System.Text;

namespace LearnDataStructure.Lists
{
    interface IQueueUsingArray<T>
    {
        void Push(T item);
        T Pop();
        T Peek();
        bool IsEmpty();
        int GetSize();
    }
  public class QueueUsingArray<T> : IQueueUsingArray<T>
    {
        private int size;
        private int topIndex = -1;
        private T[] stack;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="size"></param>
        public QueueUsingArray(int size)
        {
            this.size = size;
            stack = new T[size];
        }
        

        /// <summary>
        /// 得到栈中元素个数
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            return topIndex + 1;
        }

        public bool IsEmpty()
        {
            return topIndex==-1;
        }

        /// <summary>
        /// 向数组中放入元素,o(1)
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            if (topIndex==size-1)
            {
                throw new NotSupportedException("数组已满");
            }

            topIndex++;
            stack[topIndex] = item;
           
        }

        /// <summary>
        /// 出栈o(n),要移动后面的
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (topIndex==-1)
            {
                throw new NotSupportedException("数组为空,无法出栈");
            }
            T value = stack[0];
            if (topIndex==0)
            {
                topIndex--;
                return value;
            }

            for (int i = 0; i < topIndex; i++)
            {
                stack[i] = stack[i + 1];
            }
            topIndex--;

            return value;
        }

        /// <summary>
        /// 取得最上面的元素o(1)
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (topIndex == -1)
            {
                throw new NotSupportedException("数组为空,无法出栈");
            }
            T value = stack[0];
            return value;
        }
    }
}

//用数组做队列不太方便因为在移出数据时,是o(n)操作,而数组做的栈则是o(1)操作.
//为了解决这个问题,于是就有了循环队列

