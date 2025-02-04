using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.SlidingWindow
{
    internal class GoodSubstrings
    {
        public int CountGoodSubstrings(string s)
        {
            if(s.Length < 3) return 0;
            int ans = 0;
            for (int i = 0; i <= s.Length-3; i++)
            {
                string sub = s.Substring(i, 3);
                // count unique characters
                int count = sub.Distinct().Count();
                if(count == 3)
                {
                    ans++;
                }

            }
            return ans;

        }

        public IList<int> FindAnagrams(string s, string p)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            foreach (var c in p)
            {
                map[c] = map.GetValueOrDefault(c, 0) + 1;
            }
            Dictionary<char, int> window = new Dictionary<char, int>();
            List<int> ans = new List<int>();
            for(int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                window[c] = window.GetValueOrDefault(c, 0) + 1;
                if (i >= p.Length)
                {
                    char left = s[i - p.Length];
                    window[left]--;
                    if (window[left] == 0)
                    {
                        window.Remove(left);
                    }
                }
                if (i >= p.Length - 1)
                {
                    if (IsAnagram(map, window))
                    {
                        ans.Add(i - p.Length + 1);
                    }
                }
            }
            return ans;

        }

        private bool IsAnagram(Dictionary<char, int> map, Dictionary<char, int> window)
        {
            foreach (var key in map.Keys)
            {
                if (!window.ContainsKey(key) || window[key] != map[key])
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckInclusion(string s1, string s2)
        {
            if(s1.Length > s2.Length) return false;
            Dictionary<char, int> map = new Dictionary<char, int>();
            foreach (var c in s1)
            {
                map[c] = map.GetValueOrDefault(c, 0) + 1;
            }
            Dictionary<char, int> window = new Dictionary<char, int>();
            for (int i = 0; i < s2.Length; i++)
            {
                char c = s2[i];
                window[c] = window.GetValueOrDefault(c, 0) + 1;
                if (i >= s1.Length) // window size is greater than s1
                {
                    char left = s2[i - s1.Length];
                    window[left]--;
                    if (window[left] == 0)
                    {
                        window.Remove(left);
                    }
                }
                if (i >= s1.Length - 1)
                {
                    if (IsAnagram(map, window))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool HasAllCodes(string s, int k)
        {
            int windowSize = k;
            HashSet<string> set = new HashSet<string>();
            for (int i = 0; i <= s.Length - windowSize; i++)
            {
                string sub = s.Substring(i, windowSize);
                set.Add(sub);
            }
            return set.Count == Math.Pow(2, k);
        }

        public int MaxVowels(string s, int k)
        {
            int windowSize = k;
            int vowels = 0;
            int ans = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                vowels += IsVowel(c) ? 1 : 0;
                if(i >= windowSize)
                {
                    char left = s[i - windowSize];
                    vowels -= IsVowel(left) ? 1 : 0;
                }

                if(i >= windowSize - 1)
                {
                    ans = Math.Max(ans, vowels);
                }
            }
            return ans;

        }

        private bool IsVowel(char c)
        {
            return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
        }
    }

  

    
}
