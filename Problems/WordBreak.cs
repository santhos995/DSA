using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    //https://leetcode.com/problems/word-break/
    internal class WordBreakClass
    {
        public bool WordBreak(string s, IList<string> wordDict)
        {

            bool[] dp = new bool[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                foreach (var str in wordDict)
                {
                    if (i >= str.Length - 1)
                    {
                        if (s.Substring(i - str.Length + 1, str.Length) == str && ((i-str.Length) <0 || dp[i - str.Length]))
                            dp[i] = true;
                    }
                }
            }
            return dp[s.Length - 1];
        }
    }
    
}
