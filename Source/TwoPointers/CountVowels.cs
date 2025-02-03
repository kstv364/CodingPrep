using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.TwoPointers
{
    internal class CountVowels
    {
        public int[] VowelStrings(string[] words, int[][] queries)
        {
            int[] result = new int[queries.Length];
            int[] prefixCount = new int[words.Length + 1];

            for (int i = 0; i < words.Length; i++)
            {
                prefixCount[i+1] = prefixCount[i] + (IsFulfilled(words[i]) ? 1 : 0);
            }

            for (int i = 0; i < queries.Length; i++)
            {
                int left = queries[i][0];
                int right = queries[i][1];
                result[i] = prefixCount[right+1] - prefixCount[left];

            }
            return result;
        }

        private bool IsFulfilled(string v)
        {
            // starts and ends with vowel
            if(v.Length < 1 )
            {
                return false;
            }
            if (v[0] == 'a' || v[0] == 'e' || v[0] == 'i' || v[0] == 'o' || v[0] == 'u')
            {
                if (v[v.Length - 1] == 'a' || v[v.Length - 1] == 'e' || v[v.Length - 1] == 'i' || v[v.Length - 1] == 'o' || v[v.Length - 1] == 'u')
                {
                    return true;
                }
            }
            return false;

        }
    }
}
