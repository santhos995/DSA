class TreeNode {
    int val;
    TreeNode left;
    TreeNode right;
  
    TreeNode(int x) {
      val = x;
    }
  };
  
  class TreeDiameter {
  
    public static int findDiameter(TreeNode root) {
      // TODO: Write your code here
  
      if(root==null) return 0;
      if(root.left==null && root.right==null) return 1;
  
      int dia = height(root.left) + height(root.right) + 1;
      System.out.println(dia + " " + root.val );
      return Math.max(dia, Math.max(findDiameter(root.left), findDiameter(root.right)));
    }
  
  
  public static int height(TreeNode root) {
      // TODO: Write your code here
  
      if(root==null) return 0;
      if(root.left==null && root.right==null) return 1;
      return Math.max(1+height(root.left), 1+height(root.right));
  }
    public static void main(String[] args) {
      TreeNode root = new TreeNode(1);
      root.left = new TreeNode(2);
      root.right = new TreeNode(3);
      root.left.left = new TreeNode(4);
      root.right.left = new TreeNode(5);
      root.right.right = new TreeNode(6);
      System.out.println("Tree Diameter: " + TreeDiameter.findDiameter(root));
      root.left.left = null;
      root.right.left.left = new TreeNode(7);
      root.right.left.right = new TreeNode(8);
      root.right.right.left = new TreeNode(9);
      root.right.left.right.left = new TreeNode(10);
      root.right.right.left.left = new TreeNode(11);
      System.out.println("Tree Diameter: " + TreeDiameter.findDiameter(root));
    }
  }