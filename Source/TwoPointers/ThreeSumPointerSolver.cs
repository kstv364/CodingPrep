using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.TwoPointers
{
    internal class ThreeSumPointerSolver
    {
        public class ListComparer : IEqualityComparer<IList<int>>
        {
            public bool Equals(IList<int>? x, IList<int>? y)
            {
                if (x == null || y == null) return false;
                return x.SequenceEqual(y);
            }

            public int GetHashCode(IList<int> obj)
            {
                return obj.Aggregate(0, (acc, num) => acc ^ num.GetHashCode());
            }
        }
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            HashSet<IList<int>> set = new HashSet<IList<int>>(new ListComparer());
            for (int i = 0; i < nums.Length; i++)
            {
                int j = i + 1, k = nums.Length - 1;
                while(j < k)
                {
                    if (nums[i] + nums[j] + nums[k] == 0)
                    {
                        set.Add([nums[i], nums[j], nums[k]]);
                        j++; k--;   
                    }
                    else if(nums[i] + nums[j] + nums[k] < 0)
                    {
                        j++;
                    }
                    else
                    {
                        k--;
                    }
                }

            }
            return set.ToList();

        }
    }
}
