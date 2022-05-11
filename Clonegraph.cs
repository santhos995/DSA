using System.Collections.Generic;
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}


public class Solution {
    public Node CloneGraph(Node node) {

        if(node == null) return node;
        var map = new Dictionary<Node,Node>();
        //Two BFS is needed
        //First pass, construct new node for all nodes present
        var q = new Queue<Node>();
        q.Enqueue(node);
        while(q.Count>0){
            var count = q.Count;
            for (int i = 0; i < count; i++)
            {
               var n = q.Dequeue();
               if(!map.ContainsKey(n)){
                   map.Add(n, new Node(n.val));
               }
               foreach (var neighbor in n.neighbors)
               {
                   if(!map.ContainsKey(neighbor))
                       q.Enqueue(neighbor);
               }
            }
        }
        //Second pass - to remap the neighours
        q.Clear();
        bool[] visited = new bool[map.Count+1];
        q.Enqueue(node);
        visited[node.val] = true;
        Node root = map[node];
        while(q.Count>0){
            var count = q.Count;
            for (int i = 0; i < count; i++)
            {
               var n = q.Dequeue();
               Node newNode = map[n];
               
               foreach (var neighbor in n.neighbors)
               {
                   newNode.neighbors.Add(map[neighbor]);
                   if(!visited[neighbor.val]){
                        q.Enqueue(neighbor);
                        visited[neighbor.val] = true;
                        Console.WriteLine(neighbor.val);
                   }
               }
            }
        }
        return root;
    }

    public Node CloneGraphDFS(Node node){
        
    }
}