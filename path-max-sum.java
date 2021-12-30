class TreeNode {
    int val;
    TreeNode left;
    TreeNode right;
  
    TreeNode(int x) {
      val = x;
    }
  };
  
  class MaximumPathSum {
    static int sum = -1;
    public static int findMaximumPathSum(TreeNode root) {
      // TODO: Write your code here
      sum = -1;
      pathSum(root);
      return sum;
    }
    // return types index 0 is height and index 1 is sum
    public static int[] pathSum(TreeNode root) {
        // TODO: Write your code here
    
        if(root==null) return new int[]{0,0};
        if(root.left==null && root.right==null) return new int[]{1, root.val};
    
        int[] left = pathSum(root.left);
        int[] right = pathSum(root.right);
    
        if(left[0] !=0 && right[0] !=0){
          sum = Math.max(sum, left[1]+ right[1]+root.val);
        }
    
        return new int[] {1+Math.max(left[0], right[0]), root.val + Math.max(left[1],right[1])};
    }
    public static void main(String[] args) {
      TreeNode root = new TreeNode(1);
      root.left = new TreeNode(2);
      root.right = new TreeNode(3);
      System.out.println("Maximum Path Sum: " + MaximumPathSum.findMaximumPathSum(root));
      
      root.left.left = new TreeNode(1);
      root.left.right = new TreeNode(3);
      root.right.left = new TreeNode(5);
      root.right.right = new TreeNode(6);
      root.right.left.left = new TreeNode(7);
      root.right.left.right = new TreeNode(8);
      root.right.right.left = new TreeNode(9);
      System.out.println("Maximum Path Sum: " + MaximumPathSum.findMaximumPathSum(root));
      
      root = new TreeNode(-1);
      root.left = new TreeNode(-3);
      System.out.println("Maximum Path Sum: " + MaximumPathSum.findMaximumPathSum(root));
    }
  }