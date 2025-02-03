
namespace Solutions.TwoPointers.Strings
{
    internal class ValidPalindromeByRemoving1
    {
        public bool ValidPalindrome(string s)
        {
            int l = 0, r = s.Length - 1;
            while (l < r)
            {
                if (s[l] == s[r])
                {
                    l++;
                    r--;
                }
                else
                {
                    var op1 = IsPalindrome(s, l, r - 1);
                    var op2 = IsPalindrome(s, l + 1, l);
                    return op1 || op2;
                }

            }
            return true;
        }

        private bool IsPalindrome(string s, int l, int r)
        {
            while (l < r)
            {
                if (s[l] != s[r]) return false;
                l++;
                r--;
            }
            return true;
        }
    }
}
