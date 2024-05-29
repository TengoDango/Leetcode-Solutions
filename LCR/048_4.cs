// https://leetcode.cn/problems/h54YBf/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR048_4;
/*
 * 二叉树示例：
 *           11
 *          /  \
 *        22    33
 *       /     /  \
 *     44    55    66
 *             \
 *              77
 *             /
 *           88
 * 
 * 序列策略：数组记录完全二叉树 (索引从 1 开始)
 *     ,11,22,33,44,,55,66,,,,,,77,,,(不知道多少个),,,88
 *     很费时间和空间，容易耗尽内存 (无法通过所有用例)
 * 
 * 序列化：确定节点对应的二进制索引
 */
public class Codec
{
    /// <summary>
    /// 二叉树 -> 字符串
    /// </summary>
    public string serialize(TreeNode? root)
    {
        List<int?> data = [];
        Deconstruct(root, 1, data);
        return string.Join(",", data);
    }
    /// <summary>
    /// 从树中提取数据
    /// </summary>
    void Deconstruct(TreeNode? node, int index, List<int?> data)
    {
        if (node is null) return;
        while (data.Count <= index) data.Add(null);
        data[index] = node.val;
        Deconstruct(node.left, index * 2, data);
        Deconstruct(node.right, index * 2 + 1, data);
    }
    /// <summary>
    /// 字符串 -> 二叉树
    /// </summary>
    public TreeNode? deserialize(string s)
    {
        var data = s.Split(',').Select(IntParse).ToArray();
        return Construct(data, 1);
    }
    /// <summary>
    /// 从数据中构造树
    /// </summary>
    TreeNode? Construct(int?[] data, int index)
    {
        if (index >= data.Length || data[index] is null) return null;
        TreeNode node = new(data[index]!.Value)
        {
            left = Construct(data, index * 2),
            right = Construct(data, index * 2 + 1)
        };
        return node;
    }
    static int? IntParse(string s) => int.TryParse(s, out int i) ? i : null;
}