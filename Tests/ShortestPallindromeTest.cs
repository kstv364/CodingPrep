using Solutions;
using Xunit;

namespace Tests
{
    public class ShortestPallindromeTest
    {
        [Theory]
        [InlineData("aacecaaa", "aaacecaaa")]
        [InlineData("abcd", "dcbabcd")]
        [InlineData("", "")]
        [InlineData("a", "a")]
        [InlineData("aa", "aa")]
        public void ShortestPalindrome_ShouldReturnExpectedResult(string input, string expected)
        {
            // Arrange
            var shortestPallindrome = new ShortestPallindrome();

            // Act
            var result = shortestPallindrome.GetShortestPalindrome(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
