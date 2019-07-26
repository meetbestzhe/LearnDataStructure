using System;
using System.Collections.Generic;

namespace LeetCode.ArrayLearn
{
    public class TwoSum
    {
        public int[] TwoSumAdd(int[] nums, int target)
        {
            Dictionary<int,int> dictionary= new  Dictionary<int,int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int temp = target - nums[i];
                if (dictionary.TryGetValue(temp,out int index))
                {
                    return  new int[]{index,i};
                }
                else
                {
                    //dictionary[nums[i]]=i;
                    dictionary.TryAdd(nums[i], i);
                }
            }
           return  new int[]{-1,-1};
        }

    }
}
