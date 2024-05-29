// https://leetcode.cn/problems/h54YBf/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR048_1;
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
 * 序列策略：前序遍历，逗号分隔，空节点用空串表示
 *     11,22,44,,,,33,55,,77,88,,,,66,,
 * 
 * 序列化：直接 DFS 前序遍历即可
 * 反序列化：结合列表索引遍历与二叉树前序遍历
 */
public class Codec
{
    /// <summary>
    /// 二叉树 -> 字符串
    /// </summary>
    public string serialize(TreeNode? root)
    {
        return string.Join(',', Deconstruct(root));
    }
    /// <summary>
    /// 从树中提取数据
    /// </summary>
    IEnumerable<int?> Deconstruct(TreeNode? node)
    {
        // 生成函数：前序遍历
        if (node is null)
        {
            yield return null;
        }
        else
        {
            yield return node.val;
            foreach (var item in Deconstruct(node.left))
                yield return item;
            foreach (var item in Deconstruct(node.right))
                yield return item;
        }
    }
    /// <summary>
    /// 字符串 -> 二叉树
    /// </summary>
    public TreeNode? deserialize(string s)
    {
        var data = s.Split(',').Select(IntParse).ToArray();
        var index = -1;
        return Construct(data, ref index);
    }
    /// <summary>
    /// 从数据中构造树
    /// </summary>
    TreeNode? Construct(int?[] data, ref int index)
    {
        // 在索引遍历的同时使用递归 DFS

        index++;
        if (index == data.Length || data[index] is null)
        {
            return null;
        }
        TreeNode node = new(data[index]!.Value)
        {
            left = Construct(data, ref index),
            right = Construct(data, ref index)
        };
        return node;
    }
    static int? IntParse(string s) => s == "" ? null : int.Parse(s);
}