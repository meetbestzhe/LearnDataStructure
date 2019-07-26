using System;
using System.Collections.Generic;
using System.Text;

namespace LearnDataStructure.Lists
{
    interface IStackUsingArray<T>
    {
        void Push(T item);
        T Pop();
        T Peek();
        bool IsEmpty();
        int GetSize();
    }
  public class StackUsingArray<T> : IStackUsingArray<T>
    {
        private int size;
        private int topIndex = -1;
        private T[] stack;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="size"></param>
        public StackUsingArray(int size)
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
        /// 出栈o(1)
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (topIndex==-1)
            {
                throw new NotSupportedException("数组为空,无法出栈");
            }

            topIndex--;
            return stack[topIndex+1];
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

            return stack[topIndex];
        }

    }


}

//基本元素,指针位置,size大小,数组的初始化
//关键在于有一个指针 从-1开始,
//然后基本三个方法,进栈,出栈