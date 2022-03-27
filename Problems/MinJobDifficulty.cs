using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    //https://leetcode.com/problems/minimum-difficulty-of-a-job-schedule/
    public class MaxJobDifficulty
    {
        int[,] memo;
        int[] job;
        int[] maxDifficulty;
        int d;
        public int MinDifficulty(int[] jobDifficulty, int d)
        {
            job = jobDifficulty;
            memo = get2DArray(job.Length, d + 1);
            this.d = d;
            if (job.Length < d) return -1;
            preComputeMaxDifficulty();
            Console.WriteLine($"len-{job.Length}");
            return dp(0, 1);
        }
        private int[,] get2DArray(int row, int column, int defaultVal = -1)
        {
            int[,] ar = new int[row, column];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    ar[i, j] = defaultVal;
                }
            }

            return ar;
        }
        private int dp(int i, int day)
        {
            if (i == job.Length)
                return 0;

            if (memo[i, day] != -1)
                return memo[i, day];
            //Console.WriteLine($"i-{i},day-{day},m={memo[i,day]}");
            if (day == d)
            {
                memo[i, day] = maxDifficulty[i];
                return maxDifficulty[i];
            }

            int j = job.Length - (d - day);//5 - (3-1).. so <j is allowed days

            int best = int.MaxValue;
            int hardest = int.MinValue;
            //int max = int.MinValue;
            for (int k = i; k < j; k++)
            {
                hardest = Math.Max(hardest, job[k]);
                best = Math.Min(best, hardest + dp(k + 1, day + 1));
            }
            memo[i, day] = best;
            return memo[i, day];
        }
        private void preComputeMaxDifficulty()
        {
            maxDifficulty = new int[job.Length];
            int max = int.MinValue;
            for (int i = job.Length - 1; i >= 0; i--)
            {
                max = Math.Max(max, job[i]);
                maxDifficulty[i] = max;
            }
        }


        public int MinDifficultyIterative(int[] job, int d)
        {
            int[,] dp = new int[job.Length, d + 1];
            int max = int.MinValue;
            for (int i = job.Length - 1; i >= 0; i--)
            {
                max = Math.Max(max, job[i]);
                dp[i, d] = max;
            }

            for (int day = d - 1; day > 0; day--)
            {

                for (int i = 0; i < job.Length; i++)
                {

                    int highest = int.MinValue;
                    int best = int.MaxValue;

                    for (int k = day; k < job.Length - (d - day); k++)
                    {

                    }
                    highest = Math.Max(highest, job[i]);

                }
            }
            return -1;
        }
    }
}
