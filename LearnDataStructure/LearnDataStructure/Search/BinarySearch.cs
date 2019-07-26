using System;
using System.Collections.Generic;
using System.Text;

namespace LearnDataStructure.Search
{
    /// <summary>
    /// 二分查找法,针对有序的数组
    /// 如何考虑找不到,称为2019-7-25的困惑
    /// 应该使用low=high,结合a[low]与aimValue值一起判断
    /// 其实low如果大于high 了就是找不到...总算搞懂了
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinarySearch<T> where T:IComparable<T>
    {
        public int SearchByDichotomizing(T[] a,int N,T aimValue)
        {
            return GetIndex( a,0,N-1, aimValue);
        }

        public int SearchFirstEqualByDichotomizing(T[] a, int N, T aimValue)
        {
            return GetIndexFirstEqual(a, 0, N - 1, aimValue);
        }
        public int SearchLastEqualByDichotomizing(T[] a, int N, T aimValue)
        {
            return GetIndexLastEqual(a, 0, N - 1, aimValue);
        }
        public int SearchFirstGreaterAndEqualByDichotomizing(T[] a, int N, T aimValue)
        {
            return GetIndexFirstGreaterAndEqual(a, 0, N - 1, aimValue);
        }
        public int SearchLastLessAndEqualByDichotomizing(T[] a, int N, T aimValue)
        {
            return GetIndexLastLessAndEqual(a, 0, N - 1, aimValue);
        }


        /// <summary>
        /// 最简单的,没有重复元素
        /// 如果存在,则必然是中间值等于,或者最后low=heigt直接找到,其实也是中间值相等
        /// </summary>
        /// <param name="a"></param>
        /// <param name="p"></param>
        /// <param name="r"></param>
        /// <param name="aimValue"></param>
        /// <returns></returns>
        private int GetIndex(T[] a,int low ,int high,T aimValue)
        {

            //分区点

            if (low<=high)
            {
                int mid = low + (high - low) / 2;


                if (a[mid].CompareTo(aimValue) == 0)
                {
                    return mid;
                }
                if (a[mid].CompareTo(aimValue) > 0)
                {
                    return GetIndex(a, low, mid - 1, aimValue);
                }
                if (a[mid].CompareTo(aimValue) < 0)
                {
                    return GetIndex(a, mid + 1, high, aimValue);
                }
            }
           
                return -1;
        
          

        }



        /// <summary>
        /// 第一种变形,找到第一个相等的值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="p"></param>
        /// <param name="r"></param>
        /// <param name="aimValue"></param>
        /// <returns></returns>
        private int GetIndexFirstEqual(T[] a, int low, int high, T aimValue)
        {

            if (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (a[mid].CompareTo(aimValue) == 0 )
                {
                    //这样写，好简洁。。。

                    if ((mid == 0) || (a[mid - 1].CompareTo(aimValue) !=0)) return mid;
                    else
                    {
                        high = mid - 1;
                         return GetIndex(a, low, high, aimValue);
                    }

                    //if (mid==0)
                    //{
                    //    return mid;
                    //}
                    
                    //while (a[mid].CompareTo(aimValue)==0&&a[mid-1].CompareTo(aimValue)==0)
                    //{
                    //   //
                    //   if (mid==1)
                    //   {
                    //       return mid-1;
                    //   }
                    //    mid--;
                    //}
                     
                    

                }

                if (a[mid].CompareTo(aimValue) > 0)
                {
                    high = mid - 1;
                    return GetIndex(a, low, high, aimValue);
                }
                if (a[mid].CompareTo(aimValue) < 0)
                {
                    low = mid + 1;
                    return GetIndex(a, low, high, aimValue);
                }
            }

            return -1;
        }



        /// <summary>
        /// 第二种变形,找到最后一个相等的值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="p"></param>
        /// <param name="r"></param>
        /// <param name="aimValue"></param>
        /// <returns></returns>
        private int GetIndexLastEqual(T[] a, int low, int high, T aimValue)
        {
            //分区点
            if (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (a[mid].CompareTo(aimValue) == 0)
                {
                    //这里改为！=好些，如果是从大到小的数组呢？
                    //if ((mid == a.Length - 1) || (a[mid + 1].CompareTo(aimValue) > 0)) return mid;
                    //mid==a.length-1，放在前面，可以避免出现后面越界的情况
                    if ((mid == a.Length-1) || (a[mid + 1].CompareTo(aimValue) != 0)) return mid;
                    else
                    {
                        low = mid + 1;
                        return GetIndexLastEqual(a, low, high, aimValue);
                    }
                   
                    //当前值和下一个值同时判断
                    //if (mid==a.Length-1)
                    //{
                    //    return mid;
                    //}
                    //while (a[mid].CompareTo(aimValue) == 0 && a[mid +1].CompareTo(aimValue) == 0)
                    //{
                    //    if (mid == a.Length-2)
                    //    {
                    //        return mid+1;
                    //    }
                    //    mid++;
                    //}

                    //return mid;

                }

                if (a[mid].CompareTo(aimValue) > 0)
                {
                    high = mid - 1;
                    return GetIndex(a, low, high, aimValue);
                }
                if (a[mid].CompareTo(aimValue) < 0)
                {
                    low = mid + 1;
                    return GetIndex(a, low, high, aimValue);
                }
            }

            return -1;
        }



        /// <summary>
        /// 第三种变形,找到第一个大于等于的值，这种默认从小到大排序
        /// </summary>
        /// <param name="a"></param>
        /// <param name="p"></param>
        /// <param name="r"></param>
        /// <param name="aimValue"></param>
        /// <returns></returns>
        private int GetIndexFirstGreaterAndEqual(T[] a, int low, int high, T aimValue)
        {
            if (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (a[mid].CompareTo(aimValue) >= 0)
                {
                    if ((mid == 0) || (a[mid-1].CompareTo(aimValue) < 0)) return mid;
                    high =mid- 1;
                    return GetIndex(a, low, high, aimValue);
                }

                if (a[mid].CompareTo(aimValue) < 0)
                {
                    low = mid + 1;
                    return GetIndex(a, low, high, aimValue);
                }
            }

            return -1;


            //while (low <= high)
            //{
            //    int mid = low + ((high - low) >> 1);
            //    if (a[mid].CompareTo(aimValue)>=0)
            //    {
            //        if ((mid == 0) || (a[mid - 1].CompareTo(aimValue) <0)) return mid;
            //        else high = mid - 1;
            //    }
            //    else
            //    {
            //        low = mid + 1;
            //    }
            //}
            //return -1;

        }


        /// <summary>
        /// 第四种变形，找到最后一个小于等于的值，这种默认从小到大排序
        /// </summary>
        /// <param name="a"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <param name="aimValue"></param>
        /// <returns></returns>
        private int GetIndexLastLessAndEqual(T[] a, int low, int high, T aimValue)
        {
            int mid = low + (high - low) / 2;
            if (low<=high)
            {
                if (a[mid].CompareTo(aimValue) <= 0)
                {
                    if ((mid == a.Length - 1) || (a[mid + 1].CompareTo(aimValue) >= 0)) return mid;
                    low = mid + 1;
                    return GetIndexLastLessAndEqual(a, low, high, aimValue);
                }
                if (a[mid].CompareTo(aimValue) > 0)
                {
                    high = mid - 1;
                    return GetIndexLastLessAndEqual(a, low, high, aimValue);

                }

            
            }

            return -1;

        }
    }
}
