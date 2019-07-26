using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace LearnDataStructure.Sort
{
    public class ChooseSort<T> where T : IComparable<T>
    {
        /// <summary>
        /// 每一次找到最小的,从前往后找,从前往后放
        /// 重点,交换元素位置(导致了不稳定)
        /// 1.空间复杂度,不需要额外的存储空间,0(1)
        /// 2.此种写法在有相同值(均不在第一位)时,排序后,前后位置是不变的,但是如果有值在第一位和后面一样,则会出事,所以是不稳定的
        /// 3.最好的,还是O(n2),最复杂的O(n2)
        /// 4.平均复杂度,数组中查找最小值的平均复杂度是O(n),因此,查找n次,就是O(n);
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public T[] SortByChoose(T[] arr)
        {
            if (arr == null)
            {
                throw new NotSupportedException("数组未创建,无法排序");
            }
            if (arr.Length == 0)
            {
                throw new NotSupportedException("数组中无值,无法排序");
            }
            if (arr.Length == 1)
            {
                return arr;
            }

            //首先找到最小值

            for (int i = 0; i < arr.Length-1; i++)
            {
                T minValue = arr[i];
                T midValue = arr[i];

                int m = 0;
                for (int j=i+1; j < arr.Length ; j++)
                {
                    if (minValue.CompareTo(arr[j]) > 0)
                    {
                        minValue = arr[j];
                        m++;
                    }
                   
                }
                if (minValue.CompareTo(midValue)!=0)
                {
                    arr[i] = minValue;
                    arr[i+m] = midValue;
                }
              
            }
            return arr;
        }

    }
}
