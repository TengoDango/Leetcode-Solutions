// https://leetcode.cn/problems/UhWRSj/?envType=study-plan-v2&envId=coding-interviews-special

using System.Text;

namespace Leetcode.LCR063;
public class Solution
{
    /// <summary>
    /// 给定一些前缀,
    /// 将句子中的单词替换为最短的前缀
    /// (如果有给定的前缀),
    /// 返回替换后的句子.
    /// </summary>
    public string ReplaceWords(IList<string> dictionary, string sentence)
    {
        Trie trie = new();
        foreach (var word in dictionary)
            trie.Add(word);

        string[] words = sentence.Split(' ');
        for (int i = 0; i < words.Length; i++)
            words[i] = trie.FindPrefix(words[i]) ?? words[i];
        return string.Join(' ', words);
    }
    class Trie
    {
        /* 循环实现 */

        bool isEnd = false;
        Dictionary<char, Trie> children = [];
        /// <summary>
        /// 添加一个单词
        /// </summary>
        public void Add(string word)
        {
            var node = this;
            foreach (var ch in word)
            {
                if (!node.children.ContainsKey(ch))
                    node.children.Add(ch, new());
                node = node.children[ch];
            }
            node.isEnd = true;
        }
        /// <summary>
        /// 查找最短的前缀,
        /// 如果不存在, 返回 null
        /// </summary>
        public string? FindPrefix(string word)
        {
            if (isEnd) return "";

            StringBuilder builder = new();
            var node = this;
            foreach (var ch in word)
            {
                if (!node.children.TryGetValue(ch, out var child))
                    return null;
                builder.Append(ch);
                node = child;
                if (node.isEnd) return builder.ToString();
            }
            return null;
        }
    }
}