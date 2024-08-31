import java.util.Stack;



/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode() {}
 *     TreeNode(int val) { this.val = val; }
 *     TreeNode(int val, TreeNode left, TreeNode right) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

 //LC129
class Solution {
    
    int sum=0;
    
    public int sumNumbers_ite(TreeNode root) {
        Stack<temp> stk = new Stack<temp>();
        TreeNode node = root;
        int path = 0, sum =0;
        while(!stk.empty() || node!=null){
            
        }
        return sum;
    }

public class temp{
    public TreeNode node;
    public int path;
    public temp(TreeNode cuNode, int path){
this.node = cuNode;
this.path = path;
    }
}
    public int sumNumbers(TreeNode root) {
        dfs(root,0);
        return sum;
    }

    private void dfs(TreeNode node, int path){
        if(node==null) return ;

        //path = (path *10) + node.val;

        if(node.left==null && node.right==null){
            sum += (path *10) + node.val;
            //path /=10;
            return;
        }

        dfs(node.left, (path *10) + node.val);
        dfs(node.right, (path *10) + node.val);


    }
}