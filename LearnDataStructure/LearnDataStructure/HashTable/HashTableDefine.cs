using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

//https://www.geeksforgeeks.org/c-program-hashing-chaining/
//https://www.geeksforgeeks.org/implementing-our-own-hash-table-with-separate-chaining-in-java/
//https://blog.csdn.net/u010133610/article/details/64907343 C# list 与arraylist ,为了可以扩容,并且指定元素数量,这里就使用了List

namespace LearnDataStructure.HashTable
{
    /// <summary>
    /// 测试两个地方,第一个是初始化添加,再一个是减去的时候,赋值
    /// 扩容思路:先开辟一个新的2倍空间,然后把之前的再通过hash函数转变,然后放进去
    /// 注意数组初始化时,需要开辟空间
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
   public class HashTableDefine<K,V>
    {
        //存储链的数组
        private List<HashNode<K,V>> bucketArray;
        //当前数组的大小
        private int numberBuckets;
        //当前数组中元素的个数
        private int size;

        //构造函数,初始化容量大小,个数
        public HashTableDefine()
        {
            bucketArray=new List<HashNode<K, V>>();
            numberBuckets = 10;
            size = 0;
            //创建空链,这里为啥添加,后面测试
            //理解了,空也算占了一个位置,就是把空间全部开辟,用null也行
            for (int i = 0; i < numberBuckets; i++)
            {
                bucketArray.Add(null);
            }
        }

        public int Size()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return Size() == 0;
        }
        /// <summary>
        /// 实现hash函数
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int GetBucketIndex(K key)
        {
            //使用微软为我们提供的hash函数
            int hashCode = Math.Abs(key.GetHashCode()) ;
            int index = hashCode % numberBuckets;
            return index;
        }

        /// <summary>
        /// 移除一个给定键的方法
        /// 1.考虑对原数组的检查
        /// 2.考虑找不到的情况
        /// 3.最后一定要重新赋值,这和之前的链表本身就包含头节点是不一样的.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public V Remove(K key)
        {
            int bucketIndex = GetBucketIndex(key);
            //单链表中,当前节点找到了,但是上一个也需要保存,所以这里有了q节点
            HashNode<K, V> head = bucketArray[bucketIndex];
            HashNode<K, V> q = null;
            V resultKey = default(V);

            while (head!=null&&!head.Key.Equals(key))
            {
                q = head;
                head = head.next;
            }

            if (head==null)
            {
               throw  new Exception("此处值为空,或者没有找到这个删除的值");
            }

          
            //如果第一个就找到了
            if (q==null)
            {
                //不能直接这样写,因为这不是在链表里面直接操作
                //resultKey = head.Value;
                //head = head.next;
                //return resultKey;
                //要这样写
                resultKey = head.Val;
                bucketArray[bucketIndex] = head.next;
                size--;
                return resultKey;

            }
            else
            {
                resultKey = q.Val;
                q.next = head.next;
                size--;
                return resultKey;
            }
            

        }

        /// <summary>
        /// 查找值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public V Get(K key)
        {
            int bucketIndex = GetBucketIndex(key);
            HashNode<K, V> head = bucketArray[bucketIndex];
            while (head!=null&&!head.Key.Equals(key) )
            {
                head = head.next;
            }

            if (head==null)
            {
                throw new Exception("哈希表中不存在这个值");
            }

            return head.Val;

        }

        /// <summary>
        /// 增加值时,要检测键是否存在了
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(K key, V value)
        {

            int bucketIndex = GetBucketIndex(key);
            HashNode<K, V> addNode = new HashNode<K, V>(key, value);
            HashNode<K, V> head = bucketArray[bucketIndex];

            while (head!=null)
            {
                if (head.Key.Equals(key))
                {
                    head.Val= value;

                    return;
                }
                head = head.next;
            }
            //这里不需要再赋予了吧,测试
            size++;
            head = bucketArray[bucketIndex];
            addNode.next = head;       
            bucketArray[bucketIndex] = addNode;
            //还要考虑扩容情况
            if ((1.0*size)/ numberBuckets>=0.7)
            {
                numberBuckets = 2 * numberBuckets;
                List<HashNode<K, V>>  temp = bucketArray;
                bucketArray = new List<HashNode<K, V>>();
                size = 0;
                for (int i = 0; i < numberBuckets; i++)
                {
                    bucketArray.Add(null);
                }

                //这里调自有方法,重新添加一遍
                foreach (HashNode<K, V> node in temp)
                {
                    while (node!=null)
                    {
                       Add(node.Key,node.Val);
                       head = head.next;
                    }
                }

            }
        }

    }

    class HashNode<K, V>
    {
        private K key;

        public K Key
        {
            get { return key; }
            set { key = value; }
        }

        private V val;

        public V Val
        {
            get { return val; }
            set { val = value; }
        }
    
        //指向下一个节点
        public HashNode<K, V> next;
        //构造器
        public HashNode(K key, V value)
        {
            this.key = key;
            this.val = value;
        }

    }
}
