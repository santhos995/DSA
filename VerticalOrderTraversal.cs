/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public IList<IList<int>> VerticalTraversal(TreeNode root) {
     
        SortedDictionary<int, List<int>> sd = new SortedDictionary<int, List<int>>();
        traverse(root, sd);
        List<IList<int>> res = new List<IList<int>>();
            foreach(var val in sd.Values)
            {
                res.Add(val);
            }
        return res;
    }
    
    private void traverse(TreeNode node, SortedDictionary<int, List<int>> sd)
    {
         Queue<Node> q = new Queue<Node>();
        int nodesInNextLevel = 0, curLevel = 1;
        q.Enqueue(new Node(node, 0));
        SortedList<int, int> tempList = new SortedList<int, int>();
        while (q.Count() > 0)
        {
            Node n = q.Dequeue();
            curLevel--;

            tempList.Add(n.tree.val, n.x);

            if (n.tree.left != null)
            {
                nodesInNextLevel++;
                q.Enqueue(new Node(n.tree.left, n.x - 1));
            }
            if (n.tree.right != null)
            {
                nodesInNextLevel++;
                q.Enqueue(new Node(n.tree.right, n.x + 1));
            }
            if (curLevel == 0)//it is all next level
            {
                curLevel = nodesInNextLevel;
                nodesInNextLevel = 0;
                
                
                foreach(var v in tempList)
                {
                    if (!sd.ContainsKey(v.Value))
                        sd.Add(v.Value, new List<int>());
                    sd[v.Value].Add(v.Key);
                }
                tempList.Clear();
            }
        }
    }
    internal class Node
    {
        internal TreeNode tree;
        internal int x;
        internal Node(TreeNode treeNode, int xAxis)
        {
            x = xAxis;
            tree = treeNode;
        }
    }
}