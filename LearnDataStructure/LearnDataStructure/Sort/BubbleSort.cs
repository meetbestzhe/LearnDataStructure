using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LearnDataStructure.Sort
{

    /// <summary>
    /// 1.空间复杂度,由于交换,只有一个额外数据,所以为o(1)
    /// 2.最好情况123456,O(n)
    /// 3.最坏情况654321,O(n2)
    /// 4.平均O(n2)
    /// 5.不稳定的
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BubbleSort<T> where  T:IComparable<T>
    {
        /// <summary>
        /// 从小到大,冒泡排序
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public T[] SortByBubbule(T[] arr)
        {
            if (arr==null)
            {
                throw  new NotSupportedException("数组未创建,无法排序");
            }
            if (arr.Length==0)
            {
                throw new NotSupportedException("数组中无值,无法排序");
            }
            if (arr.Length == 1)
            {
                return arr;
            }

            for (int i = 0; i < arr.Length-1; i++)
            {
                T minValue = default(T);
                int over = 0;
                if (arr[i].CompareTo(arr[i + 1])>0)
                {
                    //这里有三段赋值,插入只有一段
                    minValue = arr[i + 1];
                    arr[i + 1] = arr[i];
                    arr[i] = minValue;
                    over++;
                }
                //提前结束方法
                if (over==0)
                {
                   break;
                }
            }
            return arr;
        }
       
    }
}
