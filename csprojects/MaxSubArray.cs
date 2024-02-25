public class MaxSubArr {
    //[-2,1,-3,4,-1,2,1,-5,4]
    public int MaxSubArray(int[] nums) {
        int n = nums.Length;
        int[] dp = new int[n];
        dp[0] = Math.Max(0,nums[0]);    
        int max = dp[0];

        for(int i=1;i<n;i++){
            
            dp[i] = Math.Max(dp[i-1] + nums[i], nums[i]);
            max = Math.Max(max, dp[i]);
        
        }    
        return max;
    }
}