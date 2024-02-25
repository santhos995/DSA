public class MinWindowClass {

    public string MinWindow(string s, string t) {
        int n = s.Length;
        int m = t.Length;
        int ed = 0, min = int.MaxValue;
        Dictionary<char,int> map = new();
        Dictionary<char,int> tmap = new();
        int stIndex = -1, edIndex = -1;

        for(int i=0;i<m;i++){
            if(!tmap.ContainsKey(t[i]))
                tmap.Add(t[i],0);
            tmap[t[i]]++;
        }

        int prevEnd = 0;
//"ADOBECODEBANC"
//"ABC"
        for(int st=0;st<n;){
            if(prevEnd == ed){//this is to skip adding the same element when ed increments and st will not change
                if(!map.ContainsKey(s[st]))
                    map.Add(s[st],0);
                map[s[st]]++;
                System.Console.WriteLine($"Incremented {map[s[st]]}");
            }

            bool found = true;
            foreach(var item in tmap){
                if(!map.ContainsKey(item.Key) || map[item.Key]<item.Value){
                    found = false;
                    break;
                }
            }
            Console.WriteLine($"outside-{st}:{ed}");
            if(found){
                Console.WriteLine($"found-{st}:{ed}");
                if((st-ed)<min){
                    min = st-ed;
                    stIndex = st;
                    edIndex = ed;
                }

                prevEnd = ed;
                ed++;
                map[s[prevEnd]]--;
                if(map[s[prevEnd]]==0)
                    map.Remove(s[prevEnd]);
            }
            else{
                st++;
                prevEnd = ed;//doing this one is enough
            }
        }
        Console.WriteLine($"{stIndex}:{edIndex}");
        return stIndex==-1?"":s.Substring(edIndex, stIndex-edIndex+1);
    }
}