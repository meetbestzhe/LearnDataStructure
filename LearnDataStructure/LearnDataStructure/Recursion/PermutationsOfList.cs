using System;
using System.Collections.Generic;
using System.Text;

//https://stackoverflow.com/questions/2710713/algorithm-to-generate-all-possible-permutations-of-a-list
namespace LearnDataStructure.Recursion
{
   public class PermutationsOfList<T>
    {
        public IEnumerable<List<T>> Permutate<T>(List<T> input)
        {
            //如果数量为2,返回本身以及互换位置的
            if (input.Count==2)
            {
                yield return  new List<T>(input);
                yield return new List<T>{input[1],input[0]};
            }
            else
            {
                foreach (T elem in input)
                {
                    var rlist=new List<T>(input);//创建子数组
                    rlist.Remove(elem);//移除这个元素
                    foreach (List<T> retList in Permutate<T>(rlist))
                    {
                        retList.Insert(0, elem);
                        yield return retList;
                    }
                }
            }
        }
    }
}
