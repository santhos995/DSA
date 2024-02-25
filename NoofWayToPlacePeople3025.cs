public class Solution {
    public int NumberOfPairs(int[][] points) {
        
        int n = points.Length;
        int count = 0;
        for(int i=0;i<n;i++){
            for(int j =i+1;j<n;j++){
                int x1 = points[i][0], y1 = points[i][1];
                int x2 = points[j][0], y2 = points[j][1];
                int cX,cY,tX,tY;
                //can place Chisato and takina?//1,3 1,1
                if(x1 < x2){
                    if(y1<y2){ 
                        //Console.WriteLine("first");
                        continue;}
                    cX = x1;
                    cY = y1;
                    tX = x2;
                    tY = y2;
                }else if(x1==x2){
                    cX = x2;
                    cY = y2;
                    tX = x1;
                    tY = y1;
                }
                    else{
                    if(y2<y1){
                        //Console.WriteLine("second");
                        continue;}
                    
                    cX = x2;
                    cY = y2;
                    tX = x1;
                    tY = y1;
                }
                //end
                Console.WriteLine($"{i}:{j}");
                if(!anyOneInside(points, i, j, cX, cY, tX, tY))
                    count++;
            }
        }
        return count;
    }
    bool anyOneInside(int[][] points, int i, int j, int cX, int cY, int tX, int tY){
        for(int k=0;k<points.Length;k++){
            if(i==k || j==k)
                continue;
            int x = points[k][0], y = points[k][1];
            Console.WriteLine($"entry -- {cX}:{tX}:{cY}:{tY}-- {x}:{y}");
            Console.WriteLine($"entry -- {x>=cX}:{x<=tX}:{y<=cY}:{y>=tY}-- {x}:{y}--{i}:{j}");
            if(x>=cX && x<=tX && y<=cY && y>=tY){
                Console.WriteLine($"wont work -- {x>=cX}:{x<=tX}:{y<=cY}:{y>=tY}-- {x}:{y}");
                return true;
            }
        }
        return false;
    }
}