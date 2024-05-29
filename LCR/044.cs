// https://leetcode.cn/problems/hPov7L/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR044;
public class Solution
{
    /// <summary>
    /// 获取二叉树每层最大值
    /// </summary>
    public IList<int> LargestValues(TreeNode? root)
    {
        List<int> maxValues = [];
        if (root is null) return maxValues;

        // BFS
        Queue<TreeNode> layer = [];
        layer.Enqueue(root);

        while (layer.Count > 0)
        {
            int count = layer.Count;
            int max = int.MinValue;
            for (int i = 0; i < count; i++)
            {
                var node = layer.Dequeue();
                max = Math.Max(max, node.val);
                if (node.left is not null) layer.Enqueue(node.left);
                if (node.right is not null) layer.Enqueue(node.right);
            }
            maxValues.Add(max);
        }

        return maxValues;
    }
}