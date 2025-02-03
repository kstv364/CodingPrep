using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.TwoPointers
{
    public class LeftRightDifferences
    {
        public int[] LeftRightDifference(int[] nums)
        {
            int prefixSum = 0;
            int[] result = new int[nums.Length];
            int totalSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                totalSum += nums[i];
            }

            for (int i = 0; i < nums.Length; i++)
            {
                prefixSum += nums[i];
                int leftSum = prefixSum - nums[i];
                int rightSum = totalSum - prefixSum - nums[i];
                result[i] = Math.Abs(leftSum - rightSum);
            }
            return result;
        }
    }
}
