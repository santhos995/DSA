/**
 * Definition for a binary tree node.
 * function TreeNode(val) {
 *     this.val = val;
 *     this.left = this.right = null;
 * }
 */
/**
 * @param {TreeNode} root
 * @param {TreeNode} p
 * @param {TreeNode} q
 * @return {TreeNode}
 */
var lowestCommonAncestor = function(root, p, q) {
    let res = {
        
    };
    
    lca(root, p,q, res);
    return res.a;
};

function lca(root, p, q, res){
    if(root==null) return 0;
    let count =0;
   
    count += lca(root.left, p, q, res);
    count += lca(root.right, p, q, res);
    console.log(`Val - ${root.val}, Count - ${count}`);
    if(res.a === undefined && count>1) res.a = root;
    if( (root.val == p.val || root.val == q.val)) {
        //console.log(root.val);    
        count++;
        console.log(`Inside Val - ${root.val}, Count - ${count}`);
        if(res.a === undefined && count >1) res.a = root;
    }
    
    return count;
}