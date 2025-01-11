using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions
{
    public class ShortestPallindrome
    {
        public string GetShortestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;

            string rev = new string(s.Reverse().ToArray());
            string combined = s + "#" + rev;
            int[] lps = new int[combined.Length];

            for (int i = 1; i < combined.Length; i++)
            {
                int j = lps[i - 1];
                while (j > 0 && combined[i] != combined[j])
                {
                    j = lps[j - 1];
                }
                if (combined[i] == combined[j])
                {
                    j++;
                }
                lps[i] = j;
            }

            return rev.Substring(0, s.Length - lps[combined.Length - 1]) + s;
        }
    }
}
