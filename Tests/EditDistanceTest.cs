namespace Solutions.Tests
{
    public class EditDistanceTest
  {
    [Theory]
    [InlineData("horse", "ros", 3)]
    [InlineData("intention", "execution", 5)]
    [InlineData("abc", "yabd", 2)]
    [InlineData("", "", 0)]
    [InlineData("a", "", 1)]
    [InlineData("", "a", 1)]
    public void CalculateDistance_ShouldReturnExpectedResult(string word1, string word2, int expected)
    {
      // Arrange
      var editDistance = new EditDistance(word1, word2);

      // Act
      var result = editDistance.CalculateDistance();

      // Assert
      Assert.Equal(expected, result);
    }
  }
}