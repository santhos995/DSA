
public class NoOfWays {
    public int NumberOfPairs(int[][] points) {
        int n = points.Length;
        int count =0;
        Array.Sort(points, new Comparison<int[]>(
            (x,y)=> { return x[0]<y[0] ? -1 : (x[0]==y[0])? ((x[1]>y[1])?-1:1):1;}
            ));
        
        // for (int i = 0; i < n; i++)
        // {
        //     System.Console.WriteLine($"{points[i][0]}--{points[i][1]}");
        // }
//         [[[0,1],[0,2],[0,4]]
// [[0,0],[0,3]]
// [[3,1],[1,3],[1,1]]
// [[1,1],[2,2],[3,3]]
// [[6,2],[4,4],[2,6]]
        for (int i = 0; i < n; i++){
            for (int j = i+1; j < n; j++){
                if(points[i][0]<=points[j][0] && points[i][1]>=points[j][1]){
                    //Console.WriteLine($"{i}:{j}");
                    if(!anyOneInside(points, i, j, points[i][0], points[i][1],points[j][0], points[j][1]))
                        count++;
                }
            }
        }
        
        return count;
    }

     bool anyOneInside(int[][] points, int i, int j, int cX, int cY, int tX, int tY){
        for(int k=0;k<points.Length;k++){
            if(i==k || j==k)
                continue;
            int x = points[k][0], y = points[k][1];
            //Console.WriteLine($"entry -- {cX}:{tX}:{cY}:{tY}-- {x}:{y}");
            //Console.WriteLine($"entry -- {x>=cX}:{x<=tX}:{y<=cY}:{y>=tY}-- {x}:{y}--{i}:{j}");
            if(x>=cX && x<=tX && y<=cY && y>=tY){
                //Console.WriteLine($"wont work -- {x>=cX}:{x<=tX}:{y<=cY}:{y>=tY}-- {x}:{y}");
                return true;
            }
        }
        return false;
    }
}