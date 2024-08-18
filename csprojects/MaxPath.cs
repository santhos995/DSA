
 // Definition for a binary tree node.
  public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
          this.val = val;
          this.left = left;
          this.right = right;
     }
  }
 
public class MaxPath {
    static int max = int.MinValue;
    public int MaxPathSum(TreeNode root) {
        max = int.MinValue;
        dfs(root);
        return max;
    }
    public int dfs(TreeNode node) {
        if(node == null) {return 0;}

        int left = dfs(node.left);
        int right = dfs(node.right);
        int curMax = Math.Max(0, node.val + Math.Max(left, right));

        max = Math.Max(max, node.val + Math.Max(0, left) + Math.Max(0,right) );
        return curMax;
    }
}