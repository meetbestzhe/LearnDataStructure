using System;
using System.Runtime.InteropServices.ComTypes;
using LearnDataStructure.Lists;
using LeetCode.ArrayLearn;
using Xunit;

namespace UnitTest.LeetCode.ArrayLearn
{
    public static class TwoSumTest
    {
        [Fact]
        public static void DoTest()
        {
            TwoSum twoSum = new TwoSum();
            Int32[] nums = new[] {3,2,4};
            int target = 6;
            int[] result = twoSum.TwoSumAdd(nums, target);
            Assert.True(result[0]==1&& result[1] == 2, "找到了值");
        }
    }
}
