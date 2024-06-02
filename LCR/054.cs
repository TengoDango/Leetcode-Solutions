// https://leetcode.cn/problems/w6cpku/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR054;
public class Solution
{
    /// <summary>
    /// 搜索树转为累加树
    /// </summary>
    public TreeNode? ConvertBST(TreeNode? root)
    {
        // 递减中序遍历即可
        sum = 0;
        DFS(root);
        return root;
    }

    int sum;
    void DFS(TreeNode? node)
    {
        if (node is null) return;
        DFS(node.right);
        sum += node.val;
        node.val = sum;
        DFS(node.left);
    }
}