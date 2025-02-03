using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Given a 0-indexed string word and a character ch, reverse the segment of word that starts at index 0 and ends at the index of the first occurrence of ch (inclusive). If the character ch does not exist in word, do nothing.

//For example, if word = "abcdefd" and ch = "d", then you should reverse the segment that starts at 0 and ends at 3 (inclusive). The resulting string will be "dcbaefd".
//Return the resulting string.
namespace Solutions.TwoPointers.Strings
{
    internal class ReversePrefixSolver
    {
        public string ReversePrefix(string word, char ch)
        {
            int right = word.IndexOf(ch);
            int left = 0;

            if (right == -1)
            {
                return word;
            }

            char[] s = word.ToCharArray();
            while (left < right)
            {
                swap(s, left, right);
                left++;
                right--;
            }
            return new string(s);
        }

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

        private void swap(char[] s, int left, int right)
        {
            char temp = s[left];
            s[left] = s[right];
            s[right] = temp;
        }
    }
}
