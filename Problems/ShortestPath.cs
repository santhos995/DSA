using System;
namespace Problems
{
    public class ShortestPath
    {
        static int minLen = int.MaxValue;
        static int n = 0;
        public int ShortestPathLength(int[][] graph)
        {
            n = graph.Length;
            if (n == 1) return 0;
            if (n == 2) return 1;
            
            bool[] visited = new bool[n];
            for (int i = 0; i < n; i++)
            {
                dfs(graph, i, visited, 0, 0);
            }
            return minLen;
        }

        private void dfs(int[][] graph, int i, bool[] visited, int count, int distance)
        {
            if (distance >= minLen)
                return;
            if (count == n)
            {
                minLen = Math.Min(minLen, distance);
                return;
            }
            bool isVisited = visited[i];
            visited[i] = true;
            for (int j = 0; j < graph[i].Length; j++)
            {
                dfs(graph, graph[i][j], visited, (isVisited)?count:count + 1, distance + 1);
            }
            visited[i] = false;
        }
    }
}
