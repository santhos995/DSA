//LC - #360 - https://leetcode.com/problems/top-k-frequent-elements/

public class TopKFreq {
    public int[] TopKFrequent(int[] nums, int k) {
        Dictionary<int, int> map = new Dictionary<int, int>();
        foreach (int x in nums) {
            if (!map.ContainsKey(x)){
                map.Add(x, 0);
            }
            map[x]++;
        }
        HeapItr<Freq> heap = new HeapItr<Freq>(new CustomComparer());
        foreach(var pair in map) {
            System.Console.WriteLine($"Adding {pair.Key}:{pair.Value}");
            heap.Add(new Freq(pair.Key, pair.Value));
            System.Console.WriteLine($"Now peek - {heap.Peek().num}");
            if(heap.Count()>k){
                var ans = heap.Poll();
                System.Console.WriteLine($"Removing {ans.num}:{ans.fre}");
            }
        }
        int[] res = new int[k];
        int i=0;
        while(heap.Count()>0){
            res[i] = heap.Poll().num;
            i++;
        }
        return res;
    }

    
}

public class Freq{
        public int num;
        public int fre;
        public Freq(int num, int fre)
        {
            this.num = num;
            this.fre = fre;
        }
    }
    public class CustomComparer : IComparer<Freq>
{
    
    public int Compare(Freq x, Freq y)
    {
        if (x == null && y == null) return 0;
        if (x == null) return -1;
        if (y == null) return 1;
       
        return x.fre.CompareTo(y.fre);
    }

}