using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right, which minimizes the sum of all numbers along its path.

//Note: You can only move either down or right at any point in time.
namespace Solutions
{
    public class MinPathSumSolution
    {
        public int MinPathSum(int[][] grid)
        {
            if(grid.Length == 0)
            {
                return 0;
            }
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }
                    else if (i == 0)
                    {
                        grid[i][j] += grid[i][j - 1];
                    }
                    else if (j == 0)
                    {
                        grid[i][j] += grid[i - 1][j];
                    }
                    else
                    {
                        grid[i][j] += Math.Min(grid[i - 1][j], grid[i][j - 1]);
                    }
                }
            }
            return grid[grid.Length - 1][grid[0].Length - 1];
        }

    }
}
