using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.TwoPointers.Strings
{
    internal class ReverseVowelsSolver
    {
        public string ReverseVowels(string s)
        {
            var charr = s.ToCharArray();
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                if (!IsVowel(charr[left]))
                {
                    left++;
                    continue;
                }
                if (!IsVowel(charr[right]))
                {
                    right--;
                    continue;
                }
                swap(charr, left, right);
                left++;
                right--;
            }
            return new string(charr);
        }

        private void swap(char[] charr, int left, int right)
        {

            char temp = charr[left];
            charr[left] = charr[right];
            charr[right] = temp;
        }

        private bool IsVowel(char v)
        {
            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            return vowels.Contains(v);
        }
    }
}
