namespace Solutions.TwoPointers.Strings
{
    internal class PallindromeByMinReplacements
    {
        public string MakeSmallestPalindrome(string s)
        {
            if(s.Length == 0) return s;

            char[] chars = s.ToCharArray();
            int start = 0, end = s.Length - 1;
            while(start < end)
            {
                if (chars[start] != chars[end]) 
                {
                    if (chars[start] < chars[end]) 
                    { 
                        chars[end] = chars[start];
                    }
                    else
                    {
                        chars[start] = chars[end];
                    }
                }
                start++; end--;
            }
            return string.Join("", chars) ?? string.Empty;
        }

        public string MergeAlternately(string word1, string word2)
        {
            if(word1.Length == 0) return word2;
            if (word2.Length == 0) return word1;
            int n = word1.Length + word2.Length;
            if(n == 0) return string.Empty;

            char[] chars = new char[n];
            int p1 = 0, p2 = 0, i=0;
            bool odd = false;
            while(p1 < word1.Length && p2 < word2.Length)
            {
                if (!odd)
                {
                    chars[i++] = word1[p1++];
                }
                else
                {
                    chars[i++] = word2[p2++];
                }
            }

            while(p1 < word1.Length)
            {
                chars[i++] = word1[p1++];
            }

            while (p2 < word2.Length)
            {
                chars[i++] = word2[p2++];
            }
            return string.Join("", chars) ?? string.Empty;
        }

        public string LargestMerge(string word1, string word2)
        {
            List<char> chars = new List<char>(); 
            int i = 0, j = 0;
            while(i < word1.Length && j < word2.Length)
            {
                if (word1[i]  > word2[j])
                {
                    chars.Add(word1[i++]);
                }
                else if (word1[i] < word2[j])
                {
                    chars.Add(word2[j++]);
                }
                else
                {
                    if(string.CompareOrdinal(word1.Substring(i), word2.Substring(j)) > 0)
                    {
                        chars.Add(word1[i++]);
                    }
                    else { chars.Add(word2[j++]);}
                }
            }

            while (i < word1.Length)
            {
                chars.Add(word1[i++]);
            }

            while (j < word2.Length)
            {
                chars.Add(word2[j++]);
            }
            return new string(chars.ToArray());
        }

        public int[] ShortestToChar(string s, char c)
        {
            int[] ans = new int[s.Length];
            int curDist = Int32.MaxValue - 1;
            for (int i = 0; i < s.Length; i++)
            {
                ans[i] = Int32.MaxValue - 1;
                if (s[i] == c)
                {
                    ans[i] = 0;
                    curDist = 0;
                }
                else
                {
                    curDist = Math.Min(curDist + 1, Int32.MaxValue - 1);
                    ans[i] = Math.Min(curDist, ans[i]);
                }
            }

            curDist = Int32.MaxValue - 1;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[s.Length - 1- i] == c)
                {
                    ans[s.Length -1 -i] = 0;
                    curDist = 0;
                }
                else
                {
                    curDist = Math.Min(curDist + 1, Int32.MaxValue - 1);
                    ans[s.Length - 1- i] = Math.Min(curDist, ans[s.Length - 1 - i]);
                }
            }

            return ans;
        }
    }
}
