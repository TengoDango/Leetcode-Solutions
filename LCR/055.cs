// https://leetcode.cn/problems/kTOapQ/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR055;
/// <summary>
/// 二叉树中序迭代器
/// </summary>
public class BSTIterator(TreeNode root)
{
    /// <summary>
    /// 获取下一个值
    /// </summary>
    public int Next()
    {
        var node = stack.Pop();
        var p = node.right;
        while (p is not null)
        {
            stack.Push(p);
            p = p.left;
        }
        return node.val;
    }
    /// <summary>
    /// 是否有下一个值
    /// </summary>
    public bool HasNext() => stack.Count > 0;

    // 辅助递归栈
    Stack<TreeNode> stack = InitStack(root);
    static Stack<TreeNode> InitStack(TreeNode? root)
    {
        // 模拟递归函数
        Stack<TreeNode> stack = [];
        while (root is not null)
        {
            stack.Push(root);
            root = root.left;
        }
        return stack;
    }
}