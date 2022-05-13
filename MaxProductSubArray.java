

public class MaxProductSubArray {
    public int maxProduct(int[] nums) {
        
        int min = nums[0];
        int max = nums[0];
        int totalMax = max;
        for (int i = 1; i < nums.length; i++) {
            int x = min*nums[i];
            int y = max*nums[i];
            min = Math.min(x, Math.min(y, nums[i]));
            max = Math.max(x,Math.max(y, nums[i]));
            totalMax = Math.max(totalMax, max);
        }
        return totalMax;
    }
}
