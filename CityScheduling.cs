public class Solution {
    public int TwoCitySchedCost(int[][] costs) {
        int n = costs.Length;
        Console.WriteLine(n);
        List<cost> l = new List<cost>();
        
        for(int j=0;j<n;j++){
            l.Add(new cost(costs[j][0],costs[j][1]));
        }
        
        //var res = l.OrderBy(a=>a.cityA).ToList();
        l.Sort((a,b)=>(a.cityB-a.cityA)-(b.cityB-b.cityA));
        var res = l;
        

        int costA = 0,costB=0,i;
        for(i=0;i<n/2;i++){
            costA +=res[i].cityA;
            costB += res[i].cityB;
            
        }
        Console.WriteLine("i "+i);
        for(;i<n;i++){
            costA +=res[i].cityB;
            costB += res[i].cityA;
            //Console.WriteLine("insode"+i);
        }
        return Math.Min(costA,costB);
    }
    class cost{
        internal int cityA;
        internal int cityB;
        internal cost(int a, int b){
            cityA = a;
            cityB = b;
        }
    }
    /*
    class CostComparer:IComparer<cost>{
        public int Compare(cost a, cost b){
            return a-b;
        }
    }
    */
}