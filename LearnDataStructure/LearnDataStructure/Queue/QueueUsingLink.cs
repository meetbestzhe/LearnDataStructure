using System;
using System.Collections.Generic;
using System.Text;

namespace LearnDataStructure.Lists
{
    interface IQueueUsingLink<T>
    {
        void Pop();
        void Push(T value);
        T Peek();
        int GetCount();
    }
    public class QueueUsingLink<T>: IQueueUsingLink<T>
    {
        private int size;
        private SingleNode<T> head;

        public QueueUsingLink()
        {
            int size = 0;
            head = null;
        }
        /// <summary>
        /// o(1)
        /// </summary>
        public void Pop()
        {
            if (head == null)
            {
                throw new NotSupportedException("链表为空,无法取出第一个元素");
            }
            head = head.Next;
        }

        /// <summary>
        /// 推入节点 o(1)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        public void Push(T value)
        {
            SingleNode<T> singleNode =new SingleNode<T>(value,null);
            if (head==null)
            {
                head = singleNode;
                size++;
                return;
            }

            SingleNode<T> node = head;
            while (node.Next!=null)
            {
                node = node.Next;
            }
            node.Next = singleNode;
            size++;
            return;
            
        }

        /// <summary>
        /// o(1)
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (head==null)
            {
                throw new NotSupportedException("链表为空,无法得到第一个元素");
            }

            return head.Data;
        }

        public int GetCount()
        {
            return size;
        }
    }
}






//基本元素,指针位置,size大小,数组的初始化
//关键在于有一个指针 从-1开始,
//然后基本三个方法,进栈,出栈