using Problems;

public class Solution
{
    public static void Main(string[] st)
    {
        UniquePath s = new UniquePath();
        Console.WriteLine(   s.UniquePaths(3, 7));
        Console.WriteLine(   s.UniquePaths(3, 2));
    }
    int[,,] memo;
    int[] p;
    int maxTrans;
    public int MaxProfit(int maxTransaction, int[] prices)
    {
        memo = new int[prices.Length, maxTransaction + 1, 2];
        p = prices;
        maxTrans = maxTransaction;
        return dp(0, 1, 0);
    }
    public int MaxProfitIterative(int k, int[] prices)
    {
        int[,,] dp = new int[prices.Length + 1, k+2, 2];

        for (int i = prices.Length-1; i >=0; i--)
        {
            for (int j = k; j > 0; j--)
            {
                int doNothing = dp[i + 1, k, 0];
                int sell = prices[i] + dp[i + 1, k + 1, 1];
                int buy = -prices[i] + dp[i + 1, k, 0];
                dp[i, j, 0] = Math.Max(doNothing, buy);
                dp[i, j, 1] = Math.Max(doNothing, sell);
            }
            
        }
        return Math.Max(dp[0, 1, 0], dp[0, 1, 1]);

    }


        /// <summary>
        /// dp method
        /// </summary>
        /// <param name="i">current index</param>
        /// <param name="k">no of transaction</param>
        /// <param name="isHolding"> 0 for not holding the stock, 1 for holding it</param>
        /// <returns></returns>
        private int dp(int i, int k, int isHolding)
    {
        if (i == p.Length || k > maxTrans)
        {
            return 0;
        }
        if (memo[i, k, isHolding] != 0)
            return memo[i, k, isHolding];
        else
        {
            int doNothing = dp(i + 1, k, isHolding);
            int buyOrSell;
            if (isHolding == 0)
            {
                //not holding, so buy
                buyOrSell = -p[i] + dp(i + 1, k, 1);
            }
            else
            {
                //holding, so sell
                buyOrSell = p[i] + dp(i + 1, k + 1, 0);
            }
            memo[i, k, isHolding] = Math.Max(doNothing, buyOrSell);

        }
        return memo[i, k, isHolding];
    }
}