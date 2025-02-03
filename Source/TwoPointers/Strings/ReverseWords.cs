using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.TwoPointers.Strings
{
    internal class ReverseWordsSolver
    {
        public string ReverseWords(string s)
        {
            s = s.Trim();
            string[] strings = s.Split(' ');
            strings = strings.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            int left = 0;
            int right = strings.Length - 1;
            while (left < right)
            {
                swap(strings, left, right);
                left++;
                right--;
            }
            return string.Join(" ", strings);
        }

        private void swap(string[] strings, int left, int right)
        {
            string temp = strings[left];
            strings[left] = strings[right];
            strings[right] = temp;
        }
    }
}
