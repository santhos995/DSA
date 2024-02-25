public class LC695 {
    
     public int MaxAreaOfIsland_dfs(int[][] grid) {
        return -1;
     }
    public int MaxAreaOfIsland(int[][] grid) {

            UnionFind uf = new UnionFind(grid);
            int m = grid.Length;
            int n = grid[0].Length;
            //System.Console.WriteLine($"{m}:{n}");
            for(int i=0;i<m;i++){
                for(int j=0;j<n;j++){
                    if(grid[i][j]==1){
                        int cur = UnionFind.me(i,j,m,n);
                        int right = UnionFind.right(i,j,m,n);
                        if(right != -1 && uf.size[right] == 1){
                            uf.union(cur, UnionFind.right(i,j,m,n));
                            //System.Console.WriteLine($"Union right {cur}:{right}");
                        }
                        int top = UnionFind.top(i,j,m,n);
                        if(top != -1 && uf.size[top] == 1){
                            uf.union(UnionFind.me(i,j,m,n), UnionFind.top(i,j,m,n));
                            //System.Console.WriteLine($"Union top {cur}:{top}");

                        }
                        int bottom = UnionFind.bottom(i,j,m,n);
                        if(bottom != -1 && uf.size[bottom] == 1){
                            uf.union(UnionFind.me(i,j,m,n), UnionFind.bottom(i,j,m,n));
                            //System.Console.WriteLine($"Union bottom{cur}:{bottom}");

                        }
                        //System.Console.WriteLine($"End of {i}:{j}--{uf.size.Max()}");
                    }
                }
            }
            System.Console.WriteLine(string.Join(", ", uf.size));
            return uf.size.Max();
    }

    public class UnionFind{
        public int[] parent;
        public int[] size;
        public int[] rank;
        int max = 0;
        public int getMax() { return max;}
        public UnionFind(int[][] grid){
            int m = grid.Length;
            int n = grid[0].Length;

            parent = new int[m*n];
            size = new int [m*n];
            rank = new int [m*n];
            for(int i=0;i<m;i++){
                for(int j=0;j<n;j++){
                    int cur = me(i,j,m,n);
                    //System.Console.WriteLine($"{cur}--{i}:{j}");
                    parent[cur] = cur;
                    if(grid[i][j]==1){
                        size[cur]=1;
                        rank[cur]=1;
                        max = 1;
                    }
                }
            }
        }
        public void union(int x, int y){
            int parentX = find(x);
            int parentY = find(y);
            
            if(parentX == parentY){
                return;
            }
            //System.Console.WriteLine($"parent of {x}:{parentX},{y}:{parentY}");
            if(rank[parentX]>=rank[parentY]){
                parent[parentY] = parentX;
                size[parentX] += size[parentY];
                //size[parentY] = 0;
                if(rank[parentX]==rank[parentY])
                    rank[parentX]++;
            }else{
                parent[parentX] = parentY;
                size[parentY] += size[parentX];
                //size[parentX] = 0;
                
            }   
                
        }
        int find(int x){
            if(parent[x]==x)
                return x;
            return parent[x] = find(parent[x]);//path compression
        }
        public static int top(int i, int j, int m, int n){
            if(i<1) return -1;//border

            return ((i-1)*n) + j; 
        }
        public static int right(int i, int j, int m, int n){
            if(j==n-1) return -1;//border
            return i*n + j+1;
        }

        public static int bottom(int i, int j, int m, int n){
            if(i==m-1) return -1;
            return ((i+1)*n) + j; 
        }

        public static int me(int i, int j, int m, int n){
            return i*n + j;
        }
    }
}