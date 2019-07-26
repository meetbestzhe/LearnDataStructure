using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;


//单链表反转  https://algorithms.tutorialhorizon.com/reverse-a-linked-list/
//合并两个列表: https://algorithms.tutorialhorizon.com/merge-or-combine-two-sorted-linked-lists/
namespace LearnDataStructure.Lists
{
    //public class SingleList<T> :IEnumerable<T> where T : IComparable<T>
    public class SingleList<T> : IEnumerable<T> where T:IComparable<T>
    {
        public Node<T> head = null;

        /// <summary>
        /// 根据值查找节点,0(n)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Node<T> FindByValue(T value)
        {
            Node<T> p = head;
            while (p!=null &&!p.getData().Equals(value))
            {
                p = p.Next;
            }
            return p;
        }
        
        /// <summary>
        /// 通过指针查找对应节点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Node<T> FindByIndex(int index)
        {
            Node<T> p = head;
            int pos = 0;
            while (p != null && pos != index)
            {
                p = p.Next;
                ++pos;
            }
            return p;
        }
        /// <summary>
        /// 将值插入到列表头部
        /// </summary>
        /// <param name="value"></param>
        public void InsertToHead(T value)
        {
            Node<T> newNode = new Node<T>(value, null);
            InsertToHead(newNode);
        }
        /// <summary>
        /// 将节点插入到列表头部 (1)
        /// </summary>
        /// <param name="newNode"></param>
        public void InsertToHead(Node<T> newNode)
        {
            //最开始构造列表的时候,就可能头部为空
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }
       
        }

