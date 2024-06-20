// https://leetcode.cn/problems/iSwD2y/?envType=study-plan-v2&envId=coding-interviews-special


namespace Leetcode.LCR065;
public class Solution
{
    /// <summary>
    /// 寻找最短压缩编码 (定义见链接)
    /// </summary>
    public int MinimumLengthEncoding(string[] words)
    {
        Trie trie = new();
        foreach (var word in words)
            trie.Insert(word);
        return trie.GetMinLength();
    }
    class Trie
    {
        bool isEnd = false;
        Dictionary<char, Trie> children = [];

        /// <summary>
        /// 插入一个字符串,
        /// 但是逆序插入
        /// </summary>
        public void Insert(ReadOnlySpan<char> word)
        {
            if (word.Length == 0)
            {
                // 字符串结束
                isEnd = true;
                return;
            }
            var c = word[^1];
            // 向对应字母的子树递归插入
            if (!children.ContainsKey(c))
                children.Add(c, new());
            children[c].Insert(word[..^1]);
        }
        /// <summary>
        /// 递归获取最短压缩编码长度
        /// </summary>
        public int GetMinLength(int depth = 1, int sum = 0)
        {
            if (children.Count == 0)
            {
                // 叶子节点
                return sum + depth;
            }
            foreach (var child in children.Values)
                sum = child.GetMinLength(depth + 1, sum);
            return sum;
        }
    }
}