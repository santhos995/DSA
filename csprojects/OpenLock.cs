//LC752 - Not solved
public class Solution2 {
    public int OpenLock(string[] deadends, string target) {
        if(target == "0000") return 0;

        Dictionary<string,List<string>> graph;
        HashSet<string> deadendsSet = new HashSet<string>(deadends);
        graph = constructGraph(deadendsSet);

        //bfs
        string root = "0000";
        int move = 0;
        HashSet<string> visited = new();
        //List<string> siblings = graph[root];
        Queue<string> q = new();
        q.Enqueue(root);
        //bool targetFound = false;
        while(q.Count>0){
            int count = q.Count;
            while(count-- >0){
                var node = q.Dequeue();
                if(node == target) return move;//we found our target node;
                visited.Add(node);
                foreach(string neighbour in graph[node]){
                    if(!visited.Contains(neighbour))//to stop recursion
                        q.Enqueue(neighbour);
                }
            }
            move++;
        }
        return move;
    }

    Dictionary<string,List<string>> constructGraph(HashSet<string> deadendsSet){
        Dictionary<string,List<string>> res = new();
        int[] init = new int[]{0,0,0,0};

        //string parent = String.Join("",init);

        List<int[]> neighbours = new();

        neighbours.Add(init);//Initial node;

        while(neighbours.Count > 0){
            List<int[]> connectedNeighbours = new();
            foreach(int[] node in neighbours){
                string parent = String.Join("",node);
                if(!res.ContainsKey(parent))
                    res.Add(parent, new List<string>());
                
                connectedNeighbours = getConnectedNeighbours(node, deadendsSet);
                foreach(int[] neigbour in connectedNeighbours){
                    string neigb = String.Join("",neigbour);
                    res[parent].Add(neigb);

                    if(!res.ContainsKey(neigb))
                        res.Add(neigb, new List<string>());

                    res[neigb].Add(parent);
                }
            }
            neighbours = connectedNeighbours;
        }

        //End case
        List<string> ends = new List<string>(){"9000","0900","0090","0009"};
        foreach(string node in ends){
            if(!deadendsSet.Contains(node)){
                res["0000"].Add(node);
                //res[node].Add("0000");
            }
        }
        return res;
    }

    List<int[]> getConnectedNeighbours(int[] node, HashSet<string> deadendsSet){
        List<int[]> res = new();
        for(int i=0;i<4;i++){
            int[] copy = new int[4];
            Array.Copy(node, 0, copy, 0, 4);

            int move = copy[i]+1;
            if(move>10){
                //its time to stop - dont add this lock pattern neighbour since this might have already traversed
                continue;
            }
            copy[i] = move;
            if(!deadendsSet.Contains(String.Join("",copy))){
                res.Add(copy);
            }
        }
        return res;
    }
}