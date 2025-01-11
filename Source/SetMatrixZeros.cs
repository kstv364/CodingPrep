using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions
{
    internal class SetMatrixZeros
    {
        public void SetZeroes(int[][] matrix)
        {
            bool firstRowHasZero = false;
            bool firstColumnHasZero = false;

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        if (i == 0)
                        {
                            firstRowHasZero = true;
                        }
                        if (j == 0)
                        {
                            firstColumnHasZero = true;
                        }
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;
                    }
                }
            }

            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 1; j < matrix[i].Length; j++)
                {
                    if (matrix[i][0] == 0 || matrix[0][j] == 0)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            if (firstRowHasZero)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    matrix[0][j] = 0;
                }
            }

            if (firstColumnHasZero)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    matrix[i][0] = 0;
                }
            }   

        }

    }
}
