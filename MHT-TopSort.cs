public class Solution {
    public IList<int> FindMinHeightTrees(int n, int[][] edges) {
        var graph = new Dictionary<int, List<int>>();
        var inDegree = new Dictionary<int, int>();
        for (int i = 0; i < n; i++)
        {
            graph.Add(i, new List<int>());
            inDegree.Add(i,0);
        }

        foreach (var edge in edges)
        {
            int first = edge[0];
            int second = edge[1];
            graph[first].Add(second);
            graph[second].Add(first);
            inDegree[first]++;
            inDegree[second]++;
        }

        Queue<int> source = new Queue<int>();
        foreach (var edge in inDegree)
        {
            if(edge.Value ==1)
                source.Enqueue(edge.Key);
        }

        int remainingEdges = n-1;
        while(remainingEdges>2)
        {
            remainingEdges -= source.Count;
            int count = source.Count;
            for (int i = 0; i < count; i++)
            {
                var vertex = source.Dequeue();
                var children = graph[vertex];
                if(vertex == 1)
                    Console.WriteLine($"{i}--{remainingEdges}");
                foreach (var child in children)
                {
                    inDegree[child]--;
                    if(inDegree[child]==1)
                        source.Enqueue(child);
                }
            }
        }
        return new List<int>(source);
    }
}