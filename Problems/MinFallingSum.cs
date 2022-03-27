using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    internal class MinFallingSum
    {
        public int MinFallingPathSum(int[][] g)
        {
            int m = g.Length;
            int n = g[0].Length;

            int[,] dp = new int[m, n];

            dp[0, 0] = g[0][0];
            int min = int.MaxValue;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0)
                    {
                        if (j > 0)
                            dp[i, j] = g[i][j];
                    }
                    else if (j == 0)
                    {
                        if (i > 0)
                            dp[i, j] = g[i][j] + Math.Min(dp[i - 1, j],dp[i-1,j+1]);
                    }
                    else
                    {
                        dp[i, j] = g[i][j] + Math.Min(get(dp,i - 1, j - 1), Math.Min(get(dp,i - 1, j), get(dp,i - 1, j + 1)));
                    }
                    if (i == m - 1)
                        min = Math.Min(min, dp[i, j]);
                }
            }
            //Print2DArray(dp);
            return min;
        }
        public static void Print2DArray<T>(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        int get(int[,] dp, int row, int col)
        {
            if (row < 0 || col < 0 || row>= dp.GetLength(0) || col >=dp.GetLength(0))
                return int.MaxValue;
            return dp[row,col];
        }
    }
}
