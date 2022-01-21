public class Solution {
    int[,] memo;
    string s1, s2;
    public int LongestCommonSubsequence(string text1, string text2) {
        memo = GetNew2DArray<int>(text1.Length,text2.Length,-1);
        s1 = text1;
        s2 = text2;
        return dp(text1.Length -1 ,text2.Length-1);
    }
    private int dp(int i, int j)
    {
        if(i<0 || j< 0 || i==s1.Length || j==s2.Length)
            return 0;
        if(memo[i,j]!=-1)
            return memo[i,j];
        else
        {  
            int inc=0;
            if(s1[i]==s2[j])
            {
                inc = 1;
                Console.WriteLine($"i - {i}, j - {j}");
            }
            
            memo[i,j] =  Math.Max(dp(i-1,j-1)+inc, Math.Max(dp(i, j-1), dp(i-1,j)));
        }
        Console.WriteLine($"i - {i}, j - {j}, {memo[i,j]}");
        return memo[i,j];
    }
    public static T[,] GetNew2DArray<T>(int x, int y, T initialValue)
{
    T[,] nums = new T[x, y];
    for (int i = 0; i < x * y; i++) nums[i % x, i / x] = initialValue;
    return nums;
}
}