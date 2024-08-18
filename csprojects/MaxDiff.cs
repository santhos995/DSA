public class MaxDiff
{
    public int MaxDistance(IList<IList<int>> arrays)
    {
        int n = arrays.Count;
        int[] prefixMin = new int[n];
        int[] suffixMin = new int[n];

        int min = int.MaxValue;
        prefixMin[0] = min;
        for (int i = 1; i < n; i++)
        {
            if (arrays[i - 1][0] < min)
            {
                min = arrays[i - 1][0];
            }
            prefixMin[i] = min;
        }

        min = int.MaxValue;
        suffixMin[n - 1] = min;
        for (int i = n - 2; i >= 0; i--)
        {
            if (arrays[i + 1][0] < min)
            {
                min = arrays[i + 1][0];
            }
            suffixMin[i] = min;
        }


        //Max
        int[] prefixMax = new int[n];
        int[] suffixMax = new int[n];

        int max = int.MinValue;
        prefixMax[0] = max;
        for (int i = 1; i < n; i++)
        {
            int len = arrays[i - 1].Count;
            if (arrays[i - 1][len - 1] > max)
            {
                max = arrays[i - 1][len - 1];
            }
            prefixMax[i] = max;
        }

        max = int.MinValue;
        suffixMax[n - 1] = max;
        for (int i = n - 2; i >= 0; i--)
        {
            int len = arrays[i + 1].Count;
            if (arrays[i + 1][len - 1] > max)
            {
                max = arrays[i + 1][len - 1];
            }
            suffixMax[i] = max;
        }


        //Merge min and max
        int[] minArr = new int[n];
        int[] maxArr = new int[n];

        int maxDiff = 0;
        for (int i = 0; i < n; i++)
        {
            minArr[i] = Math.Min(prefixMin[i], suffixMin[i]);
            maxArr[i] = Math.Max(prefixMax[i], suffixMax[i]);
            maxDiff = Math.Max(maxDiff, Math.Abs(maxArr[i] - minArr[i]));
        }

        return maxDiff;
    }
}