using System;
namespace csprojects
{
	public class SubSet_BitMap
	{

        //Rfernce - https://www.topcoder.com/thrive/articles/print-all-subset-for-set-backtracking-and-bitmasking-approach
        public void subSet_find(int[] nums)
		{
			//List<HashSet<int>> subSet = new List<HashSet<int>>();

			HashSet<int> setMax = new();
			//subsetLength would be 2^n
			Array.Sort(nums);
			for (int i = 0; i < Math.Pow(2, nums.Length); i++)//Why 2^n -> there are two possiblities for each ith number either selct or not select, so there are 2^n possiblity
			{
				int num = 0;
				for (int j = 0; j < nums.Length; j++)
				{
					if (((1 << j) & i) == (1 << j))//Very important line: Here we are checking if jth bit is set in i, if this means
						//we will include this nums[j] to our subset, if it is not set, we will skip them.
					{
						num |= nums[j];
					}
				}
				setMax.Add(num);
			}

			for (int i = 0; i < Math.Pow(2, nums.Length); i++)
			{
				if (!setMax.Contains(i))
				{
					Console.WriteLine(i);
					return;
				}
			}
			Console.WriteLine("Not found");
		}
	}
}

