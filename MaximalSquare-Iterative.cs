public class Solution {
    public int MaximalSquare(char[][] matrix) {
        int m = matrix.Length;
        int n = matrix[0].Length;
       
        int[,] dp = new int[m+1,n+1];
        int max = -1;

        for(int i=m-1;i>=0;i--){
            for(int j=n-1;j>=0;j--){
                if(matrix[i][j]=='0')
                    dp[i,j] = 0;
                else{
                    dp[i,j] = 1+Math.Min(dp[i+1,j+1], Math.Min(dp[i,j+1],dp[i+1,j]));
                    
                }
                max = Math.Max(max,dp[i,j]);
            }
        }       
        return max*max;
    }
   
}