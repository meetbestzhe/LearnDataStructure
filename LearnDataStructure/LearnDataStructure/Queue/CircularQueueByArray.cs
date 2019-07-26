using System;
using System.Collections.Generic;
using System.Text;

namespace LearnDataStructure.Lists
{
    
    class CircularQueueByArray
    {
        //定义数组
        private string[] items;
        //数组大小
        private int n;
        //head表示队头下标,tail表示队尾下标
        private int head = 0;
        private int tail = 0;
        //申请一个大小为capacity的数组
        public CircularQueueByArray(int capacity)
        {
            items= new string[capacity];
            n = capacity;
        }
        //入队
        public bool enqueue(string item)
        {
            //队列满了
            if ((tail + 1) % n == head) return false;
            items[tail] = item;
            //之所以要除以n,是因为尾巴数量会超过?
            //当tail=n-1,首等于0时,如果是tail=tail+1 就会出错了.
            tail = (tail + 1) % n;
            return true;
        }
        //出队
        public string Dequeue()
        {
            //如果head==tail 表示队列为空
            if (head == tail) return null;
            string ret = items[head];
            head = (head + 1) % n;
            return ret;
        }

    }
}
