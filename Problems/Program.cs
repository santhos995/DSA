public class Solution
{
    //public static void Main(string[] st)
    //{
    //    Solution s = new Solution();
    //    s.MaxProfit();
    //}
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