        /// <summary>
        /// 顺序插入,链表尾部插入 考虑头不存在的情况(1)
        /// </summary>
        /// <param name="value"></param>
        public void InsertTail(T value)
        {
            Node<T> newNode = new Node<T>(value,null);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node<T> q = head;
                //找到最后一个节点
                while (q.Next != null)
                {
                    q = q.Next;
                }
                //最后一个本来就为空,没必要写
                //bnewNode.Next = q.Next;
                q.Next = newNode;
            }
        }

        /// <summary>
        /// 在某个节点后面插入值
        /// </summary>
        /// <param name="p"></param>
        /// <param name="value"></param>
        public void InsertAfter(Node<T> p, T value)
        {
            Node<T> newNode=new Node<T>(value,null);
            InsertAfter(p,newNode);
        }

        /// <summary>
        /// 在某个节点后面插入这个值的节点,需要对空节点检测
        /// </summary>
        /// <param name="p"></param>
        /// <param name="newNode"></param>
        public void InsertAfter(Node<T> p, Node<T> newNode)
        {
            if (p == null) return;
            newNode.Next = p.Next;
            p.Next = newNode;
        }

        /// <summary>
        /// 在某个节点前面插入值
        /// </summary>
        /// <param name="p"></param>
        /// <param name="value"></param>
        public void InsertBefore(Node<T> p, T value)
        {
            Node<T> newNode = new Node<T>(value, null);
            InsertBefore(p, newNode);
        }
        


        /// <summary>
        /// 在某个节点前面插入这个值的节点,需要对空节点检测
        /// </summary>
        /// <param name="p"></param>
        /// <param name="newNode"></param>
        public void InsertBefore(Node<T> p, Node<T> newNode)
        {
            if(p==null ||newNode==null) return;
            if (head == p)
            {
                // newNode.Next = head;
                //head = newNode;
                InsertToHead(newNode);
                return;
            }

            Node<T> q = head;
            //这个有两种情况,要么找到了节点,要么没有找到
            while (q.Next != null && q.Next!=p)
            {
                q = q.Next;
            }
            //也有可能找不到这个节点
            if (q == null)
            {
                return;
            }
            q.Next = newNode;
            newNode.Next = p;
        }

        /// <summary>
        /// 通过指定节点删除
        /// </summary>
        /// <param name="newNode"></param>
        public void DeleteByNode(Node<T> newNode)
        {
            //如果为空
            if (head == null ||newNode==null)
            {
                return;
            }
            //如果是头节点
            if (head==newNode)
            {
                head = head.Next;
            }
            //如果是中间,或者尾巴的节点
            Node<T> q = head;
            while (q.Next != null&&q.Next!=newNode)
            {
                q = q.Next;
            }
        }

        public void DeleteByValue(T value)
        {
            if(head==null) return;
            Node<T> p = head;
            //记录p的实际值,用q
            Node<T> q = null;
            while (p!=null&&!p.getData().Equals(value))
            {
                q = p;
                p = p.Next;
               
            }
            //没有找到,剩下的就只能是找到了这个值
            if(p==null) return;
            
            //第一个值就找到了
            if (q==null)
            {
                head = head.Next;
            }
            else
            {
                q.Next = q.Next.Next;
            }


        }

        public void DeleteAllByValue(T value)
        {
            //头节点,这里需要修改一下

            while (head!=null &&head.getData().Equals(value))
            {
                head = head.Next;
            }

            Node<T> pNode = head;
            while (pNode.Next!= null) 
            {
               
                if (pNode.Next.getData().Equals(value))
                {
                    
                    pNode.Next = pNode.Next.Next;
                    continue;
                }
                pNode = pNode.Next;
            }
        }

        /// <summary>
        /// 反转链表 o(n)
        /// </summary>
        public void ReverseListByTwoNode()
        {
            if (head == null )
            {
                throw new NotSupportedException("没有头节点,何来翻转");
            }

            if (head.Next==null)
            {
                return;
            }

            //使用三个节点来进行逆序

            Node<T> curNode = head;

            Node<T> preNode = null;
            Node<T> nextNode = null;
            while (curNode != null)
            {
                //先得到下一个节点
                nextNode = curNode.Next;
                //完成转序
                curNode.Next = preNode;

                //上一个节点就变成了当前节点
                preNode = curNode;
                //当前节点就变成了下一个节点
                curNode = nextNode;
            }
            //最后将头节点展现出来
            head = preNode;

        }


        /// <summary>
        /// 非递归合并两个有序链表 o(n)
        /// </summary>
        /// <returns></returns>
       static public SingleList<T> MergeWithOutRecur(SingleList<T> firstLink, SingleList<T>secondLink)
        {
            SingleList<T> a = firstLink;
            SingleList<T> b = secondLink;
            SingleList<T> resultist=new SingleList<T>();
            while (a.head != null && b.head != null)
            {
                if (a.head.getData().CompareTo(b.head.getData())<0)
                {
                    resultist.InsertTail(a.head.getData() );
                    a.head = a.head.Next;
                }
                else
                {
                    resultist.InsertTail(b.head.getData());
                    b.head = b.head.Next;
                }
            }
            //经过上面的操作之后,至少有一个没有走完
            while (a.head!=null)
            {
                resultist.InsertTail(a.head.getData());
                a.head = a.head.Next;
            }
            while (b.head != null)
            {
                resultist.InsertTail(b.head.getData());
                b.head = b.head.Next;
            }

            return resultist;
        }

        /// <summary>
        /// 取得中间节点  o(n)
        /// </summary>
        /// <returns></returns>
        public Node<T> getMiddleNode()
        {
            if (head==null)
            {
                return null;
            }
            Node<T> slowNode = head;
            Node<T> fastNode = head;
            //全部用快节点判断
            while (fastNode.Next!=null&&fastNode.Next.Next!=null)
            {
                slowNode = slowNode.Next;
                fastNode = fastNode.Next.Next;
            }

            return slowNode;
        }






        /// <summary>
        /// 节点类
        /// </summary>
        public class Node<T>
       {
           //数据域
           private T data;  
            //引用域
           public Node<T> Next { get; set; }
           /// <summary>
           /// 构造器
           /// </summary>
           /// <param name="data"></param>
           /// <param name="next"></param>
           public Node(T data, Node<T> next)
           {
               this.data = data;
               this.Next = next;
           }

           /// <summary>
           /// 得到节点中的数据
           /// </summary>
           /// <returns></returns>
           public T getData()
           {
               return data;
           }
       }


        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

      
    }
}

//总共有三个位置要检查,结构中本身是否存在被插入的节点,插入的节点是否为空,是否为头部或者尾部插入
//头部就不用遍历了,0(1).
//头结点要能够获取,或者判断列表是否为空
//值也要能获取
