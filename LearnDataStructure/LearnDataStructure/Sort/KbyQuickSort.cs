using System;
using System.Collections.Generic;
using System.Text;

namespace LearnDataStructure.Sort
{

    /// <summary>
    /// 利用快排，得到第k大的元素
    /// 思路，第k大的元素出现在p上面时，为k=p+1
    /// 如果小于a[p]则出现在小于p+1
    /// 如果大于[p]则出现在大于p+1
    /// 时间复杂度n+n/2+n/4+...+1 最后2n-1
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class KbyQuickSort<T> where T : IComparable<T>
    {
        public T SortByQuick(T[] a, int n,int k)
        {
           return GetMostKByQuickSort(a, 0, n - 1,k);
        }


        public T SortByQuickTwo(T[] a, int n, int k)
        {
            return GetMostKByQuickSortTwo(a, 0, n - 1, k);
        }

        /// <summary>
        /// 用while
        /// </summary>
        /// <param name="a"></param>
        /// <param name="p">0</param>
        /// <param name="r">n-1</param>
        public T GetMostKByQuickSort(T[] a, int p, int r,int k)
        {

            int q = Partion(a, p, r);//获取分区点
          
            //从q处分开
            while (k!=q + 1)
            {
                if (k<q+1)
                {
                    q = Partion(a, p, q - 1);
                   
                }
                else if (k >q + 1)
                {
                    q = Partion(a, q + 1, r);
                }
            }         
            return a[q];
        }


        /// <summary>
        /// 用迭代
        /// </summary>
        /// <param name="a"></param>
        /// <param name="p"></param>
        /// <param name="r"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        private T GetMostKByQuickSortTwo(T[] a, int p, int r, int k)
        {
            int q = Partion(a, p, r);//获取分区点
            if (k == q + 1-p)
            {
                return a[q];
            }
            else if (k < q + 1)
            {
                return GetMostKByQuickSortTwo(a, p, q - 1, k);
            }
            else
            {
                //如果是后面，k就发生了改变，要减去
                return GetMostKByQuickSortTwo(a, q+1, r, k-(q+1-p));
            }
        }






        /// <summary>
        /// i是最后要交换的位置
        /// j是一步一步向下走
        /// 在j向下走的过程中,如果都是大于所给值,则i不变
        /// 如果小于所给值,则i移动到下一位
        /// i的位置一直保持在小于给定值的右边,最后交换这两个位置就行了
        /// </summary>
        /// <param name="a"></param>
        /// <param name="p"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        private int Partion(T[] a, int p, int r)
        {
            T pivot = a[r];
            int i = p;
            //这里的j如何表示?
            for (int j = p; j < r; ++j)
            {
                if (a[j].CompareTo(pivot) < 0)
                {
                    if (i == j)
                    {
                        ++i;
                    }
                    else
                    {
                        T tmp1 = a[i];
                        //注意这里的i是后面加上来
                        a[i++] = a[j];
                        a[j] = tmp1;
                    }
                }
            }

            //最后这里是干嘛的?
            T tmp2 = a[i];
            a[i] = a[r];
            a[r] = tmp2;
            return i;
        }

    }
}
