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

    public Node CloneGraphBFSOptimized(Node node){
        if(node==null) return node;
        
        Node root = new Node(node.val);
        
        var map = new Dictionary<int, Node>();
        map.Add(root.val,root);
        Queue<Node> q = new Queue<Node>();
        q.Enqueue(node);
        
        while(q.Count>0){
            var cur = q.Dequeue();
            var curNewNode = map[cur.val];
            foreach (var neighbor in cur.neighbors)
            {
                if(!map.ContainsKey(neighbor.val)){//only if not in the map, we need to enqueue bcs what are all in map are already visited
                    map.Add(neighbor.val,new Node(neighbor.val));
                    q.Enqueue(neighbor);
                }
                curNewNode.neighbors.Add(map[neighbor.val]);
            }
        }
        return root;
    }

    public Node CloneGraphDFS(Node node){
        
        var map = new Dictionary<int, Node>();
        return dfs(node, map);
    }
    private Node dfs(Node node, Dictionary<int, Node> map){
        if(node == null) return null;
        if(map.ContainsKey(node.val))
            return map[node.val];
        
        var newNode = new Node(node.val);
        map.Add(node.val, newNode);
        foreach (var neighbor in node.neighbors)
        {
            if(!map.ContainsKey(neighbor.val)){
                var newNeighbor = dfs(neighbor, map);
                newNode.neighbors.Add(newNeighbor);
            }
            else{
                newNode.neighbors.Add(map[neighbor.val]);
            }
        }
        return newNode;
    }
}