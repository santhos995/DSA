//Not solved s
public class LC1992 {
   int x, y;
    List<int[]> res = new();
    public int[][] FindFarmland(int[][] land) {
        int n = land.Length;
        int m = land[0].Length;
        bool[,] visited = new bool[n,m];
        for (int i = 0;i  < n; i++) {
            for (int j = 0;j < m; j++) {
                if (land[i][j]==1 && !visited[i,j]){
                    int a = i, b = j;
                    x = 0;y = 0;
                    dfs(land, visited, i, j, a, b);
                    System.Console.WriteLine($"{a}:{b}--{x}:{y}");
                    res.Add(new int[]{a, b, x, y});
                    for(int k = i;k <= x;k++){
                        for(int l = j;l<=y;l++){
                            System.Console.WriteLine($"{k}:{l}");
                            visited[k,l] = true;
                        }
                    }
                }
            }
        }
        return res.ToArray<int[]>();
    }
    public void dfs(int[][] land,bool[,] visited, int i, int j, int a, int b){
        int n = land.Length;
        int m = land[0].Length;
        if(!inRange(i,j,n,m)) return;
        if(visited[i,j] || land[i][j]==0) return;

        visited[i,j] = true;
        dfs(land, visited, i, j++, a, b);
        dfs(land, visited, i++, j, a, b);
        x = i-1;
        y=j-1;
        
    }

    private bool inRange(int i,int j,int n,int m){
        return i >= 0 && i < n && j >= 0 && j < m;
    }
}