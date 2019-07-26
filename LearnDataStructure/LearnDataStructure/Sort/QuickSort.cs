using System;
using System.Collections.Generic;
using System.Text;

namespace LearnDataStructure.Sort
{
    
    /// <summary>
    /// 1.空间复杂度,O(n)
    /// 2.最好情况n*logn,每次都选的中间元素,分区logn次
    /// 3.最坏情况n*n,每次都选的最后一个元素,导致分区n次
    /// 4.平均n*logn
    /// 5.原地非稳定,下面的写法是不稳定的比如1,5,4,2,6,4  最后4和4会交换位置
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QuickSort<T> where  T:IComparable<T>
    {
        public void SortByQuick(T[] a, int n)
        {
            QuickSortInternally(a, 0, n - 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="p">0</param>
        /// <param name="r">n-1</param>
        private void QuickSortInternally(T[] a, int p, int r)
        {
            if (p>=r) return;
            int q = Partion(a, p, r);//获取分区点
            //从q处分开
            QuickSortInternally(a,p,q-1);
            QuickSortInternally(a,q+1,r);
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
