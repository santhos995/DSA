//for a 2d jagged array
 Array.Sort(points, new Comparison<int[]>(
            (x,y)=> { 
                return x[0]<y[0] ? -1 : (x[0]==y[0])? ((x[1]<y[1])?-1:1):1;
                }
            ));