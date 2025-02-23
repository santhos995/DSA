//LC #76 - https://leetcode.com/problems/minimum-window-substring/?envType=study-plan-v2&envId=top-100-liked

using System.Reflection.PortableExecutable;

public class MinWindowSubString {
    public string MinWindow(string s, string t) {
        Dictionary<char, int> smap = new Dictionary<char, int>();
        Dictionary<char, int> tmap = new Dictionary<char, int>();
/*
        for (int i = 0;i<s.Length;i++){
            char c = s[i];
            if(!smap.ContainsKey(c)){
                smap.Add(c,0);
            }
            smap[c]++;
        }
*/
        for (int i = 0;i<t.Length;i++){
            char c = t[i];
            if(!tmap.ContainsKey(c)){
                tmap.Add(c,0);
            }
            tmap[c]++;
        }
        int windowStart, windowEnd = 0;
        int matched = 0;
        int minWindow = int.MaxValue;
        string minStr = "";
        for(windowStart=0;windowStart<s.Length;windowStart++){
            char c = s[windowStart];
            if(!smap.ContainsKey(c)){
                smap.Add(c,0);
            }
            smap[c]++;

            if(tmap.ContainsKey(c) && smap[c]==tmap[c]){
                matched += smap[c];
                if(matched==t.Length && minWindow>windowStart-windowEnd+1){
                    minWindow = Math.Min(minWindow, windowStart-windowEnd +1);
                    minStr = s.Substring(windowEnd, windowStart-windowEnd+1);
                }
            }

            while(matched==t.Length && windowEnd<windowStart){
                char ch = s[windowEnd];
                if(tmap.ContainsKey(ch) && tmap[ch]==smap[ch]){
                    matched -= tmap[ch];
                }
                smap[ch]--;
                windowEnd++;
                if(matched==t.Length&& minWindow>windowStart-windowEnd+1){
                 minWindow = Math.Min(minWindow, windowStart-windowEnd +1);   
                 minStr = s.Substring(windowEnd, windowStart-windowEnd+1);
                }
            }
        }
        return minStr;
    }
}