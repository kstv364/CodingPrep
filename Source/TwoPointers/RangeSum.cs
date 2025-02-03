using Solutions.TwoPointers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

//Given an integer array nums, handle multiple queries of the following type:

//Calculate the sum of the elements of nums between indices left and right inclusive where left <= right.
//Implement the NumArray class:

//NumArray(int[] nums) Initializes the object with the integer array nums.
//int sumRange(int left, int right) Returns the sum of the elements of nums between indices left and right inclusive (i.e.nums[left] + nums[left + 1] + ... + nums[right]).
namespace Solutions.TwoPointers
{
    public class NumArray
    {
        private int[] _prefixSum;

        public NumArray(int[] nums)
        {
            _prefixSum = new int[nums.Length + 1];
            for (int i = 0; i < nums.Length; i++)
            {
                _prefixSum[i + 1] = _prefixSum[i] + nums[i];
            }
        }

        public int SumRange(int left, int right)
        {
            return _prefixSum[right + 1] - _prefixSum[left];

        }
    }
}
