// https://leetcode.cn/problems/3Etpl5/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR049;
public class Solution
{
    /// <summary>
    /// 计算二叉树生成的数值之和
    /// 
    /// 二叉树从根节点到叶子节点的路径表示一个数字
    /// 例如从根节点到叶子节点路径 1->2->3 表示数字 123
    /// </summary>
    public int SumNumbers(TreeNode root)
    {
        // DFS
        sum = 0;
        UpdateSum(root, 0);
        return sum;
    }

    int sum;
    void UpdateSum(TreeNode node, int prefix)
    {
        prefix = prefix * 10 + node.val;
        if (node.left is null && node.right is null)
        {
            sum += prefix;
            return;
        }
        if (node.left is not null) UpdateSum(node.left, prefix);
        if (node.right is not null) UpdateSum(node.right, prefix);
    }
}