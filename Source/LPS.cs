using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions
{
    public class LPS
    {
        public string LongestPalindrome(string s)
        {
            if (s == null || s.Length < 1)
            {
                return "";
            }
            int start = 0, end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int len1 = ExpandAroundCenter(s, i, i);
                int len2 = ExpandAroundCenter(s, i, i + 1);
                int len = Math.Max(len1, len2);
                if (len > end - start)
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }
            return s.Substring(start, end - start + 1);

        }

        private int ExpandAroundCenter(string s, int i1, int i2)
        {
            while(i1>= 0 && i2 < s.Length && s[i1] == s[i2])
            {
                i1--;
                i2++;
            }
            return i2 - i1 - 1;
        }
    }
}
