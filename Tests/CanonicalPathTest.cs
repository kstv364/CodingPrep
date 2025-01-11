using Solutions;
using Xunit;

namespace Tests
{
    public class CanonicalPathTest
    {
        [Theory]
        [InlineData("/home/", "/home")]
        [InlineData("/../", "/")]
        [InlineData("/home//foo/", "/home/foo")]
        [InlineData("/a/./b/../../c/", "/c")]
        [InlineData("/a/../../b/../c//.//", "/c")]
        [InlineData("/a//b////c/d//././/..", "/a/b/c")]
        public void SimplifyPath_ShouldReturnExpectedResult(string input, string expected)
        {
            // Arrange
            var canonicalPath = new CanonicalPath();

            // Act
            var result = canonicalPath.SimplifyPath(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
