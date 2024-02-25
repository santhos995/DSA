using System;
namespace csprojects
{
	public class MaxOperationSameScore
	{
        
            public int MaxOperations(int[] nums)
            {
                int n = nums.Length;
                if (n == 2) return 1;
                
            int[,] dp = new int[n, n];
            initialize(dp, -1, n);
            int max1 = 1+ calculate(nums, 2, n - 1, nums[0] + nums[1], dp);
            int max2 = 1+ calculate(nums, 1, n - 2, nums[0] + nums[n - 1], dp);
            int max3 = 1+ calculate(nums, 0, n - 3, nums[n - 2] + nums[n - 1], dp);
            //Console.WriteLine($"{max1}:{max2}:{max3}");
            return Math.Max(max1, Math.Max(max2, max3));
        }
//17876942274
//2147483647
        private void initialize(int[,] dp, int v, int n)
        {
            
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    dp[i, j] = v;
                }
            }
        }

        int calculate(int[] nums, int st, int ed, int val, int[,] dp)
        {

            if (st>=ed) return 0;
            if (dp[st, ed] != 0) return dp[st, ed];
            int max = 0;

            if (((nums[st] + nums[st + 1]) == val))
            {
                max = Math.Max(max, 1 + calculate(nums, st + 2, ed, val, dp));
            }
             if((nums[st] + nums[ed]) == val) {
                max = Math.Max(max, 1 + calculate(nums, st + 1, ed - 1, val, dp));
            }
                if((nums[ed - 1] + nums[ed]) == val)
            {
                max = Math.Max(max, 1 + calculate(nums, st, ed - 2, val, dp));
            }


            return dp[st, ed] = max;
            }
        
    }
}

