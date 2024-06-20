// https://leetcode.cn/problems/z1R5dt/?envType=study-plan-v2&envId=coding-interviews-special

namespace Leetcode.LCR066;
public class MapSum
{
    Trie root = new();

    /// <summary>
    /// 插入键值对, 如果存在则更新值
    /// </summary>
    public void Insert(string key, int value)
        => root.Insert(key, value);
    /// <summary>
    /// 以 prefix 开头的键对应值之和
    /// </summary>
    public int Sum(string prefix)
    {
        Trie node = root;
        foreach (var ch in prefix)
        {
            if (!node.children.ContainsKey(ch)) return 0;
            node = node.children[ch];
        }
        return node.Sum();
    }
    class Trie
    {
        bool isEnd = false;
        int value = 0;
        public Dictionary<char, Trie> children = [];

        /// <summary>
        /// 插入一个字符串
        /// </summary>
        public void Insert(ReadOnlySpan<char> word, int value)
        {
            if (word.Length == 0)
            {
                // 字符串结束
                isEnd = true;
                this.value = value;
                return;
            }
            var c = word[0];
            // 向对应字母的子树递归插入
            if (!children.ContainsKey(c))
                children.Add(c, new());
            children[c].Insert(word[1..], value);
        }
        /// <summary>
        /// 树中所有单词对应值之和
        /// </summary>
        public int Sum()
        {
            int sum = 0;
            if (isEnd) sum += value;
            foreach (var child in children.Values)
                sum += child.Sum();
            return sum;
        }
    }
}