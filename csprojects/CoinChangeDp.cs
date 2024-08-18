public class CoinChangeDP {
    public int CoinChange(int[] coins, int amount) {
        int n = coins.Length;
        int[,] dp = GetNew2DArray<int>(amount+1, n, int.MaxValue);

        for(int i =0;i<coins.Length;i++){
            if(amount<=coins[i]){

                dp[coins[i],i] = 1;
            }
        }

        for(int i =0;i<coins.Length;i++){
            for (int amt = 1;amt<=amount;amt++){
                dp[amt, i] = int.MaxValue;
                if(i>0){
                    dp[amt, i] = Math.Min(dp[amt, i], dp[amt, i-1]);
                    if(amt>=coins[i] && dp[amt-coins[i],i-1]!=int.MaxValue){
                        dp[amt, i] = Math.Min(dp[amt, i], 1+dp[amt-coins[i],i-1]);
                    }

                }
                if(amt>=coins[i]&& dp[amt-coins[i],i]!=int.MaxValue){//current coin
                        dp[amt, i] = Math.Min(dp[amt, i], 1+dp[amt-coins[i],i]);
                }

            }
        }
        return dp[amount,n-1]==int.MaxValue?-1:dp[amount,n-1];
    }

    public static T[,] GetNew2DArray<T>(int x, int y, T initialValue)
{
    T[,] nums = new T[x, y];
    for (int i = 0; i < x * y; i++) nums[i % x, i / x] = initialValue;
    return nums;
}
}