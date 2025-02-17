﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.SlidingWindow
{
    internal class SlidingWindowStatTemplate
    {
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
