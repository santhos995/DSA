using System;
namespace csprojects
{
    public class BrickAndLadder
    {
        public int FurthestBuilding(int[] heights, int bricks, int ladders)
        {
            int n = heights.Length;
            int[,,] memo = new int[n, bricks, ladders ];
            return furtherCalc(heights, 0, bricks, ladders, memo);
        }
        int furtherCalc(int[] heights, int i, int bricks, int ladder, int[,,] memo)
        {
            int n = heights.Length;
            if (i >= n - 1) return 0;

            if (memo[i, bricks, ladder] != 0) return memo[i, bricks, ladder];
            if (heights[i] >= heights[i + 1])
                return 1 + furtherCalc(heights, i + 1, bricks, ladder, memo);

            if (ladder == 0 && (bricks == 0 || bricks < (heights[i + 1] - heights[i]))) return 0;

            int path1 = 0;
            if (bricks >= (heights[i + 1] - heights[i]))
                path1 = 1 + furtherCalc(heights, i + 1, bricks - (heights[i + 1] - heights[i]), ladder, memo);//chosing bricks
            int path2 = 0;
            if (ladder > 0)
                path2 = (1 + furtherCalc(heights, i + 1, bricks, ladder - 1, memo));//choosing ladder

            return memo[i, bricks, ladder] = Math.Max(path1, path2);
        }
    }
}

