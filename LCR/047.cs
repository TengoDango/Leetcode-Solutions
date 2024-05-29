// https://leetcode.cn/problems/pOCWxh/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR047;
public class Solution
{
    /// <summary>
    /// 剪除二叉树中所有值为 0 的子树
    /// </summary>
    /// <returns>根节点</returns>
    public TreeNode? PruneTree(TreeNode? root)
    {
        // DFS
        if (root is null) return null;
        root.left = PruneTree(root.left);
        root.right = PruneTree(root.right);
        return root.left == null
            && root.right == null
            && root.val == 0
            ? null : root;
    }
}