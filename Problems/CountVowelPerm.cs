using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    internal class CountVowelPerm
    {
        public int CountVowelPermutation(int n)
        {
            if (n == 1)
                return 5;
            int[,] dp = new int[n, 5];
            for (int i = 0; i < 5; i++)
            {
                dp[0, i] = 1;
            }
            int sum = 0;
            int mod = (int)(Math.Pow(10, 9) + 7);
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    int val;
                    if (j == 0)
                        val = dp[i - 1, 1];
                    else if (j == 1)
                        val = (dp[i - 1, 0] + dp[i - 1, 2]) % mod;
                    else if (j == 2)
                        val = ((dp[i - 1, 0] + dp[i - 1, 1]) % mod + (dp[i - 1, 3] + dp[i - 1, 4]) % mod) % mod;
                    else if (j == 3)
                        val = (dp[i - 1, 2] + dp[i - 1, 4]) % mod;
                    else
                        val = dp[i - 1, 0];
                    dp[i, j] = val;
                    //Console.WriteLine($"{j}=={dp[i,j]}");
                    if (i == n - 1)
                    {
                        sum = (sum + dp[i, j]) % mod;

                    }
                }
            }
            return sum;
        }

    }
}
