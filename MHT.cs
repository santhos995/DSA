public class Solution
{
    public IList<int> FindMinHeightTrees(int n, int[][] edges)
    {
        int minHeight = int.MaxValue;
        List<int> minList = new List<int>();
        var graph = new Dictionary<int, List<int>>();
        for (int source = 0; source < n; source++)
        {
            graph.Add(source, new List<int>());
            foreach (var edge in edges)
            {
                if (edge[0] == source )
                    graph[source].Add(edge[1]);
                if (edge[1] == source )
                    graph[source].Add(edge[0]);

            }
        }


        for (int source = 0; source < n; source++)
        {
            int height = 0;
            bool[] visited = new bool[n];
            Queue<int> q = new Queue<int>();
            q.Enqueue(source);
            bool breakLoop = false;
            while (q.Count > 0)
            {
                int count = q.Count();
                height++;
                if (height > minHeight)
                {
                    breakLoop = true;
                    break;
                }
                while (count-- > 0)
                {
                    int node = q.Dequeue();
                    visited[node] = true;
                    foreach (var edge in edges)
                    {
                        if (edge[0] == node && !visited[edge[1]])
                            q.Enqueue(edge[1]);
                        if (edge[1] == node && !visited[edge[0]])
                            q.Enqueue(edge[0]);
                    }
                }
            }
            if (breakLoop)
                continue;

            if (height <= minHeight)
            {
                //Console.WriteLine($"{source}--{height}--{minHeight}");

                if (height < minHeight)//we need to reset the list, bcs we found a minHeaight source
                    minList = new List<int>();
                minHeight = height;
                minList.Add(source);
            }
        }
        return minList;

    }
}