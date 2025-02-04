using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.SlidingWindow
{
    internal class TemplateFixedWindow
    {
        public bool Solve(int[] nums, int windowSize)
        {
            int n = nums.Length;
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += nums[i]; // add the new element
                if (i >= windowSize)
                {
                    sum -= nums[i - windowSize]; // remove the oldest element if window overflows
                }

                if(i >= windowSize - 1)
                {

                    // check if the current window is the solution
                    if (sum == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}

