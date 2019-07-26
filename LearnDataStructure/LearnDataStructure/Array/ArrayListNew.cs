using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;

namespace LearnDataStructure.Lists
{
    //基于数组的列表结构
    
    public class ArrayListNew<T>:IEnumerable<T>
    {
        /// <summary>
        ///定义变量
        /// </summary>
        //最大值
        private bool DefaultMaxCapacityIsX64 = true;
       // 是否达到数组最大值
        private bool IsmaximumCapacityReached = false;

        //C#数组最大长度
        public const int MAXIMUM_ARRAY_LENGTH_x64 = 0X7FEFFFFF;//x64
        public const  int MAXIMUM_ARRAY_LENGTH_x86 = 0x8000000; //x86

        //默认的空列表初始化
        private readonly T[] _emptyArray=new T[0];

        //默认容量,当最小值小于5的时候
        private const int _defaultCapacity = 8;

        //这个类内部的单元数组,不是一个属性
        private T[] _collection;

        //数组当前的大小
        private  int _size { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ArrayListNew() : this(0) { }

        public ArrayListNew(int capacity)
        {
            if (capacity < 0)
            {
                //数组越界
                throw new ArgumentOutOfRangeException();
            }

            if (capacity ==0)
            {
                _collection = _emptyArray;
            }
            else
            {
                _collection=new T[capacity];
            }

            _size = 0;
        }

        /// <summary>
        /// 确保容量大小正确
        /// </summary>
        /// <param name="minCapacity"></param>
        private void _ensureCapacity(int minCapacity)
        {
            //如果内部集合的容量小于最小容量
            //...并且最大容量没有到达,
            //...然后把内部集合最大化
           
            int newCapacity = (_collection.Length == 0 ? _defaultCapacity : _collection.Length * 2);
            //在堆栈溢出之前,允许达到最大的容量
            int maxCapacity = (DefaultMaxCapacityIsX64 == true ? MAXIMUM_ARRAY_LENGTH_x64 : MAXIMUM_ARRAY_LENGTH_x86);
            if (newCapacity < minCapacity)
                newCapacity = minCapacity;
            if (newCapacity >= maxCapacity)
            {
                newCapacity = maxCapacity - 1;
                IsmaximumCapacityReached = true;
            }

            this._resizeCapacity(newCapacity);
        }

        /// <summary>
        /// 重置这个数组的大小
        /// </summary>
        /// <param name="newCapacity"></param>
        private void _resizeCapacity(int newCapacity)
        {
            if (newCapacity != _collection.Length && newCapacity > _size)
            {
                try
                {
               
                    //传入一个集合,并且根据新的容量返回这个数组
                    System.Array.Resize<T>(ref _collection, newCapacity);
                }
                catch (OutOfMemoryException)  //这里为啥还要这样写呢?
                {
                    if (DefaultMaxCapacityIsX64 == true)
                    {
                        DefaultMaxCapacityIsX64 = false;
                        _ensureCapacity(newCapacity);
                    }

                    throw;
                }
            }
        }

        /// <summary>
        /// 得到列表中单元的数量
        /// </summary>
        public int Count
        {
            get { return _size; }
        }

        /// <summary>
        /// 得到列表的容量
        /// </summary>
        public int Capacity
        {
            get { return _collection.Length; }
        }

        /// <summary>
        /// 判断列表是否为空
        /// </summary>
        public bool IsEmpty
        {
            get { return (Count == 0); }
        }

        /// <summary>
        /// 得到第一个元素
        /// </summary>
        /// <value>The first.</value>
       public T First
       {
           get
           {
               if (Count == 0)
               {
                    throw new IndexOutOfRangeException("List is empty.");

               }

               return _collection[0];
           }
       }

        /// <summary>
        /// 得到最后一个元素
        /// </summary>
        /// <result> The last.</result>
        public T Last
        {
            get
            {
                if (Count==0)
                {
                    throw  new IndexOutOfRangeException("List is empty.");
                }

                return _collection[Count - 1];
            }
        }

        /// <summary>
        /// 得到或者给指定的元素赋值
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _size)
                {
                    throw  new IndexOutOfRangeException();
                }

