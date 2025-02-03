using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.TwoPointers.Strings
{
    internal class ReverseStringSolver
    {
        public void ReverseString(char[] s)
        {
            int n = s.Length;
            int left = 0;
            int right = n - 1;
            while (left < right)
            {
                swap(s, left, right);
                left++;
                right--;
            }
        }

        private void swap(char[] s, int left, int  right)
        {
            char temp = s[left];
            s[left] = s[right];
            s[right] = temp;
        }
    }
}
