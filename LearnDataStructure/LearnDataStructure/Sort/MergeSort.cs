using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LearnDataStructure.Sort
{
    /// <summary>
    /// 1.空间复杂度,至少0(n)
    /// 2.最好情况n*logn,每次本身都选的中间元素,分区logn次
    /// 3.最坏情况n*logn,每次本身都选的中间元素,分区logn次
    /// 4.平均n*logn
    /// 5.非原地,稳定排序,由于两个数组合并时借用了一个新的数组
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MergeSort<T> where T:IComparable<T>
    {
        public void MergeBySort( T[] a, int n)
        {
            MergeSortInternally(a, 0, n - 1);
            //因为a下面的函数运行后,还是他
          
        }
        //递归调用函数
        private void MergeSortInternally(T[] a, int p, int r)
        {
            if (p>=r) return;
           //取p 到r的中间位置q,防止(p+r)的和超过int类型最大值
           int q = p + (r - p) / 2;

            MergeSortInternally(a,p,q);
            MergeSortInternally(a, q+1, r);
            //将A[p...q]和A[q+1..r]合并为A[p....r]
            Merge(a, p, q, r);
        }

        private void Merge(T[] a, int p, int q, int r)
        {
            int i = p;
            int j = q + 1;
            int k = 0;
            //建立一个临时数组和a一样的大小
            T[] tmp=new T[r-p+1];
            while (i<=q &&j<=r)
            {
                if (a[i].CompareTo(a[j])<=0)
                {
                    tmp[k++] = a[i++];
                }
                else
                {
                    tmp[k++] = a[j++];
                }
            }
            //判断哪个子数组中有剩余的数据

            int start = i;
            int end = q;

            //这里为什么要等于?,如果上一步中,j满了,j会变成r+1,所以下面的是满足的.
            if (j<=r)
            {
                start = j;
                end = r;
            }
            while (start <= end)
            {
                //注意这里的k是后面再加上来
                tmp[k++] = a[start++];
            }
            //将剩余的数组拷贝到临时数组
            for (int m = 0; m<=r-p; m++)
            {
                a[p + m] = tmp[m];
            }
        }

    }
}
