//Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.

//You have the following three operations permitted on a word:

//Insert a character
//Delete a character
//Replace a character


//Example 1:

//Input: word1 = "horse", word2 = "ros"
//Output: 3
//Explanation:
//horse->rorse(replace 'h' with 'r')
//rorse->rose(remove 'r')
//rose->ros(remove 'e')
namespace Solutions
{
    public class EditDistance
    {
        private string _word1;
        private string _word2;
        private int[,] _dp;

        public EditDistance(string word1, string word2)
        {
            _word1 = word1;
            _word2 = word2;
            _dp = new int[_word1.Length + 1, _word2.Length + 1];
        }

        public int CalculateDistance()
        {
            InitializeDP();
            ComputeEditDistance();
            return _dp[_word1.Length, _word2.Length];
        }

        private void InitializeDP()
        {
            for (int i = 0; i <= _word1.Length; i++)
            {
                _dp[i, 0] = i;
            }
            for (int j = 0; j <= _word2.Length; j++)
            {
                _dp[0, j] = j;
            }
        }

        private void ComputeEditDistance()
        {
            for (int i = 1; i <= _word1.Length; i++)
            {
                for (int j = 1; j <= _word2.Length; j++)
                {
                    if (_word1[i - 1] == _word2[j - 1])
                    {
                        _dp[i, j] = _dp[i - 1, j - 1];
                    }
                    else
                    {
                        _dp[i, j] = 1 + Math.Min(_dp[i - 1, j - 1], Math.Min(_dp[i - 1, j], _dp[i, j - 1]));
                    }
                }
            }
        }
    }
}
