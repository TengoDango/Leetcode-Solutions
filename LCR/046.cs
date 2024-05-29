// https://leetcode.cn/problems/WNC0Lk/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR046;
public class Solution
{
    /// <summary>
    /// 获取二叉树右视图
    /// </summary>
    public IList<int> RightSideView(TreeNode? root)
    {
        if (root == null) return [];

        // BFS
        List<int> view = [];
        Queue<TreeNode> layer = [];
        layer.Enqueue(root);
        while (layer.Count > 0)
        {
            int count = layer.Count;
            for (int i = 0; i < count; i++)
            {
                var node = layer.Dequeue();
                if (i == 0) view.Add(node.val);
                if (node.right is not null) layer.Enqueue(node.right);
                if (node.left is not null) layer.Enqueue(node.left);
            }
        }
        return view;
    }
}