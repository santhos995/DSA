using System;
public class Solution {
    public int NumberOfPairs(int[][] points) {
        int n = points.Length;
        Array.Sort(points, new Comparison<int[]>(
            (x,y)=> x[0]<y[0] ? -1 : (x[0]==y[0])? ((x[1]<y[1])?-1:1):1;
            ));
        
        for (int i = 0; i < n; i++)
        {
            System.Console.WriteLine($"{points[i][0]}--{points[i][1]}");
        }
    }

}