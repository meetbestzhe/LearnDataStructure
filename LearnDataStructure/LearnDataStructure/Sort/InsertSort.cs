using System;
using System.Collections.Generic;
using System.Text;

namespace LearnDataStructure.Sort
{
    public class InsertSort<T> where T : IComparable<T>
    {
        /// <summary>
        /// 从小到大,插入排序
        /// 重点,插入的比较,是从后面开始的,这样就方便了移位置
        /// 1.空间复杂度,不需要额外的存储空间,0(1)
        /// 2.此种写法在有相同值时,排序后,前后位置是不变的,所以是稳定的
        /// 3.最好的,还是O(n),最复杂的O(n2)
        /// 4.平均复杂度,数组中插入一个数据的平均复杂度是O(n),因此,插入n个,就是O(n);
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public T[] SortByInsert(T[] arr)
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

            for (int i = 1; i < arr.Length; i++)
            {
                T value = arr[i];
                int j = i - 1;
                //查找插入的位置,倒序查找为了挪动位置方便
                for (; j>=0; j--)
                {
                    if (arr[j].CompareTo(value)>0)
                    {
                        //这里只有一段赋值,插入有三段
                        arr[j + 1] = arr[j];
                    }
                    else
                    {
                        break; 
                    }
                }
                arr[j + 1] = value;
            }
            //第一种,头部插入
           
            return arr;
        }

    }
}
