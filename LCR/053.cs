// https://leetcode.cn/problems/P5rCT8/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR053;
public class Solution
{
    /// <summary>
    /// 寻找中序遍历的后继节点
    /// </summary>
    public TreeNode? InorderSuccessor(TreeNode root, TreeNode p)
    {
        if (p.right is not null)
        {
            // 右子树存在，后继为右子树的最左节点
            p = p.right;
            while (p.left is not null) p = p.left;
            return p;
        }
        else
        {
            // 右子树不存在，设后继为 successor
            // p 应当在 successor 的左子树中
            // 这意味着 successor 在 root 到 p 的路径上
            TreeNode? successor = null;
            while (root is not null)
            {
                if (p.val < root.val)
                {
                    successor = root;
                    root = root.left!;
                }
                else if (p.val > root.val)
                {
                    root = root.right!;
                }
                else
                {
                    return successor;
                }
            }
            return null;
        }
    }
}