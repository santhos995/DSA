using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    internal class LIS
    {
        //https://leetcode.com/problems/longest-increasing-subsequence/
        public int LengthOfLIS(int[] nums)
        {
            //[10,9,2,5,3,7,101,18]
            int[] dp = new int[nums.Length];

            Array.Fill(dp, 1);
            int totalMax = int.MinValue;
            for (int i = 1; i < nums.Length; i++)
            {
                int max = int.MinValue;
                for (int j = i-1; j >=0; j--)
                {
                    if (nums[i] > nums[j])
                        max = Math.Max(max, dp[j] + 1);
                }
                dp[i] = (max==int.MinValue)?1:max;
                totalMax = Math.Max(totalMax, dp[i]);
            }
            return (totalMax == int.MinValue) ? 1 : totalMax;
        }
    }
}
