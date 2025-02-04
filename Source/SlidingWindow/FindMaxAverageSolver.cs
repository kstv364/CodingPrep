using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.SlidingWindow
{
    internal class FindMaxAverageSolver
    {
        public double FindMaxAverage(int[] nums, int k)
        {
            int windowSize = k;
            double ans = double.MinValue;
            double sum = 0;
            for(int i=0; i<nums.Length; i++)
            {
                sum += nums[i];
                if(i >= windowSize)
                {
                    // exclude the leftmost
                    sum -= nums[i - windowSize];
                }
                if(i >= windowSize - 1)
                {
                    ans = Math.Max(ans, sum/windowSize);
                }
            }
            return ans;
        }

        public int NumOfSubarrays(int[] arr, int k, int threshold)
        {
            int ans = 0;
            double windowSum = 0;
            for(int i=0 ; i<arr.Length ; i++)
            {
                windowSum += arr[i]; // inclue ith
                if(i >= k)
                {
                    windowSum -= arr[i-k];
                }

                if (i >= k - 1)
                {
                    // valid window of size k
                    double avg = windowSum/k;
                    if(avg >= threshold)
                    {
                        ans++;
                    }
                }
            }
            return ans;
        }

        public int[] GetAverages(int[] nums, int k)
        {
            int windowSize = 2 * k + 1;
            int[] ans = new int[nums.Length];
            for(int i = 0; i < nums.Length; i++)
            {
                ans[i] = -1;
            }
            int currentSum = 0;
            for(int i = 0;i < nums.Length; i++)
            {
                currentSum += nums[i];
                if(i >= windowSize) 
                {
                    currentSum -= nums[i - windowSize];
                }

                if(i >= windowSize - 1)
                {
                    ans[i-k] = currentSum / windowSize;
                }
            }
            return ans;
        }

        public long MaximumSubarraySum(int[] nums, int k)
        {
            Dictionary<int,int> count = new Dictionary<int,int>();
            long currSum = 0;
            long ans = 0;
            for(int i = 0; i < nums.Length; i++) 
            {
                count[nums[i]] = count.GetValueOrDefault(nums[i],0) +1;
                currSum += nums[i];
                if(i >= k)
                {
                    count[nums[i-k]]--;
                    currSum -= nums[i-k];
                    if(count[nums[i - k]] == 0)
                    {
                        count.Remove(nums[i-k]);
                    }
                }

                if(i >= k - 1)
                {
                    // valid window
                    if (IsDistinct(count, k))
                    {
                        // valid candidate
                        ans = Math.Max(currSum, ans);
                    }
                    
                }
            
            }
            return (long)ans;
        }

        private bool IsDistinct(Dictionary<int, int> count, int windowSize)
        {
            return count.Count == windowSize;
        }

        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums.Length == 0 || k == 0)
            {
                return new int[0];
            }

            int n = nums.Length;
            int[] result = new int[n - k + 1];
            int ri = 0; // Index for the result array

            // Create a Deque (Double-ended queue) to store indices of elements
            // The front of the Deque will always have the index of the maximum element in the current window
            LinkedList<int> deque = new LinkedList<int>();

            for (int i = 0; i < n; i++)
            {
                // Remove indices of elements that are out of the current window from the front of the Deque
                while (deque.Count > 0 && deque.First.Value < i - k + 1)
                {
                    deque.RemoveFirst();
                }

                // Remove indices of elements that are smaller than the current element from the back of the Deque
                while (deque.Count > 0 && nums[deque.Last.Value] < nums[i])
                {
                    deque.RemoveLast();
                }

                // Add the current index to the back of the Deque
                deque.AddLast(i);

                // If the window has moved to the point where it contains 'k' elements, start storing the maximum for each window
                if (i >= k - 1)
                {
                    result[ri++] = nums[deque.First.Value];
                }
            }

            return result;
        }
    }
}
