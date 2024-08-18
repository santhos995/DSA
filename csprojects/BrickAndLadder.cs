using System;
namespace csprojects
{
    public class BrickAndLadder
    {
        public int FurthestBuilding(int[] heights, int bricks, int ladders)
        {
            int n = heights.Length;
            Dictionary<string, int> memo = new();
            return furtherCalc(heights, 0, bricks, ladders, memo);
        }
        int furtherCalc(int[] heights, int i, int bricks, int ladder, Dictionary<string, int> memo)
        {
            int n = heights.Length;
            if (i >= n - 1) return 0;
            string key = $"{i}:{bricks}:{ladder}";
            if (memo.ContainsKey(key)) return memo[key];
            if (heights[i] >= heights[i + 1])
                return 1 + furtherCalc(heights, i + 1, bricks, ladder, memo);

            if (ladder == 0 && (bricks == 0 || bricks < (heights[i + 1] - heights[i]))) return 0;

            int path1 = 0;
            if (bricks >= (heights[i + 1] - heights[i]))
                path1 = 1 + furtherCalc(heights, i + 1, bricks - (heights[i + 1] - heights[i]), ladder, memo);//chosing bricks
            int path2 = 0;
            if (ladder > 0)
                path2 = (1 + furtherCalc(heights, i + 1, bricks, ladder - 1, memo));//choosing ladder

            memo.Add(key, Math.Max(path1, path2));
            return memo[key];
        }
    }
}

