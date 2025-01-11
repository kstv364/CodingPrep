using Solutions;
using Xunit;

namespace Tests
{
    public class LPSTest
    {
        [Theory]
        [InlineData("babad", "bab")]
        [InlineData("cbbd", "bb")]
        [InlineData("a", "a")]
        [InlineData("ac", "c")]
        [InlineData("racecar", "racecar")]
        public void LongestPalindrome_ShouldReturnExpectedResult(string input, string expected)
        {
            // Arrange
            var lps = new LPS();

            // Act
            var result = lps.LongestPalindrome(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
