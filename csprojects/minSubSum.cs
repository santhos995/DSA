public class Solution4 {
    public int SumSubarrayMins(int[] arr) {
        int n = arr.Length;
        int[,] dp = GetNew2DArray(n,n,-1);

        for (int i = 0; i < n; i++)
        {
            dp[i,i] = arr[i];
            int min = arr[i];
            for (int j = i+1; j < n; j++)
            {
                min = Math.Min(min, arr[j]);
                dp[i,j] = min;
            }
        }

        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                sum += dp[i,j];
            }
        }
        return sum;
    }
     public static T[,] GetNew2DArray<T>(int x, int y, T initialValue)
{
    T[,] nums = new T[x, y];
    for (int i = 0; i < x * y; i++) nums[i % x, i / x] = initialValue;
    return nums;
}
}