using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;

//https://www.cnblogs.com/ylsforever/p/6510528.html
//https://www.cnblogs.com/fanyong/archive/2013/03/31/2992522.html
namespace LearnDataStructure.Lists
{
    //public class LRUDoubleList<T> :IEnumerable<T> where T : IComparable<T>
    /// <summary>
    /// 定义接口，真的很方便哦，这样就统一了。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILRUDoubleListOperate<T>
    {
        void AddToHead(Node<T> node);
        void DeleteNode(Node<T> node);
        void Look(T key);
    }

    /// <summary>
    /// 双向链表类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LRUDoubleList<T> : ILRUDoubleListOperate<T>
    {
        private Dictionary<T, Node<T>> Cache;
        private int Capacity;
        private Node<T> head;
        private Node<T> tail;

        public LRUDoubleList(int capacity)
        {
            this.Capacity = capacity;
            Cache=new Dictionary<T, Node<T>>();
        }



        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="node"></param>
        public void AddToHead(Node<T> node)
        {
            if (Cache.Count==0)
            {
                head = node;
                tail = node;
            }
            //将节点插入到头部
            else
            {
                node.Next = head;
                head.Prev = node;
                head = node;
            }
        }


        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="node"></param>
        public void DeleteNode(Node<T> node)
        {
            if (node==head)
            {
                head = node.Next;

            }
            if (node == tail)
            {
                tail = node.Prev;
            }

            //对开始的边界检查
            if (node.Prev!=null)
            {
                node.Prev.Next = node.Next; 
            }
            //对尾部的边界检查
            if (node.Next!=null)
            {
                node.Next.Prev = node.Prev;
            }
        }

        public void Look(T key)
        {
            if (Cache.ContainsKey(key))
            {
                Node<T> keyNode = Cache[key];
                //在节点和cache中都删除
                DeleteNode(keyNode);
                Cache.Remove(key);

            }
            else
            {
                if (Cache.Count==Capacity)
                {
                    //cache满了,删除最后的,然后进入新的
                    T tailKey =tail.Data;
                    DeleteNode(tail);
                    Cache.Remove(tailKey);
                }
            }
            Node<T> newNode = new Node<T>(key,null,null);
            AddToHead(newNode);
            Cache.Add(key,newNode);

        }
    }

}



//其实LRU也是一种列表,用新的列表结构表示
//原理,添加字典,记录操作过程,查询方便
//节点的删除添加和字典同步
//没有重复的
//删除其实也很快,通过和字典中的key作对比,可以直接找到节点