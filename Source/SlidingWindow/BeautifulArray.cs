using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.SlidingWindow
{
    internal class BeautifulArray
    {
        public int[] GetSubarrayBeauty(int[] nums, int k, int x)
        {
            IList<int> result = new List<int>();
            Dictionary<int , int > keyValuePairs = new Dictionary<int , int>();
            int windowSize = k;
            for (int i = 0; i < nums.Length; i++)
            {
                // add current 
                keyValuePairs[nums[i]] = keyValuePairs.GetValueOrDefault(nums[i], 0) + 1;
                if( i >= windowSize )
                {
                    keyValuePairs[nums[i - windowSize]]--;
                    if (keyValuePairs[nums[i - windowSize]] == 0)
                    {
                        keyValuePairs.Remove(nums[i - windowSize]);
                    }
                }
                // window calculated
                if (i >= windowSize - 1)
                {
                    result.Add(CalculateXth(keyValuePairs, x));
                }
            }
            return result.ToArray();
        }

        private int CalculateXth(Dictionary<int, int> keyValuePairs, int x)
        {
            int rem = x;
            for(int i =  -50; i < 0; i++)
            {
                if (keyValuePairs.ContainsKey(i))
                {
                    if (rem > keyValuePairs[i])
                    {
                        rem -= keyValuePairs[i];
                    }
                    else
                    {
                        return rem;
                    }

                }
                
            }
            return 0;
        }

        public int MaxScore(int[] cardPoints, int k)
        {
            if( cardPoints == null  || cardPoints.Length == 0) return 0;

            var totalSum = 0;
            for(int i =0 ; i < cardPoints.Length; i++) { totalSum += cardPoints[i];  }

            var windowSize = cardPoints.Length - k;
            var windowSum = 0;
            int ans = 0; 
            for (int i = 0 ; i < cardPoints.Length; i++)
            {
                windowSum += cardPoints[i];
                if( i >= windowSize )
                {
                    windowSum -= cardPoints[i - windowSize];
                }
                // window calculated here
                if( i >= windowSize -1)
                {
                    ans = Math.Max(ans, totalSum - windowSum);
                }
            }
            return ans;

        }
    }
}
