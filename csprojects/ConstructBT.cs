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
public class ConstructBT {
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        Dictionary<int,int> map = new Dictionary<int,int>();
        for (int i = 0; i < inorder.Length; i++)
        {
            map.Add(inorder[i], i);
        }
        return BuildTree(0,inorder.Length-1,0,inorder,preorder,map);
    }
    public TreeNode BuildTree(int inSt, int inEnd, int preSt, int[] inorder, int[] preorder, Dictionary<int, int> inMap){
        if(preSt>=preorder.Length || inSt>inEnd) return null;

        TreeNode node = new TreeNode(preorder[preSt]);
        int inIndex = inMap[preorder[preSt]];

        node.left = BuildTree(inSt, inIndex-1, preSt+1, inorder, preorder, inMap);
        node.right = BuildTree(inIndex+1, inEnd, preSt+2, inorder, preorder, inMap);
        return node;
    }
}