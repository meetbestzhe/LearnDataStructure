using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LearnDataStructure.Lists
{
    /// <summary>
    /// 实现一个大小固定可以增删改的数组
    /// </summary>
    /// 数组特点:1.数组是连续的
    /// 数组特点:2.数组
    public class Array
    {
        //数组的定义
        public int[] data;

        //数组长度,私有还是共有，外界如何处理
        private int n;

        //数组实际元素个数
        private int count;

        /// <summary>
        /// 数组构造函数
        /// </summary>
        /// <param name="capacity">数组容量</param>
        public Array(int capacity)
        {
            this.data = new int[capacity];
            this.n = capacity;
            this.count = 0;
        }


        /// <summary>
        /// 根据索引,查找数据中的元素并返回
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int Find(int index)
        {
            if (index < 0 || index >= count) return -1;
            return data[index];
        }

        /// <summary>
        /// 插入元素:考虑头部插入与尾部插入,还有中间插入
        /// </summary>
        /// <param name="location">按照实际位置算</param>
        /// <param name="value">插入的值</param>
        public void Insert(int location, int value)
        {
            //判断数组是否已经满了
            if (n == count)
            {
                throw new ArgumentOutOfRangeException("数组已满,请不要再插入");
            }

            //检验位置是否合理
            if (location < 0 || location > count)
            {
                throw new ArgumentOutOfRangeException("增加参数位置超出范围");
            }

            count++;
            //不管是第一个,中间,还是最后一个,这样都能完成
            for (int i = count-1; i > location; i--)
            {
                data[i] = data[i - 1];
            }

            data[location] = value;

        }
         
        /// <summary>
        /// 删除数组中的元素
        /// </summary>
        /// <param name="location"></param>
        /// <param name="value"></param>
        public void Delete(int location, int value)
        {
            //检验位置是否合理
            if (location < 0 || location >= count )
            {
                throw new ArgumentOutOfRangeException("删除参数位置超出范围");
            }
            //删除尾部

            for (int i = location; i <count; i++)
            {
                data[i] = data[i+1];
            }
            count--;
        }

        public void PrintAll()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(data[i]+"  ");
            }
        }
    }
}
