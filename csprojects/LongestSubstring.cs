//LC #3 - https://leetcode.com/problems/longest-substring-without-repeating-characters/

//aabcabcaa
//bbb
//aeweka
public class LongestSubstring {
    public int LengthOfLongestSubstring(string s) {
        Dictionary<char,int> chars = new();
        int st = 0, ed = 0;
    int max = 1;
        for (st = 0;  st < s.Length;st++ )
        {
            if(chars.ContainsKey(s[st])){
                ed = Math.Max(ed, chars[s[st]]+1);
            }
            chars[s[st]] = st;
            max = Math.Max(max, st - ed+1);
        }
        return max;
    }
}