import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;

class Solution {
    public int minCostConnectPoints(int[][] points) {
        PriorityQueue<Edge> pq = new PriorityQueue<Edge>(new EdgeComparator());
        for (int i = 0; i < points.length; i++) {
            for (int j = i+1; j < points.length; j++) {
                int cost = Math.abs(points[i][0]-points[j][0]) +
                            Math.abs(points[i][1]-points[j][1]);
                //System.out.println(i + " "+j+" "+cost);
                pq.add(new Edge(i,j,cost));
            }
        }

        UnionFind uf = new UnionFind(points.length);
        int count = points.length-1;
        int min =0;
        //System.out.println(pq.count()+"--"+count);
        while(pq.count()>0 && count>0){
            Edge ed = pq.poll();
            //System.out.println("root for "+x);uf.connected(ed.Point1, ed.Point2));
            if(!uf.connected(ed.Point1, ed.Point2)){
                uf.union(ed.Point1, ed.Point2);
                min += ed.Cost;
            }
            count--;
        }
        return min;
    }
    
    class UnionFind {
        private int[] root;
        // Use a rank array to record the height of each vertex, i.e., the "rank" of each vertex.
        private int[] rank;
    
        public UnionFind(int size) {
            root = new int[size];
            rank = new int[size];
            for (int i = 0; i < size; i++) {
                root[i] = i;
                rank[i] = 1; // The initial "rank" of each vertex is 1, because each of them is
                             // a standalone vertex with no connection to other vertices.
            }
        }
    
        // The find function here is the same as that in the disjoint set with path compression.
        public int find(int x) {
            //System.out.println("root for "+x);
            if (x == root[x]) {
                return x;
            }
            return root[x] = find(root[x]);
        }
    
        // The union function with union by rank
        public void union(int x, int y) {
            int rootX = find(x);
            int rootY = find(y);
            if (rootX != rootY) {
                if (rank[rootX] > rank[rootY]) {
                    root[rootY] = rootX;
                } else if (rank[rootX] < rank[rootY]) {
                    root[rootX] = rootY;
                } else {
                    root[rootY] = rootX;
                    rank[rootX] += 1;
                }
            }
        }
    
        public boolean connected(int x, int y) {
            return find(x) == find(y);
        }
    }
    private class Edge{
        int Point1,Point2,Cost;
        Edge(int point1, int point2, int cost){
            Point1 = point1;
            Point2 = point2;
            Cost = cost;
        }
    }
    private class EdgeComparator implements Comparator<Edge>{

        @Override
        public int compare(Edge o1, Edge o2) {
            
            return o2.Cost - o1.Cost;
        }

    }
    private class PriorityQueue<T> {
        List<T> nums = new ArrayList<>();
        Comparator<T> comparator;

        public PriorityQueue(Comparator<T> comparator) {
            this.comparator = comparator;
            nums = new ArrayList<>();
        }

        void add(T val) {
            nums.add(val);
            heapifyUp(nums.size() - 1);//Heapify has to be done on its parent
        }

        T peek() {
            return nums.get(0);
        }

        T poll() {
            T num = nums.get(0);
            nums.set(0, nums.get(nums.size() - 1));
            nums.remove(nums.size() - 1);
            heapify(0);
            return num;
        }

        void heapify(int i) {
            if (i < 0) return;
            int k = i;
            int left = 2 * i;
            int right = left + 1;
            if (left < nums.size() && comparator.compare(nums.get(left),nums.get(k))>0)
                k = left;
            if (right < nums.size() && comparator.compare(nums.get(right), nums.get(k))>0)
                k = right;
            if (k != i) {
                swap(i, k);
                heapify(k);
            }
        }

        private void heapifyUp(int i) {
            int parent = i / 2;
            if (parent < 0) return;

            if (comparator.compare(nums.get(parent), nums.get(i))<0) {
                swap(i, parent);
                heapify(parent);//this is needed because the other child might break the heap property
                heapifyUp(parent);
            }
        }

        void swap(int i, int j) {
            Collections.swap(nums,i,j);
        }

        public int count() {
            return nums.size();
        }
}
}