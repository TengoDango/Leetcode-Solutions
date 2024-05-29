// https://leetcode.cn/problems/NaqhDT/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR043;
/// <summary>
/// 完全二叉树
/// </summary>
public class CBTInserter(TreeNode root)
{
    /// <summary>
    /// 插入节点，返回插入后结点的父节点值
    /// </summary>
    public int Insert(int value)
    {
        // 计算路径 (二进制分解)
        count++;
        int n = count;
        Stack<bool> path = [];
        while (n > 1)
        {
            path.Push(n % 2 == 1);
            n /= 2;
        }
        // 寻找父节点
        TreeNode parent = root;
        while (path.Count > 1)
        {
            bool isRight = path.Pop();
            parent = isRight ? parent.right! : parent.left!;
        }
        // 插入新节点
        if (path.Pop())
            parent.right = new(value);
        else
            parent.left = new(value);
        return parent.val;
    }
    /// <summary>
    /// 获取根节点
    /// </summary>
    public TreeNode Get_root() => root;

    int count = Count(root);
    /// <summary>
    /// 获取结点个数
    /// </summary>
    static int Count(TreeNode? t)
    {
        if (t is null) return 0;
        return 1 + Count(t.left) + Count(t.right);
    }
}