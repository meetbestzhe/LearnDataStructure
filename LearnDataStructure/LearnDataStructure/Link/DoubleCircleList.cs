using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

//https://www.cnblogs.com/ylsforever/p/6510528.html
//https://www.cnblogs.com/fanyong/archive/2013/03/31/2992522.html
namespace LearnDataStructure.Lists
{

    /// <summary>
    /// 双向链表类
    /// </summary>
    /// <typeparam name="T"></typeparam>
   public interface IDoubleCircleListOperate<T>
    {

    void AddAfter(int index, T value); //在某个节点之后添加节点
    void AddBefore(int index, T value);//在某个节点之前添加
   
    void AddLast(T value);
    void Clear();
    bool Contains(T value);
    Node<T> Find(T value);
    Node<T> FindLast(T value);
    void RemoveAt(int index); //移除指定位置节点
    void RemoveFirst();//移除开始位置的节点
    void RemoveLast();//移除最后一个位置的节点
    int Count();//获得链表中实际包含的node数
    Node<T> First();//获得链表中的第一个节点
    Node<T> Last();//获得链表中最后的一个节点
    }
public class DoubleCircleList<T> : IDoubleCircleListOperate<T>
    {
        private Node<T> _head;

        private int _size;
        public Node<T> Head { get; set; }



        /// <summary>
        /// 构造函数
        /// </summary>
        public DoubleCircleList()
        {
            Head = null;
            _size = 0;
        }

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get { return this.GetItemAt(index); }
        }

        /// <summary>
        /// 获取指定位置的元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetItemAt(int index)
        {
           
            //判断index位置的合理性
            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException("列表为空，或者查找范围超出索引范围");
            }
            //用p是因为不改变头指针的位置
            Node<T> p = new Node<T>(default(T), null, null);
            p = Head;

            //返回第一个节点
            if (index == 0)
            {
                return p.Data;
            }
            //右向查找
            if (index<_size/2)
            {
                //其实这句话,就保证了index为啥,最后的p就是他
                for (int i = 0; i < index; i++)
                {
                    p = p.Next;
                }
            }
            //_size-index.可以在后面验证下
            for (int i = 0; i < _size-index; i++)
            {
                p = p.Next;
            }
            return p.Data;

        }

        /// <summary>
        /// 判断双链表是否为空,用头结点是否存在判断的,并不是size哦.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _size == 0;
        }

        /// <summary>
        /// 在已存在节点后添加参数
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void AddAfter(int index, T value)
        {
           
            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException("链表为空，或者索引超出链表范围");
            }

            Node<T> p = Head;
            Node<T> inserNode = new Node<T>(value, null, null);
            for (int i = 0; i < index; i++)
            {
                p = p.Next;
            }

            //先保证插入的节点,再保证它前后的节点
            inserNode.Prev = p;
            inserNode.Next = p.Next;
            p.Next.Prev = inserNode;
            p.Next = inserNode;

            _size++;
        }

        public void AddBefore(int index, T value)
        {
            if (IsEmpty())
            {
                throw new NotSupportedException("由于链表为空,不能添加");
            }

            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException("索引超出链表范围");
            }


            Node<T> p = Head;
            Node<T> inserNode = new Node<T>(value, null, null);
            for (int i = 0; i < index; i++)
            {
                p = p.Next;
            }

            inserNode.Prev = p.Prev;
            inserNode.Next = p;
            p.Prev.Next = inserNode;
            p.Prev = inserNode;


            _size++;
        }


        /// <summary>
        /// 应该将这个方法扩展了作为值的插入
        /// 顺序插入值
        /// </summary>
        /// <param name="value"></param>
        public void AddLast(T value)
        {

            Node<T> insertNode = new Node<T>(value, null, null);
            if (_size == 0)
            {
                Head = insertNode;
                Head.Next = Head;
                Head.Prev = Head;
                return;
            }

            Node<T> p = Head;
            for (int i = 0; i < _size - 1; i++)
            {
                p = p.Next;
            }
            insertNode.Prev = p;
            insertNode.Next = Head;
            p.Next = insertNode;
            Head.Prev = insertNode;
            _size++;
        }

        /// <summary>
        /// 改变头就行
        /// </summary>
        public void Clear()
        {
            this.Head = null;
            _size = 0;
        }

        public int Count()
        {
            return _size;
        }

        /// <summary>
        /// 查找值为value的第一个节点
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Node<T> Find(T value)
        {
            if (!Contains(value))
                throw new NotSupportedException("值不存在");

            Node<T> p = Head;
            if (p.Data.Equals(value))
            {
                return p;
            }

            for (int i = 0; i < _size - 1; i++)
            {
                p = p.Next;
                if (p.Data.Equals(value))
                {
                    return p;
                }
            }

            return p;
        }

        /// <summary>
        /// 查找最后一个元素
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Node<T> FindLast(T value)
        {

            if (!Contains(value))
                throw new NotSupportedException("值不存在");

            Node<T> p = Head;
            Node<T> q = null;

            for (int i = 0; i < _size - 1; i++)
            {
                p = p.Next;
                if (p.Data.Equals(value))
                {
                    q = p;
                }
            }

            return q;
        }
        /// <summary>
        /// 返回第一个
        /// </summary>
        /// <returns></returns>
        public Node<T> First()
        {
            if (IsEmpty())
                throw new NotSupportedException("链表为空无法放回");
            return Head;
        }

        public Node<T> Last()
        {
            if (IsEmpty())
                throw new NotSupportedException("链表为空无法放回");
            Node<T> p = Head;
            if (_size == 0)
            {
                return p;
            }

            for (int i = 0; i < _size - 1; i++)
            {
                p = p.Next;

            }

            return p;
        }


        /// <summary>
        /// 删除指定位置元素,有细节
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (IsEmpty())
            {
                throw new NotSupportedException("由于链表为空,不能执行当前操作");
            }

            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException("索引超出链表范围");
            }


            //如果只有一个节点,当_size为1时,只有index=0,才能进来
            if (_size == 1 && index == 0)
            {
                Head = null;
                return;
            }

            if (_size != 1 && index == 0)
            {
                Head = Head.Next;
                Head.Prev = null;

            }

        }

        public void RemoveFirst()
        {
            RemoveAt(0);
        }

        public void RemoveLast()
        {
            RemoveAt(_size - 1);
        }

        public bool Contains(T value)
        {
            //判空
            if (IsEmpty())
            {
                Console.WriteLine("The double linked list is empty.");
                return false;
            }

            //判断头部是否包含
            Node<T> p = Head;
            if (p.Data.Equals(value))
            {
                return true;
            }

            for (int i = 0; i < _size - 1; i++)
            {
                p = p.Next;
                if (p.Data.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }
    }

  

}


//被插入的是否合理,插入的是否合理


//总共有三个位置要检查,结构中本身是否存在被插入的节点,插入的节点是否为空,是否为头部或者尾部插入
//头部就不用遍历了,0(1).
//到底是index,还是p节点来定位置


//一、检测
//1.插入的值是否有效
//2.被插入的是否存在
//3.插入的头部,尾部以及中间的区别

//二、节点的移动搞明白
//1.节点前
//2.节点后
//3.插入时，一共有四条线要改变，先保证插入的节点，然后再修改其左右的节点


//三、双向列表与双向循环列表差异
//1.双向循环列表对比双向列表，在指定位置查找上更为方便。
//2.操作时，一个获取元素的方向，再就是首位保证相连接(这部分操作在添加参数中实现)
//3.假设头其实应该是不会变的