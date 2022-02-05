public class Solution {
    public int[] FindOrder(int n, int[][] prerequisites) {
        
        var graph = new Dictionary<int, List<int>>();
        var inDegree = new Dictionary<int, int>();
        for (int i = 0; i < n; i++)
        {
            graph.Add(i, new List<int>());
            inDegree.Add(i, 0);
        }
        for (int i = 0; i < prerequisites.GetLength(0); i++)
        {
            int parent = prerequisites[i][1], child = prerequisites[i][0];
            graph[parent].Add(child);
            inDegree[child]++;
        }
        Queue<int> source = new Queue<int>();
        foreach (var vertex in inDegree)
        {
            if(vertex.Value == 0)
                source.Enqueue(vertex.Key);
        }

        List<int> result = new List<int>();
        while(source.Count >0)
        {
            var visited = source.Dequeue();
            result.Add(visited);
            foreach (var children in graph[visited])
            {
                inDegree[children]--;
                if(inDegree[children]==0)
                    source.Enqueue(children);
                    
            }
        }
        if(result.Count != n)
            result = new List<int>();
        return result.ToArray<int>();
    }
}