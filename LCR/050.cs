// https://leetcode.cn/problems/6eUYwP/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR050;
public class Solution
{
    /// <summary>
    /// 寻找指定路径和的路径数量
    /// 
    /// 路径不一定从根节点开始，也不一定从叶子节点结束，但是方向必须向下
    /// </summary>
    public int PathSum(TreeNode? root, int targetSum)
    {
        // 注意整数溢出

        // 记录前缀和
        Dictionary<long, int> prefixSum = [];
        prefixSum.Add(0, 1);
        // DFS + 回溯
        return PathSum(root, targetSum, 0, prefixSum);
    }

    int PathSum(TreeNode? node, int targetSum, long prefix, Dictionary<long, int> prefixSum)
    {
        if (node is null) return 0;
        prefix += node.val;
        int count = prefixSum.GetValueOrDefault(prefix - targetSum);
        prefixSum[prefix] = prefixSum.GetValueOrDefault(prefix) + 1;
        count += PathSum(node.left, targetSum, prefix, prefixSum);
        count += PathSum(node.right, targetSum, prefix, prefixSum);
        prefixSum[prefix] -= 1;
        return count;
    }
}