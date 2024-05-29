// https://leetcode.cn/problems/h54YBf/?envType=study-plan-v2&envId=coding-interviews-special

using System.Text;

namespace Leetcode.LCR048_3;
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
 * 序列策略：括号嵌套
 *     null <-> ""
 *     TreeNode(value) <-> (<value>)
 *     TreeNode(value, left) <-> (<left><value>)
 *     TreeNode(value, left, right) <-> (<left><value><right>)
 *     ( ((44)22)  11  ((55((88)77)) 33 (66)) )
 * 
 * 序列化：任意顺序遍历 (此处使用前序遍历) 并使用 StringBuilder
 * 反序列化：递归读取嵌套括号
 */
public class Codec
{
    /// <summary>
    /// 二叉树 -> 字符串
    /// </summary>
    public string serialize(TreeNode? root)
    {
        StringBuilder data = new();
        Deconstruct(root, data);
        return data.ToString();
    }
    /// <summary>
    /// 从树中提取数据
    /// </summary>
    void Deconstruct(TreeNode? node, StringBuilder data)
    {
        if (node is null) return;
        data.Append('(');
        Deconstruct(node.left, data);
        data.Append(node.val);
        Deconstruct(node.right, data);
        data.Append(')');
    }
    /// <summary>
    /// 字符串 -> 二叉树
    /// </summary>
    public TreeNode? deserialize(string data)
    {
        if (data == "") return null;
        int index = 0;
        return ReadNode(data, ref index);
    }
    /// <summary>
    /// 从数据中构造树
    /// </summary>
    TreeNode? ReadNode(string data, ref int index)
    {
        // 读取顺序：左括号 - 左子树 - 结点值 - 右子树 - 右括号
        if (data[index] != '(') return null;

        index++; // 跳过左括号
        TreeNode node = new()
        {
            left = ReadNode(data, ref index),
            val = ReadInt(data, ref index),
            right = ReadNode(data, ref index)
        };
        index++; // 跳过右括号
        return node;
    }
    int ReadInt(string data, ref int index)
    {
        int start = index;
        while (data[index] != '(' && data[index] != ')')
            index++;
        return int.Parse(data[start..index]);
    }
}