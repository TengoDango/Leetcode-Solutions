// https://leetcode.cn/problems/NYBBNL/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR052;
public class Solution
{
    /// <summary>
    /// 将二叉搜索树整理为递增链表 (仍为搜索树形式)
    /// </summary>
    public TreeNode IncreasingBST(TreeNode root)
    {
        prev = null;
        return InOrder(root)!;
    }
    /// <summary>
    /// 整理子树，返回整理后的根节点
    /// </summary>
    TreeNode? InOrder(TreeNode? root)
    {
        if (root is null) return null;

        // 整理左子树，递归更新 prev 并获取新的根节点
        TreeNode newRoot = InOrder(root.left) ?? root;
        // 将左子树与根节点连接
        root.left = null;
        if (prev is not null) prev.right = root;
        // 更新 prev 为当前根节点
        prev = root;
        // 整理右子树
        root.right = InOrder(root.right);
        return newRoot;
    }
    TreeNode? prev;
}