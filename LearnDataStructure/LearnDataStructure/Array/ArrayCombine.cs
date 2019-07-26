using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LearnDataStructure.Lists
{
    //可以调整大小的数组
    public class ArrayCombine<T>:IEnumerable<T>
    {
        //有一个数组的定义
        private T[] data;
        //数组里面的元素个数
        private int size;

        /// <summary>
        /// 数组构造函数
        /// </summary>
        /// <param name="capacity"></param>
        public ArrayCombine(int capacity)
        {
            data = new T[capacity];
            size = 0;
        }
        
        /// <summary>
        /// 获得数组容量
        /// </summary>
        /// <returns></returns>
        public int GetCapacity()
        {
            return data.Length;
        }

        /// <summary>
        /// 获取当前元素个数
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return size;
        }

        /// <summary>
        /// 判断数组是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return size == 0;
        }

        /// <summary>
        /// 修改数组的值
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void set(int index, T value)
        {
            CheckIndex(index);
            data[index] = value;
           
        }
        /// <summary>
        /// 获取数组的某个值
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T get(int index)
        {
            CheckIndex(index);
            return data[index];
        }

        /// <summary>
        /// 检查这个数组中是否包含有某个值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool contains(T value)
        {
            for (int i = 0; i < size; i++)
            {
                if (data[i].Equals(value))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 查找数组中某个元素的指针
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int find(T value)
        {
            for (int i = 0; i < size; i++)
            {
                if (data[i].Equals(value))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// 在指定位置插入值
        /// </summary>
        /// <param name="index"></param>
        /// <param name="e"></param>
        public void Insert(int index, T e)
        {
            CheckIndex(index);
            if (size==data.Length)
            {
                //数组调整了,扩大为两倍
                Resize(2 * data.Length);
            }
            //插入就是从最后开始等于前面的
            for (int i = size; i > index; i--)
            {
                data[i] = data[i-1];

            }
            data[index] = e;
            size++;
        }
        /// <summary>
        /// 在数组头部增加元素
        /// </summary>
        /// <param name="e"></param>
        public void AddFirst(T e)
        {
            Insert(0,e);
        }

        /// <summary>
        /// 在数组尾部增加元素
        /// </summary>
        /// <param name="e"></param>
        public void AddLast(T e)
        {
            Insert(size,e);
        }

        /// <summary>
        /// 删除指定位置元素,指出删除的是谁
        /// </summary>
        /// <param name="index"></param>
        /// <param name="e"></param>
        public T Delete(int index)
        {
            CheckIndexForRemove(index);
            
            if (size==data.Length/4&&data.Length!=0)
            {
                Resize(data.Length/2);
            }
            T result = data[index];
            for (int i = index; i < size-1; i++)
            {
                data[i] = data[i+1];
            }
            size--;//如果最后一个值没有被删除,这里默认就删除了.
            data[size]=default(T);//将最后一个值弄掉
            return result;
        }

        /// <summary>
        /// 指出删除的是谁
        /// </summary>
        /// <returns></returns>
        public T DeleteLast()
        {
            return Delete(size - 1);
        }

        /// <summary>
        /// 扩容方法,新建立一个数组,时间复杂度O(n)
        /// </summary>
        /// <param name="length"></param>
        private void Resize(int length)
        {
            T[] dataNew = new T[length];
            for (int i = 0; i < size; i++)
            {
                dataNew[i] = data[i];
            }
            data = dataNew;
            
        }

        public void Combine(ArrayCombine<T> otherData)
        {
            if (otherData.Count() + size>data.Length)
            {
                Resize(2 * data.Length);
            }

            for (int i = 0; i < otherData.Count(); i++)
            {
                //这里不理解.
                data[i + size] = otherData.get(i);
            }

            size = size + otherData.Count();
        }

        /// <summary>
        /// 检查指针的有效性
        /// </summary>
        /// <param name="index"></param>
        private void CheckIndex(int index)
        {
            if (index < 0 || index > size)
            {
                throw  new ArgumentOutOfRangeException("超出了数组范围");
            }
        }

        /// <summary>
        /// 检查指针在删除时的有效性
        /// </summary>
        /// <param name="index"></param>
        private void CheckIndexForRemove(int index)
        {
            if (index < 0 || index >=size)
            {
                throw new ArgumentOutOfRangeException("超出了数组范围");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < size; i++)
            {
                yield return data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}




//一.指定位置
//1.插入,是从后面赋予前面值,而且size大小可用,过头时考虑扩容    >index
//2.删除,是从前面赋予后面值,size-1才能用.减少时考虑缩容,考虑减少到0的情况   <size-1