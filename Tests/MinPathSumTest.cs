using System;
using Xunit;

namespace Solutions.Tests
{
  public class MinPathSumSolutionTests
  {
    [Fact]
    public void MinPathSum_SingleElementGrid_ReturnsElementValue()
    {
      var solution = new MinPathSumSolution();
      int[][] grid = new int[][] { new int[] { 5 } };
      int result = solution.MinPathSum(grid);
      Assert.Equal(5, result);
    }

    [Fact]
    public void MinPathSum_TwoByTwoGrid_ReturnsMinPathSum()
    {
      var solution = new MinPathSumSolution();
      int[][] grid = new int[][]
      {
        new int[] { 1, 3 },
        new int[] { 1, 5 }
      };
      int result = solution.MinPathSum(grid);
      Assert.Equal(7, result);
    }

    [Fact]
    public void MinPathSum_ThreeByThreeGrid_ReturnsMinPathSum()
    {
      var solution = new MinPathSumSolution();
      int[][] grid = new int[][]
      {
        new int[] { 1, 3, 1 },
        new int[] { 1, 5, 1 },
        new int[] { 4, 2, 1 }
      };
      int result = solution.MinPathSum(grid);
      Assert.Equal(7, result);
    }

    [Fact]
    public void MinPathSum_EmptyGrid_ReturnsZero()
    {
      var solution = new MinPathSumSolution();
      int[][] grid = new int[][] { };
      int result = solution.MinPathSum(grid);
      Assert.Equal(0, result);
    }
  }
}