public class Solution {
    //[-2,1,-3,4,-1,2,1,-5,4]
    public int MaxSubArray(int[] nums, int k) {
        int n = nums.Length, st=0,ed=0;
        
        List<int[]> res = new List<int[]>();
        for(int i=0;i<n;i++){
            for (int j = i+1; j < n; j++)
            {
                if(Math.Abs(nums[i]-nums[j])==k){
                    res.Add(new int[]{i,j});
                }
            }
        }    

        int[] dp = new int[n];
        dp[0] = nums[0];    
        int max = 0;
        //[-1,3,2,4,5], k=3

        return max;//Not properly solved
    }
}