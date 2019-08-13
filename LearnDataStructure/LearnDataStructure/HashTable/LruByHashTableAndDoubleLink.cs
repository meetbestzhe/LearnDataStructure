using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;

namespace LearnDataStructure.HashTable
{
    public class LruByHashTableAndDoubleLink<T> where  T:IComparable
    {
         public Node<T> head;
         private Node<T> tail;
         private Dictionary<T, Node<T>> dictionary;
         private int size;
         private int count;


         public LruByHashTableAndDoubleLink(int size)
         {
             this.head=null;
             this.tail = null;
             this.size = size;
             count = 0;
             dictionary = new Dictionary<T, Node<T>>();
         }
         
        /// <summary>
        /// 查找值
        /// </summary>
        /// <param name="val"></param>
         public void Look(T val)
         {
             if (dictionary.ContainsKey(val))
             {
                //移除
                Remove(val);
             }

             if (count==size)
             {
                 Node<T> temp = tail;
                 tail = tail.Prev;
                 Remove(temp.Val);
             }

            Node<T> addNode=new Node<T>(val,null,null);
            if (head == null)
            {
                head = addNode;
                tail = addNode;
            }
            else
            {
                addNode.Next = head;
                head.Prev = addNode;
                head = addNode;
            }
            //这里有点疑问,可以这样写吗
            dictionary.Add(val,addNode);
         }

        /// <summary>
        /// 删除值
        /// </summary>
        /// <param name="val"></param>
         private void Remove(T val)
         {
             Node<T> removeNode = dictionary[val];
             //考虑头部,尾部,中间删除
             //只有一个节点
             if (removeNode.Next==null&&removeNode.Prev==null)
             {
                 head = null;
                 tail = null;
                dictionary.Remove(val);
                return;
                
             }
             //尾巴节点
             if (removeNode.Next==null&&removeNode.Prev!=null)
             {
                 tail = removeNode.Prev;
                 tail.Next = null;
                 dictionary.Remove(val);
                 return;

            }
             //头节点
             if (removeNode.Next != null && removeNode.Prev == null)
             {
                 head = removeNode.Next;
                 removeNode.Next.Prev = head;
                 dictionary.Remove(val);
                 return;

            }
             //中间的节点
             removeNode.Prev.Next = removeNode.Next;
             removeNode.Next.Prev = removeNode.Prev;
             dictionary.Remove(val);
           
        }


    }

    public class Node<T>
    {
        public  T Val { get; set; }
        public Node<T> Prev { get; set; }
        public Node<T> Next { get; set; }
        public Node(T val,Node<T> prev,Node<T> next)
        {
            this.Val = val;
            this.Prev = prev;
            this.Next = prev;
        }
    }
}