                return _collection[index];
            }
            set
            {
                if (index < 0 || index >= _size)
                {
                    throw new IndexOutOfRangeException();
                }

                _collection[index] = value;
            }
        }


        /// <summary>
        /// 给列表增加指定位置的元素
        /// </summary>
        /// <param name="dataItem">Data item.</param>
        public void Add(T dataItem)
        {
            if (_size == _collection.Length)
            {
                _ensureCapacity(_size + 1);
            }

            _collection[_size++] = dataItem;
        }



        /// <summary>
        /// 增加一系列的列表
        /// </summary>
        /// <param name="elements"></param>
        public void AddRange(IEnumerable<T> elements)
        {
            if (elements == null)
                throw new ArgumentNullException();

            // make sure the size won't overflow by adding the range
            if (((uint)_size + elements.Count()) > MAXIMUM_ARRAY_LENGTH_x64)
                throw new OverflowException();

            // grow the internal collection once to avoid doing multiple redundant grows
            if (elements.Any())
            {
                _ensureCapacity(_size + elements.Count());

                foreach (var element in elements)
                    this.Add(element);
            }
        }


        /// <summary>
        /// 重复添加元素
        /// </summary>
        public void AddRepeatedly(T value, int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException();

            if (((uint)_size + count) > MAXIMUM_ARRAY_LENGTH_x64)
                throw new OverflowException();

            // grow the internal collection once to avoid doing multiple redundant grows
            if (count > 0)
            {
                _ensureCapacity(_size + count);

                for (int i = 0; i < count; i++)
                    this.Add(value);
            }
        }

        /// <summary>
        /// 在指定位置添加元素
        /// </summary>
        /// <param name="dataItem">Data item to insert.</param>
        /// <param name="index">Index of insertion.</param>
        public void InsertAt(T dataItem, int index)
        {
            if (index < 0 || index > _size)
            {
                throw new IndexOutOfRangeException("Please provide a valid index.");
            }

            // If the inner array is full and there are no extra spaces, 
            // ... then maximize it's capacity to a minimum of _size + 1.
            if (_size == _collection.Length)
            {
                _ensureCapacity(_size + 1);
            }

            // If the index is not "at the end", then copy the elements of the array
            // ... between the specified index and the last index to the new range (index + 1, _size);
            // The cell at "index" will become available.
            if (index < _size)
            {
                System.Array.Copy(_collection, index, _collection, index + 1, (_size - index));
            }

            // Write the dataItem to the available cell.
            _collection[index] = dataItem;

            // Increase the size.
            _size++;
        }


        /// <summary>
        /// 从列表指定元素
        /// </summary>
        /// <returns>>True if removed successfully, false otherwise.</returns>
        /// <param name="dataItem">Data item.</param>
        public bool Remove(T dataItem)
        {
            int index = IndexOf(dataItem);

            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 移除指定位置的元素
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException("Please pass a valid index");
            }
            //减少一个元素,放弃最后一个元素
            _size--;

            //如果指针仍然小于当前元素个数,就使用System.Array.copy方法
            if (index < _size)
            {
                System.Array.Copy(_collection,index+1,_collection,index,(_size-index));
            }

           //将这个值得类型设置为默认类型
           _collection[_size] = default(T);
        }



        /// <summary>
        /// 返回给定值的位置
        /// </summary>
        /// <param name="dataItem"></param>
        /// <returns></returns>
        public int IndexOf(T dataItem)
        {
            return IndexOf(dataItem, 0, _size);
        }
        /// <summary>
        /// 返回给定值得位置
        /// </summary>
        /// <param name="dataItem"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public int IndexOf(T dataItem, int startIndex)
        {
            return IndexOf(dataItem, startIndex, _size);
        }
        /// <summary>
        /// 返回一个给定数据的位置
        /// </summary>
        /// <param name="dataItem"></param>
        /// <param name="startIndex">从哪儿开始搜索的指针</param>
        /// <param name="count">搜索元素的数量?这里指的是哪些</param>
        /// <returns></returns>
        public int IndexOf(T dataItem, int startIndex, int count)
        {
            //检查开始位置的边界
            if (startIndex < 0 || (uint) startIndex > (uint) _size)
            {
                throw  new IndexOutOfRangeException("Please pass a valid starting index");
            }
            //检查边界值和开始位置与包含元素个数的关系
            if (count < 0 || startIndex > (_size - count))
            {
                throw new ArgumentOutOfRangeException();
            }
            //都准备好了,开始返回值
            return System.Array.IndexOf(_collection, dataItem, startIndex, count);
        }

        /// <summary>
        /// 干掉这个数组
        /// </summary>
        public void Clear()
        {
            if (_size > 0)
            {
                _size = 0;
                //只是清空了值,其实数组还是存在的,实际上是把对应内存上的值清除掉
                System.Array.Clear(_collection, 0, _size);
                //为啥又要这步操作呢?
                _collection = _emptyArray;
            }
        }

        public void Resize(int newSize)
        {
            Resize(newSize, default(T));
        }

        /// <summary>
        /// 重置这个数组大小
        /// </summary>
        /// <param name="newSize"></param>
        /// <param name="defaultValue"></param>
        public void Resize(int newSize,T defaultValue)
       {
            int currentSize = this.Count;
            if (newSize>this._collection.Length)
                this._ensureCapacity(newSize+1);
            this.AddRange(Enumerable.Repeat<T>(defaultValue, newSize - currentSize));
       }

        /// <summary>
        /// 翻转这个列表
        /// </summary>
        public void Reverse()
        {
            Reverse(0, _size);
        }
        /// <summary>
        /// 利用数组本身的功能,反转元素
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        public void Reverse(int startIndex, int count)
        {
            //边界与开始位置的处理
            if (startIndex < 0 || startIndex >= _size)
            {
                throw new IndexOutOfRangeException("Please pass a valid starting index.");
            }
            //处理与大小相关的边界数量和开始位置
            if (count < 0 || startIndex > (_size - count))
            {
                throw new ArgumentOutOfRangeException();
            }

            //使用数组的反转功能
            System.Array.Reverse(_collection, startIndex, count);
        }

        /// <summary>
        /// 对数组的每一个元素做操作
        /// </summary>
        /// <param name="action"></param>
        public void ForEach(Action<T> action)
        {
            //不允许空函数
            if (action==null)
            {
                throw new ArgumentOutOfRangeException();
            }

            for (int i = 0; i < _size; ++i)
            {
                action(_collection[i]);
            }
        }

        /// <summary>
        /// 检测是否包含元素
        /// </summary>
        /// <param name="dataItem"></param>
        /// <returns></returns>
        public bool Contains(T dataItem)
        {
            //空值检测
            if ((Object) dataItem == null)
            {
                for (int i = 0; i < _size; i++)
                {
                    if ((Object) _collection[i] == null) return true;
                }
            }
            else
            {
                //建立一个比较器
                EqualityComparer<T> comparer=EqualityComparer<T>.Default;
                for (int i = 0; i < _size; i++)
                {
                    if (comparer.Equals(_collection[i], dataItem)) return true;
                }
            }

            return false;
        }





        //赋值粘贴的
        /// <summary>
        /// Checks whether an item specified via a Predicate<T> function exists exists in list.
        /// </summary>
        /// <param name="searchMatch">Match predicate.</param>
        public bool Exists(Predicate<T> searchMatch)
        {
            // Use the FindIndex to look through the collection
            // If the returned index != -1 then it does exist, otherwise it doesn't.
            return (FindIndex(searchMatch) != -1);
        }


        /// <summary>
        /// Finds the index of the element that matches the predicate.
        /// </summary>
        /// <returns>The index of element if found, -1 otherwise.</returns>
        /// <param name="searchMatch">Match predicate.</param>
        public int FindIndex(Predicate<T> searchMatch)
        {
            return FindIndex(0, _size, searchMatch);
        }


        /// <summary>
        /// Finds the index of the element that matches the predicate.
        /// </summary>
        /// <returns>The index of the element if found, -1 otherwise.</returns>
        /// <param name="startIndex">Starting index to search from.</param>
        /// <param name="searchMatch">Match predicate.</param>
        public int FindIndex(int startIndex, Predicate<T> searchMatch)
        {
            return FindIndex(startIndex, (_size - startIndex), searchMatch);
        }


        /// <summary>
        /// Finds the index of the first element that matches the given predicate function.
        /// </summary>
        /// <returns>The index of element if found, -1 if not found.</returns>
        /// <param name="startIndex">Starting index of search.</param>
        /// <param name="count">Count of elements to search through.</param>
        /// <param name="searchMatch">Match predicate function.</param>
        public int FindIndex(int startIndex, int count, Predicate<T> searchMatch)
        {
            // Check bound of startIndex
            if (startIndex < 0 || startIndex > _size)
            {
                throw new IndexOutOfRangeException("Please pass a valid starting index.");
            }

            // CHeck the bounds of count and startIndex with respect to _size
            if (count < 0 || startIndex > (_size - count))
            {
                throw new ArgumentOutOfRangeException();
            }

            // Null match-predicates are not allowed
            if (searchMatch == null)
            {
                throw new ArgumentNullException();
            }

            // Start the search
            int endIndex = startIndex + count;
            for (int index = startIndex; index < endIndex; ++index)
            {
                if (searchMatch(_collection[index]) == true) return index;
            }

            // Not found, return -1
            return -1;
        }




        /// <summary>
        /// Find the specified element that matches the Search Predication.
        /// </summary>
        /// <param name="searchMatch">Match predicate.</param>
        public T Find(Predicate<T> searchMatch)
        {
            // Null Predicate functions are not allowed. 
            if (searchMatch == null)
            {
                throw new ArgumentNullException();
            }

            // Begin searching, and return the matched element
            for (int i = 0; i < _size; ++i)
            {
                if (searchMatch(_collection[i]))
                {
                    return _collection[i];
                }
            }

            // Not found, return the default value of the type T.
            return default(T);
        }


        /// <summary>
        /// Finds all the elements that match the typed Search Predicate.
        /// </summary>
        /// <returns>ArrayListNew<T> of matched elements. Empty list is returned if not element was found.</returns>
        /// <param name="searchMatch">Match predicate.</param>
        public ArrayListNew<T> FindAll(Predicate<T> searchMatch)
        {
            // Null Predicate functions are not allowed. 
            if (searchMatch == null)
            {
                throw new ArgumentNullException();
            }

            ArrayListNew<T> matchedElements = new ArrayListNew<T>();

            // Begin searching, and add the matched elements to the new list.
            for (int i = 0; i < _size; ++i)
            {
                if (searchMatch(_collection[i]))
                {
                    matchedElements.Add(_collection[i]);
                }
            }

            // Return the new list of elements.
            return matchedElements;
        }


        /// <summary>
        /// Get a range of elements, starting from an index..
        /// </summary>
        /// <returns>The range as ArrayListNew<T>.</returns>
        /// <param name="startIndex">Start index to get range from.</param>
        /// <param name="count">Count of elements.</param>
        public ArrayListNew<T> GetRange(int startIndex, int count)
        {
            // Handle the bound errors of startIndex
            if (startIndex < 0 || (uint)startIndex > (uint)_size)
            {
                throw new IndexOutOfRangeException("Please provide a valid starting index.");
            }

            // Handle the bound errors of count and startIndex with respect to _size
            if (count < 0 || startIndex > (_size - count))
            {
                throw new ArgumentOutOfRangeException();
            }

            var newArrayList = new ArrayListNew<T>(count);

            // Use System.Array.Copy to quickly copy the contents from this array to the new list's inner array.
            System.Array.Copy(_collection, startIndex, newArrayList._collection, 0, count);

            // Assign count to the new list's inner _size counter.
            newArrayList._size = count;

            return newArrayList;
        }


        /// <summary>
        /// Return an array version of this list.
        /// </summary>
        /// <returns>System.Array.</returns>
        public T[] ToArray()
        {
            T[] newArray = new T[Count];

            if (Count > 0)
            {
                System.Array.Copy(_collection, 0, newArray, 0, Count);
            }

            return newArray;
        }


        /// <summary>
        /// Return an array version of this list.
        /// </summary>
        /// <returns>System.Array.</returns>
        public List<T> ToList()
        {
            var newList = new List<T>(this.Count);

            if (this.Count > 0)
            {
                for (int i = 0; i < this.Count; ++i)
                {
                    newList.Add(_collection[i]);
                }
            }

            return newList;
        }


        /// <summary>
        /// Return a human readable, multi-line, print-out (string) of this list.
        /// </summary>
        /// <returns>The human readable string.</returns>
        /// <param name="addHeader">If set to <c>true</c> a header with count and Type is added; otherwise, only elements are printed.</param>
        public string ToHumanReadable(bool addHeader = false)
        {
            int i = 0;
            string listAsString = string.Empty;

            string preLineIndent = (addHeader == false ? "" : "\t");

            for (i = 0; i < Count; ++i)
            {
                listAsString = String.Format("{0}{1}[{2}] => {3}\r\n", listAsString, preLineIndent, i, _collection[i]);
            }

            if (addHeader == true)
            {
                listAsString = String.Format("ArrayListNew of count: {0}.\r\n(\r\n{1})", Count, listAsString);
            }

            return listAsString;
        }


        /********************************************************************************/


    }

}

