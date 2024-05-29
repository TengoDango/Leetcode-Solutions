// https://leetcode.cn/problems/h54YBf/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR048_2;
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
 * 序列策略：通过索引建立列表
 *     Index        0  1  2  3  4  5  6  7
 *     Value       11 22 33 44 55 66 77 88
 *     LeftIndex    1  3  4           7
 *     RightIndex   2     5     6
 *     11,1,2;22,3,;33,4,5;44,,;55,,6;66,,;77,7,;88,,
 * 
 * 序列化：在 DFS 前序遍历的同时构造索引表
 * 反序列化：通过索引表连接二叉树节点
 */
public class Codec
{
    /// <summary>
    /// 二叉树 -> 字符串
    /// </summary>
    public string serialize(TreeNode? root)
    {
        List<NodeData> data = [];
        Deconstruct(root, data);
        return string.Join(';', data);
    }
    /// <summary>
    /// 从树中提取数据
    /// </summary>
    int? Deconstruct(TreeNode? node, List<NodeData> data)
    {
        if (node is null) return null;
        int index = data.Count;
        data.Add(new NodeData { Value = node.val });
        data[index].LeftIndex = Deconstruct(node.left, data);
        data[index].RightIndex = Deconstruct(node.right, data);
        return index;
    }
    /// <summary>
    /// 字符串 -> 二叉树
    /// </summary>
    public TreeNode? deserialize(string s)
    {
        var data = s.Split(';', StringSplitOptions.RemoveEmptyEntries)
            .Select(x => new NodeData(x)).ToArray();
        if (data.Length == 0) return null;
        return Construct(data, 0);
    }
    /// <summary>
    /// 从数据中构造树
    /// </summary>
    TreeNode? Construct(NodeData[] data, int? index)
    {
        if (index is null) return null;
        var node = data[index.Value];
        return new(node.Value,
            Construct(data, node.LeftIndex),
            Construct(data, node.RightIndex));
    }
}
class NodeData
{
    public int Value { get; set; }
    public int? LeftIndex { get; set; }
    public int? RightIndex { get; set; }

    static int? IntParse(string s) => int.TryParse(s, out var i) ? i : null;
    public NodeData() { }
    public NodeData(string s)
    {
        var data = s.Split(',');
        Value = int.Parse(data[0]);
        LeftIndex = IntParse(data[1]);
        RightIndex = IntParse(data[2]);
    }
    public override string ToString() => $"{Value},{LeftIndex},{RightIndex}";
}