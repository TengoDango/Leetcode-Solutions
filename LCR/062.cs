// https://leetcode.cn/problems/QC3q1f/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR062;
/// <summary>
/// 前缀树的插入和查找
/// </summary>
public class Trie
{
    /* 递归实现 */

    bool isEnd = false;
    Dictionary<char, Trie> children = [];

    /// <summary>
    /// 插入一个字符串
    /// </summary>
    public void Insert(string word)
        => Insert(word.AsSpan());
    void Insert(ReadOnlySpan<char> word)
    {
        if (word.Length == 0)
        {
            // 字符串结束
            isEnd = true;
            return;
        }
        var c = word[0];
        // 向对应字母的子树递归插入
        if (!children.ContainsKey(c))
            children.Add(c, new());
        children[c].Insert(word[1..]);
    }
    /// <summary>
    /// 查找字符串是否存在
    /// </summary>
    public bool Search(string word)
        => Search(word.AsSpan());
    bool Search(ReadOnlySpan<char> word)
    {
        if (word.Length == 0)
            return isEnd;
        var c = word[0];
        return children.ContainsKey(c)
            && children[c].Search(word[1..]);
    }
    /// <summary>
    /// 查找前缀是否存在
    /// </summary>
    public bool StartsWith(string prefix)
        => StartsWith(prefix.AsSpan());
    bool StartsWith(ReadOnlySpan<char> prefix)
    {
        if (prefix.Length == 0)
            return true;
        var c = prefix[0];
        return children.ContainsKey(c)
            && children[c].StartsWith(prefix[1..]);
    }
}