public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        int m = text1.Length, n = text2.Length;
        int[,] dp= new int[m+1,n+1];
        string s1 = text1,s2=text2;
        
        for(int i=0;i<=m;i++){
            for(int j=0;j<=n;j++){
                if(i==0 || j==0)
                    dp[i,j] = 0;
                else{
                    int index1 = i-1, index2 = j-1;//indexes are used to compare
                    int inc = (s1[index1]==s2[index2])?1:0;
                    
                    dp[i,j] = Math.Max(dp[i-1,j-1]+inc, Math.Max(dp[i-1,j],dp[i,j-1]));
                }
            }
        }
        //Print2DArray<int>(dp);
        return dp[m,n];
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
}