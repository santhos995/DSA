public class LongestConsecutiveSeqClass {
    public int LongestConsecutive(int[] nums) {
       
       UnionFind uf = new UnionFind(nums);

        var map = uf.parent;

        for(int i=0;i<nums.Length;i++){
            if(map.ContainsKey(nums[i]+1))
                uf.Union(nums[i], nums[i]+1);
        }
        return uf.getMax();
    }

    public class UnionFind{
        public Dictionary<int,int> parent = new();
        Dictionary<int,int> size = new();
        int max = 1;
        public UnionFind(int[] nums){
            for(int i=0;i<nums.Length;i++){
                 if(!parent.ContainsKey(nums[i])){
                    parent.Add(nums[i],nums[i]);
                    size.Add(nums[i],1);
                }
            }
        }

        int find(int x){
            if(parent[x]==x)
                return x;
            return parent[x] = find(parent[x]);//path compression
        }
        public void Union(int x, int y){
            int parentX = find(x);
            int parentY = find(y);

            if(parentX != parentY){
                parent[parentY] = parentX;
                size[parentX] += size[parentY];
                max = Math.Max(max, size[parentX]);
                System.Console.WriteLine($"{max}---{x}:{y}");
            }
        }
        public int getMax(){
            return max;
        }
    }
}