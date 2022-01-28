using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public class UniquePath
    {
        public int UniquePaths(int m, int n)
        {
            int[] dp = new int[n];
            Array.Fill(dp, 1);
            int prev = 1;//it is also base case
            for (int i = 1; i < m; i++)
            {
                prev = 1;//reset here for every row
                for (int j = 1; j < n; j++)
                {
                    int ways  = prev + dp[j];
                    dp[j] = ways;
                    prev = ways;
                }
            }
            return dp[n - 1];
        }
    }
}
