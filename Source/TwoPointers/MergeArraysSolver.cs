using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.TwoPointers
{
    internal class MergeArraysSolver
    {
        public int[][] MergeArrays(int[][] nums1, int[][] nums2)
        {
            var result = new List<int[]>();
            var p1 = 0;
            var p2 = 0;

            while (p1 < nums1.Length && p2 < nums2.Length)
            {
                if (nums1[p1][0] == nums2[p2][0])
                {
                    result.Add(new[] { nums1[p1][0], nums1[p1++][1] + nums2[p2++][1] });
                }
                else if (nums1[p1][0] < nums2[p2][0])
                {
                    result.Add(nums1[p1++]);
                }
                else
                {
                    result.Add(nums2[p2++]);
                }
            }

            while (p1 < nums1.Length)
            {
                result.Add(nums1[p1++]);
            }

            while (p2 < nums2.Length)
            {
                result.Add(nums2[p2++]);
            }

            return result.ToArray();
        }

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int k = m + n - 1;
            int i = m - 1;
            int j = n - 1;

            while(i >= 0 && j >= 0)
            {
                if (nums1[i] > nums2[j])
                {
                    nums1[k--] = nums1[i--];
                }
                else
                {
                    nums1[k--] = nums2[j--];
                }
            }

            while(i >= 0) { nums1[k--] = nums1[i--]; }
            while (j >= 0) { nums1[k--] = nums2[j--]; }

        }


        public void Rotate(int[] nums, int k)
        {
            k = k % nums.Length;
            Reverse(nums, 0, nums.Length - 1);
            Reverse(nums, 0, k - 1);
            Reverse(nums, k, nums.Length - 1);
        }
        private void Reverse(int[] nums, int start, int end)
        {
            int i = start;
            int j = end;
            while (i < j)
            {
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
                i++; j--;
            }
        }

        public int RemoveDuplicates(int[] nums)
        {
            if(nums.Length <= 2) return nums.Length;

            int i = 2;
            for (int j = 2; j < nums.Length; j++)
            {
                if (nums[j] != nums[i - 2])
                {
                    nums[i] = nums[j];
                    i++;
                }
            }
            return i;
           
        }

        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for(int j = 0; j < nums.Length; j++)
                {
                    if (nums[j] + nums[i] == target)
                        return [i, j];
                }
            }
            return [-1, -1];

        }







    }
}
