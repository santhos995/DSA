public class Solution {
    char[][] ar;
    int[,] memo;
    int max = -1;
    public int MaximalSquare(char[][] matrix) {
        ar=matrix;
        memo = GetNew2DArray<int>(matrix.Length, matrix[0].Length,-1);
        dp(0,0);
        //Print2DArray(memo);
        return max*max;
    }
    
    private int dp(int i, int j){
        int m = ar.Length;
        int n = ar[0].Length;
        
        if(i==m || j==n)
        {
          return 0;
        } 
        if(memo[i,j]!=-1)
            return memo[i,j];
               
        
        if(ar[i][j]=='0'){
            memo[i,j] = 0;
            dp(i+1,j+1);
            dp(i,j+1);
            dp(i+1,j);
        }
        else{
            memo[i,j] = 1+Math.Min(dp(i+1,j+1), Math.Min(dp(i,j+1),dp(i+1,j)));
        }
        max = Math.Max(max, memo[i,j]);
        
        return memo[i,j];
    }
    
    public static void Print2DArray<T>(T[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i,j] + "\t");
            }
            Console.WriteLine();
        }
    }
    
    public static T[,] GetNew2DArray<T>(int x, int y, T initialValue)
    {
        T[,] nums = new T[x, y];
        for (int i = 0; i < x * y; i++) nums[i % x, i / x] = initialValue;
        return nums;
    }
}