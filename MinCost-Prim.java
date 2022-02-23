import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.PriorityQueue;

class Solution {
    public int minCostConnectPoints(int[][] points) {
        PriorityQueue<Edge> pq = new PriorityQueue<Edge>((x,y)->x.Cost-y.Cost);
        
        HashMap<Integer, ArrayList<Edge>> graph = new HashMap<Integer, ArrayList<Edge>>();
        
        for (int i = 0; i < points.length; i++) {
            for (int j = i+1; j < points.length; j++) {
                int cost = Math.abs(points[i][0]-points[j][0]) +
                            Math.abs(points[i][1]-points[j][1]);
                //System.out.println(i + " "+j+" "+cost);
                List<Edge> edges = graph.get(i);
                if(edges == null)
                    edges = new ArrayList<>();
                edges.add(new Edge(i, j, cost));
            }
        }

        for (Edge edge : graph.get(0)) {
            pq.add(edge);
        }

        Boolean[] isVisited = new Boolean[points.length];
        int totalCost = 0;
        while(!pq.isEmpty() )       {
            Edge e = pq.poll();
            int p1 = e.Point1;
            int p2 = e.Point2;
            int cost = e.Cost;
            if(!isVisited[p2]){
                totalCost += cost;
                isVisited[p2] = true;
                for (Edge edge : graph.get(p2)) {
                    pq.add(edge);
                }
            }
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
}