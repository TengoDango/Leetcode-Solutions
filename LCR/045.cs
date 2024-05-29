// https://leetcode.cn/problems/LwUNpT/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR045;
public class Solution
{
    /// <summary>
    /// 获取二叉树最底层最左值
    /// </summary>
    public int FindBottomLeftValue(TreeNode root)
    {
        // DFS
        UpdateBottomLeftValue(root, 1);
        return answer;
    }

    int maxDepth = 0;
    int answer = 0;
    void UpdateBottomLeftValue(TreeNode? node, int depth)
    {
        if (node is null) return;
        if (depth > maxDepth)
        {
            maxDepth = depth;
            answer = node.val;
        }
        UpdateBottomLeftValue(node.left, depth + 1);
        UpdateBottomLeftValue(node.right, depth + 1);
    }
}