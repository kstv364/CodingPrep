
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.TwoPointers
{
    internal class ArrayExceptSelf
    {
        private int[] _prefixProduct;
        public int[] ProductExceptSelf(int[] nums)
        {
            _prefixProduct = new int[nums.Length + 1];
            _prefixProduct[0] = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                _prefixProduct[i + 1] = _prefixProduct[i] * nums[i];
            }
            int[] result = new int[nums.Length];
            int suffixProduct = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                result[i] = _prefixProduct[i] * suffixProduct;
                suffixProduct *= nums[i];
            }
            return result;

        }
    }
}
