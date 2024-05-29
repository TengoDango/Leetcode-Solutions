// https://leetcode.cn/problems/jC7MId/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR051;
public class Solution
{
    /// <summary>
    /// 计算二叉树最大路径和
    /// 
    /// 路径为任意两节点间的无重复路径 (长度 >= 1)
    /// </summary>
    public int MaxPathSum(TreeNode root)
    {
        // 一条路径的和 = 根节点值
        //  + 左子树向下路径 (长度 >= 0)
        //  + 右子树向下路径 (长度 >= 0)

        maxSum = int.MinValue;
        UpdateMaxSum(root);
        return maxSum;
    }
    int maxSum;
    /// <summary>
    /// 更新最大路径和
    /// </summary>
    /// <returns>
    /// 最大向下路径，保证不小于 0
    /// </returns>
    int UpdateMaxSum(TreeNode? node)
    {
        // DFS
        if (node is null) return 0;
        int leftSum = UpdateMaxSum(node.left);
        int rightSum = UpdateMaxSum(node.right);
        
        maxSum = Math.Max(maxSum, leftSum + rightSum + node.val);
        return Math.Max(0, Math.Max(leftSum, rightSum) + node.val);
    }
}