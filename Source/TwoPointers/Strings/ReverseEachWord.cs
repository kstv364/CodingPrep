using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.TwoPointers.Strings
{
    public class ReverseEachWord
    {
        public string ReverseWords(string s)
        {
            s= s.Trim();
            string[] strings = s.Split(' ');
            strings = strings.Where(word => !string.IsNullOrEmpty(word)).ToArray();
            for (int i = 0; i < strings.Length; i++)
            {
                strings[i] = ReverseString(strings[i]);
            }
            return string.Join(" ", strings);
        }

        public string ReverseString(string s)
        {
            int n = s.Length;
            int left = 0;
            int right = n - 1;
            var charArray = s.ToCharArray();
            while (left < right)
            {
                swap(charArray, left, right);
                left++;
                right--;
            }
            return new string(charArray);
        }

        private void swap(char[] s, int left, int right)
        {
            char temp = s[left];
            s[left] = s[right];
            s[right] = temp;
        }

        public bool IsPalindrome(string s)
        {
            s = s.ToLower();
            char[] charr = s.Where(isAlphaNumeric).ToArray();
    

            int left = 0;
            int right = charr.Length - 1;
            while (left < right)
            {
                if (charr[left] != charr[right]) return false;
                left++;
                right--;
            }
            return true;
        }

        private bool isAlphaNumeric(char ch)
        {
           return Char.IsLetterOrDigit(ch) && !Char.IsPunctuation(ch) && !Char.IsWhiteSpace(ch);
        }
    }
}
