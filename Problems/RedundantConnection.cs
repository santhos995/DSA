using System;
namespace Problems
{
    public class RedundantConnection
    {
        public int[] FindRedundantConnection(int[][] edges)
        {
            int n = edges.Length;
            var uf = new UnionFind(n + 1);
            uf.Union(edges[0][0], edges[0][1]);
            for (int i = 1; i < n; i++)
            {
                int u = edges[i][0];
                int v = edges[i][1];
                if (uf.isSameRoot(u, v))
                    return new int[] { u, v };
                uf.Union(u, v);
            }
            return new int[] { -1,-1 };
        }
    }
    public class UnionFind
    {
        private int[] rank;
        private int[] root;
        public UnionFind(int n)
        {
            rank = new int[n];
            root = new int[n];

            for (int i = 0; i < n; i++)
            {
                root[i] = i;
                rank[i] = 1;
            }
        }
        public void Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);
            if (rootX != rootY)
            {
                if (rank[rootX] < rank[rootY])
                {
                    root[rootX] = rootY;
                }
                else if (rank[rootY] < rank[rootX])
                {
                    root[rootY] = rootX;
                }
                else
                {
                    root[rootX] = rootY;
                    rank[rootY] += 1;
                }
            }
        }
        public int Find(int x)
        {
            if (root[x] == x)
                return x;
            return root[x] = Find(root[x]);
        }
        public bool isSameRoot(int x, int y)
        {
            return Find(x) == Find(y);
        }
    }
}
